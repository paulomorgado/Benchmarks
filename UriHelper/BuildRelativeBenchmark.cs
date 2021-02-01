using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UriHelperBenchmarks
{
    [MemoryDiagnoser]
    public class BuildRelativeBenchmark
    {
        public IEnumerable<object[]> Data() => TestData.PathBasePathQueryFragment();

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public string UriHelper_BuildRelative(PathString pathBase, PathString path, QueryString query, FragmentString fragment)
            => UriHelper.BuildRelative(pathBase, path, query, fragment);

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string Single_Concat(PathString pathBase, PathString path, QueryString query, FragmentString fragment)
        {
            if (pathBase.HasValue || path.HasValue)
            {
                return pathBase.ToUriComponent() + path.ToUriComponent() + query.ToUriComponent() + fragment.ToUriComponent();
            }
            else
            {
                return "/" + query.ToUriComponent() + fragment.ToUriComponent();
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string String_Create(PathString pathBaseString, PathString pathString, QueryString queryString, FragmentString fragmentString)
        {
            var pathBase = pathBaseString.ToUriComponent();
            var path = pathString.ToUriComponent();
            var query = queryString.ToUriComponent();
            var fragment = fragmentString.ToUriComponent();

            var length = pathBase.Length + path.Length + query.Length + fragment.Length;

            if (string.IsNullOrEmpty(pathBase) && string.IsNullOrEmpty(path))
            {
                if (length == 0)
                {
                    return "/";
                }

                path = "/";
                length++;
            }
            else
            {
                if (!string.IsNullOrEmpty(pathBase) && pathBase.Length == length)
                {
                    return pathBase;
                }

                if (path.Length == length)
                {
                    return path;
                }
            }

            return string.Create(length, (pathBase, path, query, fragment), initializeStringSpanAction);
        }

        private static readonly SpanAction<char, (string pathBase, string path, string query, string fragment)> initializeStringSpanAction = new(InitializeString);

        private static void InitializeString(Span<char> buffer, (string pathBase, string path, string query, string fragment) uriParts)
        {
            var index = 0;

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
    }
}
