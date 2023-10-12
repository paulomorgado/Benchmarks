// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.Logging
{
    public sealed class LogValuesFormatter
    {
        private const string NullValue = "(null)";
        private static readonly char[] FormatDelimiters = { ',', ':' };
        private readonly string[] _valueNames;
        private readonly int?[] _valueAlignments;
        private readonly string?[] _valueFormats;
        private readonly string[] _formatSegments;

        // NOTE: If this assembly ever builds for netcoreapp, the below code should change to:
        // - Be annotated as [SkipLocalsInit] to avoid zero'ing the stackalloc'd char span
        // - Format _valueNames.Length directly into a span

        public LogValuesFormatter(string format)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            OriginalFormat = format;

            var formatSegments = new List<string>(7);
            var valueNames = new List<string>(6);
            var valueAlignments = new List<int?>(6);
            var valueFormats = new List<string?>(6);
            var scanIndex = 0;
            var endIndex = format.Length;

            while (scanIndex < endIndex)
            {
                var openBraceIndex = FindBraceIndex(format, '{', scanIndex, endIndex);
                if (scanIndex == 0 && openBraceIndex == endIndex)
                {
                    // No holes found.
                    formatSegments.Add(format);
                    break;
                }

                var closeBraceIndex = FindBraceIndex(format, '}', openBraceIndex, endIndex);

                if (closeBraceIndex == endIndex)
                {
                    formatSegments.Add(format.Substring(scanIndex, endIndex - scanIndex));
                    scanIndex = endIndex;
                }
                else
                {
                    // Format item syntax : { index[,alignment][ :formatString] }.
                    var formatDelimiterIndex = FindIndexOfAny(format, FormatDelimiters, openBraceIndex, closeBraceIndex);

                    formatSegments.Add(format.Substring(scanIndex, openBraceIndex - scanIndex));

                    valueNames.Add(format.Substring(openBraceIndex + 1, formatDelimiterIndex - openBraceIndex - 2));

                    var (valueAlignment, valueFormat) = ParseAlignmentAndFormat(format, formatDelimiterIndex, closeBraceIndex - formatDelimiterIndex);
                    valueAlignments.Add(valueAlignment);
                    valueFormats.Add(valueFormat);

                    scanIndex = closeBraceIndex + 1;
                }
            }

            _valueNames = valueNames.ToArray();
            _valueFormats = valueFormats.ToArray();
            _valueAlignments = valueAlignments.ToArray();

            if (formatSegments.Count == _valueNames.Length)
            {
                formatSegments.Add(string.Empty);
            }
            _formatSegments = formatSegments.ToArray();
        }

        public string OriginalFormat { get; private set; }
        public ReadOnlySpan<string> ValueNames => new ReadOnlySpan<string>(_valueNames);

        private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex)
        {
            // Example: {{prefix{{{Argument}}}suffix}}.
            var braceIndex = endIndex;
            var scanIndex = startIndex;
            var braceOccurrenceCount = 0;

            while (scanIndex < endIndex)
            {
                if (braceOccurrenceCount > 0 && format[scanIndex] != brace)
                {
                    if (braceOccurrenceCount % 2 == 0)
                    {
                        // Even number of '{' or '}' found. Proceed search with next occurrence of '{' or '}'.
                        braceOccurrenceCount = 0;
                        braceIndex = endIndex;
                    }
                    else
                    {
                        // An unescaped '{' or '}' found.
                        break;
                    }
                }
                else if (format[scanIndex] == brace)
                {
                    if (brace == '}')
                    {
                        if (braceOccurrenceCount == 0)
                        {
                            // For '}' pick the first occurrence.
                            braceIndex = scanIndex;
                        }
                    }
                    else
                    {
                        // For '{' pick the last occurrence.
                        braceIndex = scanIndex;
                    }

                    braceOccurrenceCount++;
                }

                scanIndex++;
            }

            return braceIndex;
        }

        private static int FindIndexOfAny(string format, char[] chars, int startIndex, int endIndex)
        {
            var findIndex = format.IndexOfAny(chars, startIndex, endIndex - startIndex);
            return findIndex == -1 ? endIndex : findIndex;
        }

        private static (int? alignment, string? format) ParseAlignmentAndFormat(string format, int startIndex, int count)
        {
            if (startIndex != count)
            {
                var alignmentIndex = format[startIndex] == ',' ? 0 : -1;
                var formatIndex = format[startIndex] == ':' ? 0 : -1;

                if (formatIndex == -1)
                {
                    for (var i = alignmentIndex + 1; i < count; i++)
                    {
                        if (format[startIndex + i] == ':')
                        {
                            formatIndex = i;
                            break;
                        }
                    }
                }

                if (alignmentIndex == 0 && formatIndex > 0)
                {
                    return (int.Parse(format.AsSpan(startIndex + 1, count - formatIndex - 2), NumberStyles.Integer, CultureInfo.InvariantCulture), format.Substring(startIndex + formatIndex + 1, count - formatIndex - 1));
                }

                if (alignmentIndex == 0)
                {
                    return (int.Parse(format.AsSpan(startIndex + 1, count - 1), NumberStyles.Integer, CultureInfo.InvariantCulture), null);
                }

                if (formatIndex == 0)
                {
                    return (null, format.Substring(startIndex + 1, count - 1));
                }
            }

            return (null, null);
        }

        public string Format()
        {
            return _formatSegments[0];
        }

        public string Format<T0>(T0 arg0)
        {
            var builder = new DefaultInterpolatedStringHandler(2, 1, CultureInfo.InvariantCulture);
            builder.AppendLiteral(_formatSegments[0]);
            FormatArgument(ref builder, arg0, _valueAlignments[0], _valueFormats[0]);
            builder.AppendLiteral(_formatSegments[1]);
            return builder.ToString();
        }

        public string Format<T0, T1, T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            var builder = new DefaultInterpolatedStringHandler(4, 3, CultureInfo.InvariantCulture);
            builder.AppendLiteral(_formatSegments[0]);
            FormatArgument(ref builder, arg0, _valueAlignments[0], _valueFormats[0]);
            builder.AppendLiteral(_formatSegments[1]);
            FormatArgument(ref builder, arg1, _valueAlignments[1], _valueFormats[1]);
            builder.AppendLiteral(_formatSegments[2]);
            FormatArgument(ref builder, arg2, _valueAlignments[2], _valueFormats[2]);
            builder.AppendLiteral(_formatSegments[3]);
            return builder.ToString();
        }

        public string Format<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            var builder = new DefaultInterpolatedStringHandler(7, 6, CultureInfo.InvariantCulture);
            builder.AppendLiteral(_formatSegments[0]);
            FormatArgument(ref builder, arg0, _valueAlignments[0], _valueFormats[0]);
            builder.AppendLiteral(_formatSegments[1]);
            FormatArgument(ref builder, arg1, _valueAlignments[1], _valueFormats[1]);
            builder.AppendLiteral(_formatSegments[2]);
            FormatArgument(ref builder, arg2, _valueAlignments[2], _valueFormats[2]);
            builder.AppendLiteral(_formatSegments[3]);
            FormatArgument(ref builder, arg3, _valueAlignments[3], _valueFormats[3]);
            builder.AppendLiteral(_formatSegments[4]);
            FormatArgument(ref builder, arg4, _valueAlignments[4], _valueFormats[4]);
            builder.AppendLiteral(_formatSegments[5]);
            FormatArgument(ref builder, arg5, _valueAlignments[5], _valueFormats[5]);
            builder.AppendLiteral(_formatSegments[6]);
            return builder.ToString();
        }

        private static void FormatArgument<T>(ref DefaultInterpolatedStringHandler builder, T arg, int? alignment, string? format)
        {
            if (arg is null)
            {
                builder.AppendLiteral(NullValue);
            }
            else
            {
                if (alignment.HasValue && format is not null)
                {
                    builder.AppendFormatted<T>(arg, alignment.GetValueOrDefault(), format);
                }
                else if (alignment.HasValue)
                {
                    builder.AppendFormatted<T>(arg, alignment.GetValueOrDefault());
                }
                else if (format is not null)
                {
                    builder.AppendFormatted<T>(arg, format);
                }
                else
                {
                    builder.AppendFormatted<T>(arg);
                }
            }
        }

        public KeyValuePair<string, object?> GetValue(object?[] values, int index)
        {
            if (index < 0 || index > _valueNames.Length)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (_valueNames.Length > index)
            {
                return new KeyValuePair<string, object?>(_valueNames[index], values[index]);
            }

            return new KeyValuePair<string, object?>("{OriginalFormat}", OriginalFormat);
        }

        public IEnumerable<KeyValuePair<string, object?>> GetValues(object[] values)
        {
            var valueArray = new KeyValuePair<string, object?>[values.Length + 1];
            for (var index = 0; index != _valueNames.Length; ++index)
            {
                valueArray[index] = new KeyValuePair<string, object?>(_valueNames[index], values[index]);
            }

            valueArray[valueArray.Length - 1] = new KeyValuePair<string, object?>("{OriginalFormat}", OriginalFormat);
            return valueArray;
        }
    }
}
