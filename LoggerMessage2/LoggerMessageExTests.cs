using LoggerMessageBenchmarks;
using Microsoft.Extensions.Logging;
using Shouldly;
using Xunit;

namespace LoggerMessage2Tests
{
    internal sealed class TestLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            this.Message = formatter(state, exception);
        }
        public string? Message { get; private set; }
    }

    public static class LoggerMessageExTests
    {
        [Fact]
        public static void LoggerMessageDefine0ArgumentsTests()
        {
            // Arrange

            var logger = new TestLogger();

            Benchmark.LoggerMessageDelegate0Arguments(logger, null);
            var expected = logger.Message;

            // Act

            Benchmark.LoggerMessageExDelegate0Arguments(logger, null);
            var actual = logger.Message;

            // Assert

            actual.ShouldBe(expected);
        }

        [Fact]
        public static void LoggerMessageDefine3ValueTypeArguments()
        {
            // Arrange

            var logger = new TestLogger();

            Benchmark.LoggerMessageDelegate3ValueTypeArguments(logger, 0, null, int.MaxValue, null);
            var expected = logger.Message;

            // Act

            Benchmark.LoggerMessageExDelegate3ValueTypeArguments(logger, 0, null, int.MaxValue, null);
            var actual = logger.Message;

            // Assert

            actual.ShouldBe(expected);
        }

        [Fact]
        public static void LoggerMessageDefine6ValueTypeArguments()
        {
            // Arrange

            var logger = new TestLogger();

            Benchmark.LoggerMessageDelegate6ValueTypeArguments(logger, 0, null, int.MaxValue, 0, null, int.MinValue, null);
            var expected = logger.Message;

            // Act

            Benchmark.LoggerMessageExDelegate6ValueTypeArguments(logger, 0, null, int.MaxValue, 0, null, int.MinValue, null);
            var actual = logger.Message;

            // Assert

            actual.ShouldBe(expected);
        }

        [Fact]
        public static void LoggerMessageDefine3ReferenceTypeArguments()
        {
            // Arrange

            var logger = new TestLogger();

            Benchmark.LoggerMessageDelegate3ReferenceTypeArguments(logger, string.Empty, null, Benchmark.Text1, null);
            var expected = logger.Message;

            // Act

            Benchmark.LoggerMessageExDelegate3ReferenceTypeArguments(logger, string.Empty, null, Benchmark.Text1, null);
            var actual = logger.Message;

            // Assert

            actual.ShouldBe(expected);
        }

        [Fact]
        public static void LoggerMessageDefine6ReferenceTypeArguments()
        {
            // Arrange

            var logger = new TestLogger();

            Benchmark.LoggerMessageDelegate6ReferenceTypeArguments(logger, string.Empty, null, Benchmark.Text1, string.Empty, null, Benchmark.Text2, null);
            var expected = logger.Message;

            // Act

            Benchmark.LoggerMessageExDelegate6ReferenceTypeArguments(logger, string.Empty, null, Benchmark.Text1, string.Empty, null, Benchmark.Text2, null);
            var actual = logger.Message;

            // Assert

            actual.ShouldBe(expected);
        }
    }
}
