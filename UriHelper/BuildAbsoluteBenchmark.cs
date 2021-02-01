using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace UriHelperBenchmarks
{

    [MemoryDiagnoser]
    public class BuildAbsoluteBenchmark
    {

        public IEnumerable<object[]> Data() => TestData.HostPathBasePathQueryFragment();

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public string UriHelper_BuildRelative(HostString host, PathString pathBase, PathString path, QueryString query, FragmentString fragment)
            => UriHelper.BuildAbsolute("https", host, pathBase, path, query, fragment);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string StringBuilder_WithoutCombinedPathGeneration(HostString host, PathString pathBase, PathString path, QueryString query, FragmentString fragment)
        {
            var scheme = "https";
            var SchemeDelimiter = Uri.SchemeDelimiter;

            var encodedHost = host.ToUriComponent();
            var encodedPathBase = pathBase.ToUriComponent();
            var encodedPath = path.ToUriComponent();
            var encodedQuery = query.ToUriComponent();
            var encodedFragment = fragment.ToUriComponent();

            // PERF: Calculate string length to allocate correct buffer size for StringBuilder.
            var length =
                scheme.Length +
                SchemeDelimiter.Length +
                encodedHost.Length +
                encodedPathBase.Length +
                encodedPath.Length +
                encodedQuery.Length +
                encodedFragment.Length;

            if (!pathBase.HasValue && !path.HasValue)
            {
                length++;
            }

            var builder = new StringBuilder(length)
                .Append(scheme)
                .Append(SchemeDelimiter)
                .Append(encodedHost);

            if (!pathBase.HasValue && !path.HasValue)
            {
                builder.Append('/');
            }
            else
            {
                builder
                    .Append(encodedPathBase)
                    .Append(encodedPath);
            }

            return builder
                .Append(encodedQuery)
                .Append(encodedFragment)
                .ToString();
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string String_Concat_WithArrayArgument(HostString host, PathString pathBase, PathString path, QueryString query, FragmentString fragment)
        {
            var scheme = "https";
            var SchemeDelimiter = Uri.SchemeDelimiter;

            if (!pathBase.HasValue && !path.HasValue)
            {
                return scheme + SchemeDelimiter + "/" + host.ToUriComponent() + "/" + query.ToUriComponent() + fragment.ToUriComponent();
            }
            else
            {
                return scheme + SchemeDelimiter + pathBase.ToUriComponent() + path.ToUriComponent() + host.ToUriComponent() + "/" + query.ToUriComponent() + fragment.ToUriComponent();
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string String_Create(HostString hostString, PathString pathBaseString, PathString pathString, QueryString queryString, FragmentString fragmentString)
        {
            var scheme = "https";
            var host = hostString.ToUriComponent();
            var pathBase = pathBaseString.ToUriComponent();
            var path = pathString.ToUriComponent();
            var query = queryString.ToUriComponent();
            var fragment = fragmentString.ToUriComponent();

            // PERF: Calculate string length to allocate correct buffer size for string.Create.
            var length =
                scheme.Length +
                Uri.SchemeDelimiter.Length +
                host.Length +
                pathBase.Length +
                path.Length +
                query.Length +
                fragment.Length;

            if (string.IsNullOrEmpty(pathBase) && string.IsNullOrEmpty(path))
            {
                path = "/";
                length++;
            }

            return string.Create(length, (scheme, host, pathBase, path, query, fragment), initializeStringSpanAction);
        }

        private static readonly SpanAction<char, (string scheme, string host, string pathBase, string path, string query, string fragment)> initializeStringSpanAction = new(InitializeString);

        private static void InitializeString(Span<char> buffer, (string scheme, string host, string pathBase, string path, string query, string fragment) uriParts)
        {
            var index = 0;

            index = Copy(buffer, index, uriParts.scheme);
            index = Copy(buffer, index, Uri.SchemeDelimiter);
            index = Copy(buffer, index, uriParts.host);
            index = Copy(buffer, index, uriParts.pathBase);
            index = Copy(buffer, index, uriParts.path);
            index = Copy(buffer, index, uriParts.query);
            _ = Copy(buffer, index, uriParts.fragment);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static int Copy(Span<char> buffer, int index, string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var span = text.AsSpan();
                    span.CopyTo(buffer.Slice(index, span.Length));
                    return index + span.Length;
                }

                return index;
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string String_Create_WithCustomStruct(HostString hostString, PathString pathBaseString, PathString pathString, QueryString queryString, FragmentString fragmentString)
        {
            var scheme = "https";
            var host = hostString.ToUriComponent();
            var pathBase = pathBaseString.ToUriComponent();
            var path = pathString.ToUriComponent();
            var query = queryString.ToUriComponent();
            var fragment = fragmentString.ToUriComponent();

            // PERF: Calculate string length to allocate correct buffer size for string.Create.
            var length =
                scheme.Length +
                Uri.SchemeDelimiter.Length +
                host.Length +
                pathBase.Length +
                path.Length +
                query.Length +
                fragment.Length;

            if (string.IsNullOrEmpty(pathBase) && string.IsNullOrEmpty(path))
            {
                path = "/";
                length++;
            }

            return string.Create(length, new AbsoluteUriParts(scheme, host, pathBase, path, query, fragment), initializeAbsoluteUriStringSpanAction);
        }

        private static readonly SpanAction<char, AbsoluteUriParts> initializeAbsoluteUriStringSpanAction = new(InitializeAbsoluteUriString);

        private static void InitializeAbsoluteUriString(Span<char> buffer, AbsoluteUriParts uriParts)
        {
            var index = 0;

            index = Copy(buffer, index, uriParts.Scheme);
            index = Copy(buffer, index, Uri.SchemeDelimiter);
            index = Copy(buffer, index, uriParts.Host);
            index = Copy(buffer, index, uriParts.PathBase);
            index = Copy(buffer, index, uriParts.Path);
            index = Copy(buffer, index, uriParts.Query);
            _ = Copy(buffer, index, uriParts.Fragment);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static int Copy(Span<char> buffer, int index, string text)
            {
                if (!string.IsNullOrEmpty(text))
                {
                    var span = text.AsSpan();
                    span.CopyTo(buffer.Slice(index, span.Length));
                    return index + span.Length;
                }

                return index;
            }
        }

        private readonly struct AbsoluteUriParts
        {
            public readonly string Scheme;
            public readonly string Host;
            public readonly string PathBase;
            public readonly string Path;
            public readonly string Query;
            public readonly string Fragment;

            public AbsoluteUriParts(string scheme, string host, string pathBase, string path, string query, string fragment)
            {
                this.Scheme = scheme;
                this.Host = host;
                this.PathBase = pathBase;
                this.Path = path;
                this.Query = query;
                this.Fragment = fragment;
            }
        }
    }
}
