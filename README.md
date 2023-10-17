# Benchmarks

This repo contains a series of benchmarks to test performance theories:

* General .NET
  * [DictionaryCopyOnWrite](DictionaryCopyOnWrite)
  * [ListFor](ListFor)
  * [StringTests](StringTests)
  * [ByteArrayAllocation](ByteArrayAllocation)
  * [StringBuilderBufferAllocation](StringBuilderBufferAllocation)
  * [`IComparer<T>` vs. `Comparison<T>`](ComparerComparison)
  * Text Comparison
    * [TextComparison1](TextComparison1/README.md)
  * [`Guid`](GuidBenchmarks)
* ASP.NET
  * [UriHelper](UriHelper)
  * [HttpStrings](HttpStrings)
* Logging
  * Microsoft
    * [`LoggerMessage` vs no `DefineMessage`](Logging/Microsoft/LoggerMessage1/README.md)
    * [`LoggerMessage` vs `DefineMessage` with `DefaultInterpolatedStringHandler`](Logging/Microsoft/LoggerMessage2/README.md)
    * [`LoggerMessage` vs `DefineMessage` with `DefaultInterpolatedStringHandler`](Logging/Microsoft/LoggerMessage2/README.md)
    * [Performance implications of the different methods of logging](Logging/Microsoft/LoggingPerformance/README.md)
  * Serilog
    * [`LoggerMessage` vs `DefineMessage` with `DefaultInterpolatedStringHandler`](Logging/Serilog/SerilogPropertyDestructuring/README.md)


## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for information on contributing to this project.

This project has adopted the code of conduct defined by the [Contributor Covenant](http://contributor-covenant.org/) 
to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](http://www.dotnetfoundation.org/code-of-conduct).

## License

This project is licensed with the [MIT license](LICENSE).

## .NET Foundation

New Repo is a [.NET Foundation project](https://dotnetfoundation.org/projects).

## Related Projects

You should take a look at these related projects:

- [.NET Core](https://github.com/dotnet/core)
- [ASP.NET](https://github.com/aspnet)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
