using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UriHelperBenchmarks
{
    public static class TestData
    {
        private static readonly string[] hosts = new[] { "cname.domain.tld" };
        private static readonly string[] basePaths = new[] { "", "/base-path", };
        private static readonly string[] paths = new[] { "", "/path/one/two/three", };
        private static readonly string[] queries = new[] { "", "?param1=value1&param2=value2&param3=value3", };
        private static readonly string[] fragments = new[] { "", "#fragment", };

        public static IEnumerable<object[]> HostPathBasePathQuery()
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

        public static IEnumerable<object[]> HostPathBasePathQueryFragment()
        {
            foreach (var host in hosts)
            {
                foreach (var basePath in basePaths)
                {
                    foreach (var path in paths)
                    {
                        foreach (var query in queries)
                        {
                            foreach (var fragment in fragments)
                            {
                                yield return new object[] { new HostString(host), new PathString(basePath), new PathString(path), new QueryString(query), new FragmentString(fragment), };
                            }
                        }
                    }
                }
            }
        }

        public static IEnumerable<object[]> PathBasePathQueryFragment()
        {
            foreach (var basePath in basePaths)
            {
                foreach (var path in paths)
                {
                    foreach (var query in queries)
                    {
                        foreach (var fragment in fragments)
                        {
                            yield return new object[] { new PathString(basePath), new PathString(path), new QueryString(query), new FragmentString(fragment), };
                        }
                    }
                }
            }
        }
    }
}