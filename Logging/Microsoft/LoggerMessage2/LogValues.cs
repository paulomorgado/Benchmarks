using System.Collections;

namespace Microsoft.Extensions.Logging
{
    public readonly struct LogValues : IReadOnlyList<KeyValuePair<string, object?>>
    {
        public static readonly Func<LogValues, Exception?, string> Callback = (state, exception) => state.ToString();

        private readonly LogValuesFormatter _formatter;

        public LogValues(LogValuesFormatter formatter)
        {
            _formatter = formatter;
        }

        public KeyValuePair<string, object?> this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return new KeyValuePair<string, object?>("{OriginalFormat}", _formatter.OriginalFormat);
                }
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        public int Count => 1;

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
        {
            yield return this[0];
        }

        public override string ToString() => _formatter.Format();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
