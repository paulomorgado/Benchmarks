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
    public string String_Concat2(string scheme, HostString host, PathString basePath, PathString path, QueryString query)
    {
        if (!query.HasValue)
        {
            return string.Concat(scheme, "://", host.Value, basePath.Value, path.Value);
        }
        else if (!basePath.HasValue)
        {
            return string.Concat(scheme, "://", host.Value, path.Value, query.Value);
        }
        else if (!path.HasValue)
        {
            return string.Concat(scheme, "://", host.Value, basePath.Value, query.Value);
        }
        else
        {
            return string.Concat((ReadOnlySpan<string>)[scheme, "://", host.Value, basePath.Value, path, query.Value]);
        }
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
            + schemeValue.Length
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

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public string String_Create2(string scheme, HostString host, PathString basePath, PathString path, QueryString query)
    {
        var schemeValue = scheme ?? string.Empty;
        var hostValue = host.Value ?? string.Empty;
        var basePathValue = basePath.Value ?? string.Empty;
        var pathValue = path.Value ?? string.Empty;
        var queryValue = query.Value ?? string.Empty;

        var length =
            + schemeValue.Length
            + SchemeDelimiter.Length
            + hostValue.Length
            + basePathValue.Length
            + pathValue.Length
            + queryValue.Length;

        return string.Create(
            length,
            new UriParts( scheme, hostValue, basePathValue, pathValue, queryValue),
            static (buffer, uriParts) =>
            {
                if (uriParts.Scheme.Length > 0)
                {
                    uriParts.Scheme.CopyTo(buffer);
                    buffer = buffer.Slice(uriParts.Scheme.Length);
                }

                SchemeDelimiter.CopyTo(buffer);
                buffer = buffer.Slice(SchemeDelimiter.Length);

                if (uriParts.Host.Length > 0)
                {
                    uriParts.Host.CopyTo(buffer);
                    buffer = buffer.Slice(uriParts.Host.Length);
                }

                if (uriParts.BasePath.Length > 0)
                {
                    uriParts.BasePath.CopyTo(buffer);
                    buffer = buffer.Slice(uriParts.BasePath.Length);
                }

                if (uriParts.Path.Length > 0)
                {
                    uriParts.Path.CopyTo(buffer);
                    buffer = buffer.Slice(uriParts.Path.Length);
                }

                if (uriParts.Query.Length > 0)
                {
                    uriParts.Query.CopyTo(buffer);
                }
            });
    }

    private readonly struct UriParts
    {
        public readonly string Scheme;
        public readonly string Host;
        public readonly string BasePath;
        public readonly string Path;
        public readonly string Query;

        public UriParts(string scheme, string host, string basePath, string path, string query)
        {
            this.Scheme = scheme;
            this.Host = host;
            this.BasePath = basePath;
            this.Path = path;
            this.Query = query;
        }
    }
}
