// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;

namespace HttpStrings;

[MemoryDiagnoser]
[HideColumns("Error", "StdDev", "Median", "RatioSD")]
public class DisplayUrlBenchmark
{
    private static readonly string SchemeDelimiter = Uri.SchemeDelimiter;

    private static readonly string[] schemes = ["http"];
    private static readonly string[] hosts = ["cname.domain.tld"];
    private static readonly string[] basePaths = [null, "/base-path",];
    private static readonly string[] paths = ["/", "/path/one/two/three",];
    private static readonly string[] queries = [null, "?param1=value1&param2=value2&param3=value3",];

    public IEnumerable<object[]> Data()
    {
        foreach (var scheme in schemes)
        {
            foreach (var host in hosts)
            {
                foreach (var basePath in basePaths)
                {
                    foreach (var path in paths)
                    {
                        foreach (var query in queries)
                        {
                            yield return new object[] { scheme, new HostString(host), new PathString(basePath), new PathString(path), new QueryString(query), };
                        }
                    }
                }
            }
        }
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(Data))]
    public string StringBuilder(string scheme, HostString host, PathString basePath, PathString path, QueryString query)
    {
        var schemeValue = scheme ?? string.Empty;
        var hostValue = host.Value ?? string.Empty;
        var basePathValue = basePath.Value ?? string.Empty;
        var pathValue = path.Value ?? string.Empty;
        var queryValue = query.Value ?? string.Empty;

        var length =
            +schemeValue.Length
            + SchemeDelimiter
            + hostValue.Length
            + basePathValue.Length
            + pathValue.Length
            + queryValue.Length;

        return new StringBuilder(length)
                .Append(schemeValue)
                .Append(SchemeDelimiter)
                .Append(hostValue)
                .Append(basePathValue)
                .Append(pathValue)
                .Append(queryValue)
                .ToString();
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public string String_Interpolation(string scheme, HostString host, PathString basePath, PathString path, QueryString query)
    {
        return $"{scheme}://{host.Value}{basePath.Value}{path.Value}{query.Value}";
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public string String_Concat(string scheme, HostString host, PathString basePath, PathString path, QueryString query)
    {
        return string.Concat((ReadOnlySpan<string>)[scheme, "://", host.Value, basePath.Value, path, query.Value]);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public string String_Create(string scheme, HostString host, PathString basePath, PathString path, QueryString query)
    {
        var schemeValue = scheme ?? string.Empty;
        var hostValue = host.Value ?? string.Empty;
        var basePathValue = basePath.Value ?? string.Empty;
        var pathValue = path.Value ?? string.Empty;
        var queryValue = query.Value ?? string.Empty;

        var length =
            +schemeValue.Length
            + SchemeDelimiter.Length
            + hostValue.Length
            + basePathValue.Length
            + pathValue.Length
            + queryValue.Length;

        return string.Create(
            length,
            (schemeValue, hostValue, basePathValue, pathValue, queryValue),
            static (buffer, uriParts) =>
            {
                var (scheme, host, basePath, path, query) = uriParts;

                if (scheme.Length > 0)
                {
                    scheme.CopyTo(buffer);
                    buffer = buffer.Slice(scheme.Length);
                }

                SchemeDelimiter.CopyTo(buffer);
                buffer = buffer.Slice(SchemeDelimiter.Length);

                if (host.Length > 0)
                {
                    host.CopyTo(buffer);
                    buffer = buffer.Slice(host.Length);
                }

                if (basePath.Length > 0)
                {
                    basePath.CopyTo(buffer);
                    buffer = buffer.Slice(basePath.Length);
                }

                if (path.Length > 0)
                {
                    path.CopyTo(buffer);
                    buffer = buffer.Slice(path.Length);
                }

                if (query.Length > 0)
                {
                    query.CopyTo(buffer);
                }
            });
    }
}
