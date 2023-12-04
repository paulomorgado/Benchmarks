// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Duende.AccessTokenManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace DuendeBenchmarks;

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
[MemoryDiagnoser]
public class AddClientCredentialsTokenHandlerBenchmarks
{
    private IServiceProvider serviceProviderWithTransientTokenServices;
    private IServiceProvider serviceProviderWithSingletonTokenServices;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.serviceProviderWithTransientTokenServices = RegisterTransient();
        this.serviceProviderWithSingletonTokenServices = SingletonTransient();
    }

    private static IServiceProvider RegisterTransient()
    {
        var services = new ServiceCollection();

        RegisterCommon(services);

        return services.BuildServiceProvider();
    }

    private static IServiceProvider SingletonTransient()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IClientCredentialsTokenManagementService, ClientCredentialsTokenManagementService>();
        services.AddSingleton<IClientCredentialsTokenCache, DistributedClientCredentialsTokenCache>();
        services.AddSingleton<IClientCredentialsTokenEndpointService, ClientCredentialsTokenEndpointService>();
        services.AddSingleton<IClientAssertionService, DefaultClientAssertionService>();

        services.AddSingleton<IDPoPProofService, DefaultDPoPProofService>();
        services.AddSingleton<IDPoPKeyStore, DefaultDPoPKeyStore>();
        services.AddSingleton<IDPoPNonceStore, DistributedDPoPNonceStore>();

        RegisterCommon(services);

        return services.BuildServiceProvider();
    }

    private static void RegisterCommon(ServiceCollection services)
    {
        services.AddClientCredentialsTokenManagement()
            .AddClient("test", options => { });

        services.AddHttpClient("test")
            .AddClientCredentialsTokenHandler("test");

        services.AddDistributedMemoryCache();
    }

    [Benchmark(Baseline = true)]
    public ClientCredentialsTokenHandler ClientCredentialsTokenHandlerWithTransientTokenServices()
        => CreateClientCredentialsTokenHandler(this.serviceProviderWithTransientTokenServices, "test");

    [Benchmark]
    public ClientCredentialsTokenHandler ClientCredentialsTokenHandlerWithSingletonTokenServices()
        => CreateClientCredentialsTokenHandler(this.serviceProviderWithSingletonTokenServices, "test");

    private static ClientCredentialsTokenHandler CreateClientCredentialsTokenHandler(IServiceProvider provider, string tokenClientName)
    {
        var dpopService = provider.GetRequiredService<IDPoPProofService>();
        var dpopNonceStore = provider.GetRequiredService<IDPoPNonceStore>();
        var accessTokenManagementService = provider.GetRequiredService<IClientCredentialsTokenManagementService>();
        var logger = provider.GetRequiredService<ILogger<ClientCredentialsTokenHandler>>();

        return new ClientCredentialsTokenHandler(dpopService, dpopNonceStore, accessTokenManagementService, logger, tokenClientName);
    }
}
