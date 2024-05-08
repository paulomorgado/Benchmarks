// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using IdentityModel;
using Microsoft.Extensions.Primitives;

namespace DuendeBenchmarks;

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
[MemoryDiagnoser]
public class IsDPoPErrorBenchmarks
{
    private const string AuthorizationHeaderDPoP = "DPoP";
    private const string Error = "error";
    private const string UseDPoPNonce = "use_dpop_nonce";

    private BasicAuthenticationHeaderValue header;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.header = new BasicAuthenticationHeaderValue(AuthorizationHeaderDPoP, $"{Error}=\"{UseDPoPNonce}\"");
    }

    [Benchmark(Baseline = true)]
    public bool UsingLinqAndStringOperations()
    {
        var header = this.header;

        if (header != null && header.Parameter != null)
        {
            // WWW-Authenticate: DPoP error="use_dpop_nonce"
            var values = header.Parameter.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var error = values.Select(x =>
            {
                var parts = x.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && parts[0] == OidcConstants.TokenResponse.Error)
                {
                    return parts[1].Trim('"');
                }
                return null;
            }).Where(x => x != null).FirstOrDefault();

            return error == OidcConstants.TokenErrors.UseDPoPNonce || error == OidcConstants.TokenErrors.InvalidDPoPProof;
        }

        return false;
    }

    [Benchmark]
    public bool UsingIterationAndSpanOperations()
    {
        var header = this.header;

        if (header.Scheme == OidcConstants.AuthenticationSchemes.AuthorizationHeaderDPoP
            && header.Parameter is not null)
        {
            // WWW-Authenticate: DPoP error="use_dpop_nonce"
            var remaining = header.Parameter.AsSpan();

            while (!remaining.IsEmpty)
            {
                ReadOnlySpan<char> parameter;

                var separatorIndex = remaining.IndexOf(',');
                if (separatorIndex == -1)
                {
                    parameter = remaining;
                    remaining = ReadOnlySpan<char>.Empty;
                }
                else
                {
                    parameter = remaining.Slice(0, separatorIndex);
                    remaining = remaining.Slice(separatorIndex + 1).Trim(' ');
                }

                if (!parameter.IsEmpty)
                {
                    var equalsIndex = parameter.IndexOf("=");
                    if (equalsIndex != -1)
                    {
                        var name = parameter.Slice(0, equalsIndex).Trim(' ');
                        var value = parameter.Slice(equalsIndex + 1).Trim(' ').Trim('"');

                        if (name.SequenceEqual(OidcConstants.TokenResponse.Error.AsSpan()))
                        {
                            return value.SequenceEqual(OidcConstants.TokenErrors.UseDPoPNonce.AsSpan())
                                || value.SequenceEqual(OidcConstants.TokenErrors.InvalidDPoPProof.AsSpan());
                        }
                    }
                }
            }
        }

        return false;
    }

    [Benchmark]
    public bool UsingStringTokenizer()
    {
        var header = this.header;

        if (header.Scheme == OidcConstants.AuthenticationSchemes.AuthorizationHeaderDPoP
            && header.Parameter is not null)
        {
            // WWW-Authenticate: DPoP error="use_dpop_nonce"

            foreach (var parameterSegment in new StringTokenizer(header.Parameter, [',']))
            {
                ExtractNameValue(parameterSegment.AsSpan(), out var name, out var value);

                if (name.SequenceEqual(OidcConstants.TokenResponse.Error.AsSpan()))
                {
                    return value.SequenceEqual(OidcConstants.TokenErrors.UseDPoPNonce.AsSpan())
                        || value.SequenceEqual(OidcConstants.TokenErrors.InvalidDPoPProof.AsSpan());
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                static void ExtractNameValue(ReadOnlySpan<char> nameValuePair, out ReadOnlySpan<char> name, out ReadOnlySpan<char> value)
                {
                    var idx = nameValuePair.IndexOf('=');
                    if (idx != -1)
                    {
                        name = nameValuePair.Slice(0, idx).Trim();
                        value = nameValuePair.Slice(idx + 1).Trim();
                    }
                    else
                    {
                        name = nameValuePair.Trim();
                        value = ReadOnlySpan<char>.Empty;
                    }
                }
            }
        }

        return false;
    }
}
