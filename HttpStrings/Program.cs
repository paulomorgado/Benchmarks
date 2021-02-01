using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StringTests
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private static readonly string[] hosts = new[] { "cname.domain.tld" };
        private static readonly string[] basePaths = new[] { null, "/base-path", };
        private static readonly string[] paths = new[] { "/", "/path/one/two/three", };
        private static readonly string[] queries = new[] { null, "?param1=value1&param2=value2&param3=value3", };

        public IEnumerable<object[]> Data()
        {
            foreach (var host in hosts)
            {
                foreach (var basePath in basePaths)
                {
                    foreach (var path in paths)
                    {
                        foreach (var query in queries)
                        {
                            yield return new object[] { new HostString(host), new PathString(basePath), new PathString(path), new QueryString(query), };
                        }
                    }
                }
            }
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public string StringBuilderWithBoxing(HostString host, PathString basePath, PathString path, QueryString query)
            => new StringBuilder()
                .Append("https://")
                .Append(host)
                .Append(basePath)
                .Append(path)
                .Append(query)
                .ToString();

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string StringBuilderWithoutBoxing(HostString host, PathString basePath, PathString path, QueryString query)
            => new StringBuilder()
                .Append("https://")
                .Append(host.ToUriComponent())
                .Append(basePath.ToUriComponent())
                .Append(path.ToUriComponent())
                .Append(query.ToUriComponent())
            .ToString();

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string StringFormatWithBoxing(HostString host, PathString basePath, PathString path, QueryString query)
            => $"https://{host}{basePath}{path}{query}";

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string StringFormatWithoutBoxing(HostString host, PathString basePath, PathString path, QueryString query)
            => $"https://{host.ToUriComponent()}{basePath.ToUriComponent()}{path.ToUriComponent()}{query.ToUriComponent()}";

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string StringConcat(HostString host, PathString basePath, PathString path, QueryString query)
        {
            if (!basePath.HasValue)
            {
                return string.Concat("https://", host, path.ToUriComponent(), query.ToUriComponent());
            }

            if (!query.HasValue)
            {
                return string.Concat("https://", host, basePath.ToUriComponent(), path.ToUriComponent());
            }

            return string.Concat("https://", host, basePath.ToUriComponent(), path.ToUriComponent(), query.ToUriComponent());
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string Crazy1(HostString host, PathString basePath, PathString path, QueryString query)
        {
            var uriParts = (
                scheme: "https://",
                host: host.ToUriComponent(),
                basePath: basePath.ToUriComponent(),
                path: path.ToUriComponent(),
                query: query.ToUriComponent());

            var length = uriParts.scheme.Length + uriParts.host.Length + uriParts.basePath.Length + uriParts.path.Length + uriParts.query.Length;

            return string.Create(
                length,
                uriParts,
                (buffer, uriParts) =>
                {
                    var i = -1;

                    foreach (var c in uriParts.scheme)
                    {
                        buffer[++i] = c;
                    }

                    foreach (var c in uriParts.host)
                    {
                        buffer[++i] = c;
                    }

                    if (uriParts.basePath.Length != 0)
                    {
                        foreach (var c in uriParts.basePath)
                        {
                            buffer[++i] = c;
                        }
                    }

                    foreach (var c in uriParts.path)
                    {
                        buffer[++i] = c;
                    }

                    if (uriParts.query.Length != 0)
                    {
                        foreach (var c in uriParts.query)
                        {
                            buffer[++i] = c;
                        }
                    }
                });
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string Crazy2(HostString host, PathString basePath, PathString path, QueryString query)
        {
            const string httpsSchemePrefix = "https://";
            const int httpsSchemePrefixLength = 8;
            Debug.Assert(httpsSchemePrefix.Length == httpsSchemePrefixLength, "{nameof(httpsSchemePrefixLength)} should be {httpsSchemePrefix.Length} and is {httpsSchemePrefixLength}");

            var uriParts = (
                host: host.ToUriComponent(),
                basePath: basePath.ToUriComponent(),
                path: path.ToUriComponent(),
                query: query.ToUriComponent());

            var length = httpsSchemePrefixLength + uriParts.host.Length + uriParts.basePath.Length + uriParts.path.Length + uriParts.query.Length;

            return string.Create(
                length,
                uriParts,
                (buffer, uriParts) =>
                {
                    var span = httpsSchemePrefix.AsSpan();
                    span.CopyTo(buffer);

                    var i = httpsSchemePrefixLength;

                    span = uriParts.host.AsSpan();
                    span.CopyTo(buffer.Slice(i, span.Length));
                    i += span.Length;

                    if (uriParts.basePath.Length != 0)
                    {
                        span = uriParts.basePath.AsSpan();
                        span.CopyTo(buffer.Slice(i, span.Length));
                        i += span.Length;
                    }

                    span = uriParts.path.AsSpan();
                    span.CopyTo(buffer.Slice(i, span.Length));
                    i += span.Length;

                    if (uriParts.query.Length != 0)
                    {
                        span = uriParts.query.AsSpan();
                        span.CopyTo(buffer.Slice(i, span.Length));
                    }
                });
        }
    }
}
