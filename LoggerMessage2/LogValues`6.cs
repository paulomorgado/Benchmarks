using System.Collections;

namespace Microsoft.Extensions.Logging
{
    public readonly struct LogValues<T0, T1, T2, T3, T4, T5> : IReadOnlyList<KeyValuePair<string, object?>>
    {
        public static readonly Func<LogValues<T0, T1, T2, T3, T4, T5>, Exception?, string> Callback = (state, exception) => state.ToString();

        private readonly LogValuesFormatter _formatter;
        private readonly T0 _value0;
        private readonly T1 _value1;
        private readonly T2 _value2;
        private readonly T3 _value3;
        private readonly T4 _value4;
        private readonly T5 _value5;

        public int Count => 7;

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return new KeyValuePair<string, object?>(_formatter.ValueNames[0], _value0);
                    case 1:
                        return new KeyValuePair<string, object?>(_formatter.ValueNames[1], _value1);
                    case 2:
                        return new KeyValuePair<string, object?>(_formatter.ValueNames[2], _value2);
                    case 3:
                        return new KeyValuePair<string, object?>(_formatter.ValueNames[3], _value3);
                    case 4:
                        return new KeyValuePair<string, object?>(_formatter.ValueNames[4], _value4);
                    case 5:
                        return new KeyValuePair<string, object?>(_formatter.ValueNames[5], _value5);
                    case 6:
                        return new KeyValuePair<string, object?>("{OriginalFormat}", _formatter.OriginalFormat);
                    default:
                        throw new IndexOutOfRangeException(nameof(index));
                }
            }
        }

        public LogValues(LogValuesFormatter formatter, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            _formatter = formatter;
            _value0 = value0;
            _value1 = value1;
            _value2 = value2;
            _value3 = value3;
            _value4 = value4;
            _value5 = value5;
        }

        public override string ToString() => _formatter.Format(_value0, _value1, _value2, _value3, _value4, _value5);

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
