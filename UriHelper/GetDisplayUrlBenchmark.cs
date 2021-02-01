using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UriHelperBenchmarks
{
    [MemoryDiagnoser]
    public class GetDisplayUrlBenchmark
    {

        public IEnumerable<HttpRequest> Data() => TestData.HostPathBasePathQuery()
            .Select(d => new BenchmarkHttpRequest("https", (HostString)d[0], (PathString)d[1], (PathString)d[2], (QueryString)d[3]));

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public string UriHelper_BuildRelative(HttpRequest request)
            => UriHelper.GetDisplayUrl(request);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string String_Concat_WithArrayArgument(HttpRequest request)
        {
            return
                "https" +
                (request.Host.Value ?? string.Empty) +
                (request.PathBase.Value ?? string.Empty) +
                (request.Path.Value ?? string.Empty) +
                (request.QueryString.Value ?? string.Empty);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string String_Create(HttpRequest request)
        {
            var scheme = "https";
            var host = request.Host.ToUriComponent();
            var pathBase = request.PathBase.ToUriComponent();
            var path = request.Path.ToUriComponent();
            var query = request.QueryString.ToUriComponent();

            // PERF: Calculate string length to allocate correct buffer size for string.Create.
            var length =
                scheme.Length +
                Uri.SchemeDelimiter.Length +
                host.Length +
                pathBase.Length +
                path.Length +
                query.Length;

            if (string.IsNullOrEmpty(pathBase) && string.IsNullOrEmpty(path))
            {
                path = "/";
                length++;
            }

            return string.Create(length, (scheme, host, pathBase, path, query), initializeStringSpanAction);
        }

        private static readonly SpanAction<char, (string scheme, string host, string pathBase, string path, string query)> initializeStringSpanAction = new(InitializeString);

        private static void InitializeString(Span<char> buffer, (string scheme, string host, string pathBase, string path, string query) uriParts)
        {
            var index = 0;

            index = Copy(buffer, index, uriParts.scheme);
            index = Copy(buffer, index, Uri.SchemeDelimiter);
            index = Copy(buffer, index, uriParts.host);
            index = Copy(buffer, index, uriParts.pathBase);
            index = Copy(buffer, index, uriParts.path);
            _ = Copy(buffer, index, uriParts.query);

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
        public string String_Create_WithCustomStruct(HttpRequest request)
        {
            var scheme = "https";
            var host = request.Host.ToUriComponent();
            var pathBase = request.PathBase.ToUriComponent();
            var path = request.Path.ToUriComponent();
            var query = request.QueryString.ToUriComponent();

            // PERF: Calculate string length to allocate correct buffer size for string.Create.
            var length =
                scheme.Length +
                Uri.SchemeDelimiter.Length +
                host.Length +
                pathBase.Length +
                path.Length +
                query.Length;

            if (string.IsNullOrEmpty(pathBase) && string.IsNullOrEmpty(path))
            {
                path = "/";
                length++;
            }

            return string.Create(length, new DisplayUrlParts(scheme, host, pathBase, path, query), initializeDisplayUrlStringSpanAction);
        }

        private static readonly SpanAction<char, DisplayUrlParts> initializeDisplayUrlStringSpanAction = new(InitializeDisplayUrlString);

        private static void InitializeDisplayUrlString(Span<char> buffer, DisplayUrlParts uriParts)
        {
            var index = 0;

            index = Copy(buffer, index, uriParts.Scheme);
            index = Copy(buffer, index, Uri.SchemeDelimiter);
            index = Copy(buffer, index, uriParts.Host);
            index = Copy(buffer, index, uriParts.PathBase);
            index = Copy(buffer, index, uriParts.Path);
            _ = Copy(buffer, index, uriParts.Query);

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

        private readonly struct DisplayUrlParts
        {
            public readonly string Scheme;
            public readonly string Host;
            public readonly string PathBase;
            public readonly string Path;
            public readonly string Query;

            public DisplayUrlParts(string scheme, string host, string pathBase, string path, string query)
            {
                this.Scheme = scheme;
                this.Host = host;
                this.PathBase = pathBase;
                this.Path = path;
                this.Query = query;
            }
        }

        private class BenchmarkHttpRequest : HttpRequest
        {
            public BenchmarkHttpRequest(string scheme, HostString host, PathString pathBase, PathString path, QueryString query) : base()
            {
                this.Scheme = scheme;
                this.Host = host;
                this.PathBase = pathBase;
                this.Path = path;
                this.QueryString = query;
            }

            public override HttpContext HttpContext => throw new NotImplementedException();
            public override string Method { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override string Scheme { get; set; }
            public override bool IsHttps { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override HostString Host { get; set; }
            public override PathString PathBase { get; set; }
            public override PathString Path { get; set; }
            public override QueryString QueryString { get; set; }
            public override IQueryCollection Query { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override string Protocol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override IHeaderDictionary Headers => throw new NotImplementedException();
            public override IRequestCookieCollection Cookies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override long? ContentLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override string ContentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override System.IO.Stream Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override bool HasFormContentType => throw new NotImplementedException();
            public override IFormCollection Form { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            public override System.Threading.Tasks.Task<IFormCollection> ReadFormAsync(System.Threading.CancellationToken cancellationToken = default) => throw new NotImplementedException();
            public override string ToString() => UriHelper.GetDisplayUrl(this);
        }
    }
}
