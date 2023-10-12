using Serilog;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Serilog.Events;
using Serilog.Core;

BenchmarkSwitcher.FromAssembly(typeof(SerilogBenchmarks).Assembly).Run(args);

[HideColumns("Error", "StdDev", "Median", "RatioSD")]
[MemoryDiagnoser]
public class SerilogBenchmarks
{
    Data data = new()
    {
        Name = "Name",
        Value = 42,
        Inner = new()
        {
            Name = "InnerName",
            Value = 24
        }
    };

    [GlobalSetup]
    public void Setup() =>
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Sink(new LogEventSink())
            .CreateLogger();

    [Params(LogEventLevel.Information, LogEventLevel.Debug)]
    public LogEventLevel LogEventLevel { get; set; }

    [Benchmark(Baseline = true)]
    public void DiscreteProperties() => Log.Write(this.LogEventLevel, "Data=(Name={Name}, Value={Value}, Inner=(Name={InnerName}, Value={InnerValue}))", this.data.Name, this.data.Value, this.data.Inner.Name, this.data.Inner.Value);

    [Benchmark]
    public void PropertyDestructuring() => Log.Write(this.LogEventLevel, "{@Data}", this.data);
}

public class Data
{
    public string? Name { get; init; }
    public int Value { get; init; }
    public InnerData? Inner { get; init; }
}

public class InnerData
{
    public string? Name { get; init; }
    public int Value { get; init; }
}

class LogEventSink : ILogEventSink
{
    public void Emit(LogEvent logEvent)
    {
    }
}
