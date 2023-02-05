using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using BenchmarkDotNet.Attributes;

namespace Wpf
{
[MemoryDiagnoser]
public class ModifierKeysConverterBenchmarks
{
    private const char Modifier_Delimiter = '+';

    [Params("Control", "Control+Shift", "Control+Shift+Alt", "Control+Shift+Alt+Windows", " Control + Shift + Alt + Windows ")]
    public string Text;

    [Benchmark(Baseline = true)]
    public ModifierKeys GetModifierKeys() => GetModifierKeys(this.Text, CultureInfo.CurrentCulture);

    private ModifierKeys GetModifierKeys(string modifiersToken, CultureInfo culture)
    {
        ModifierKeys modifiers = ModifierKeys.None;
        if (modifiersToken.Length != 0)
        {
            int offset = 0;
            do
            {
                offset = modifiersToken.IndexOf(Modifier_Delimiter);
                string token = (offset < 0) ? modifiersToken : modifiersToken.Substring(0, offset);
                token = token.Trim();
                token = token.ToUpper(culture);

                if (token == String.Empty)
                    break;

                switch (token)
                {
                    case "CONTROL":
                    case "CTRL":
                        modifiers |= ModifierKeys.Control;
                        break;

                    case "SHIFT":
                        modifiers |= ModifierKeys.Shift;
                        break;

                    case "ALT":
                        modifiers |= ModifierKeys.Alt;
                        break;

                    case "WINDOWS":
                    case "WIN":
                        modifiers |= ModifierKeys.Windows;
                        break;

                    default:
                        throw new NotSupportedException();
                }

                modifiersToken = modifiersToken.Substring(offset + 1);
            } while (offset != -1);
        }
        return modifiers;
    }

    [Benchmark()]
    public ModifierKeys GetModifierKeysWithSpanSplit() => GetModifierKeysWithSpanSplit(this.Text);

    private ModifierKeys GetModifierKeysWithSpanSplit(string modifiersToken)
    {
        ModifierKeys modifiers = ModifierKeys.None;
        var modifiersTokenSpan = modifiersToken.AsSpan();
        if (modifiersTokenSpan.Length != 0)
        {
            var offset = 0;
            do
            {
                offset = modifiersTokenSpan.IndexOf(Modifier_Delimiter);
                var token = (offset < 0) ? modifiersTokenSpan : modifiersTokenSpan.Slice(0, offset);
                token = token.Trim();

                if (token.Length == 0)
                    break;

                if (token.Equals("CONTROL", StringComparison.OrdinalIgnoreCase)
                    || token.Equals("CTRL", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= ModifierKeys.Control;
                }
                else if (token.Equals("SHIFT", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= ModifierKeys.Shift;
                }
                else if (token.Equals("ALT", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= ModifierKeys.Alt;
                }
                else if (token.Equals("WINDOWS", StringComparison.OrdinalIgnoreCase)
                    || token.Equals("WIN", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= ModifierKeys.Windows;
                }
                else
                {
                    throw new NotSupportedException();
                }

                modifiersTokenSpan = modifiersTokenSpan.Slice(offset + 1);
            } while (offset != -1);
        }
        return modifiers;
    }
}
}
