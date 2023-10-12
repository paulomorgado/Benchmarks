``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22458
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  Job-CPJMSR : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Runtime=.NET 6.0  Toolchain=net60  

```

|                                                Method |       Mean |      Error |      StdDev |     Median | Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------------------------------------ |-----------:|-----------:|------------:|-----------:|------:|--------:|-------:|----------:|
|                         LoggerMessageDefine0Arguments |  28.140 ns |  0.8800 ns |    2.553 ns |          - |  1.00 |    0.00 |      - |         - |
|                       LoggerMessageDefineEx0Arguments |  18.510 ns |  0.4190 ns |    0.979 ns |          - |  0.64 |    0.05 |      - |         - |
|                                                       |            |            |             |            |       |         |        |           |
|                LoggerMessageDefine0ArgumentsGenerated |  17.626 ns |  0.3501 ns |   0.8588 ns |          - |  1.00 |       - |      - |         - |
|              LoggerMessageDefineEx0ArgumentsGenerated |   2.271 ns |  0.0903 ns |   0.1885 ns |          - |  0.13 |       - |      - |         - |
|                                                       |            |            |             |            |       |         |        |           |
|            LoggerMessageDefine3ReferenceTypeArguments | 258.500 ns |   5.240 ns |  13.0500 ns |          - |  1.00 |    0.00 | 0.0420 |     176 B |
|          LoggerMessageDefineEx3ReferenceTypeArguments | 264.800 ns |  13.930 ns |  41.0600 ns |          - |  1.05 |    0.17 | 0.1702 |     712 B |
|                                                       |            |            |             |            |       |         |        |           |
|   LoggerMessageDefine3ReferenceTypeArgumentsGenerated | 314.100 ns | 22.4300 ns |  65.0900 ns | 300.400 ns |  1.00 |    0.00 | 0.0420 |     176 B |
| LoggerMessageDefineEx3ReferenceTypeArgumentsGenerated | 366.100 ns | 16.3600 ns |  48.2300 ns | 384.600 ns |  1.23 |    0.30 | 0.1740 |     728 B |
|                                                       |            |            |             |            |       |         |        |           |
|                LoggerMessageDefine3ValueTypeArguments | 465.800 ns | 38.7100 ns | 108.5600 ns | 434.300 ns |  1.00 |    0.00 | 0.0381 |     160 B |
|              LoggerMessageDefineEx3ValueTypeArguments | 358.000 ns |  7.1800 ns |  21.1800 ns | 356.500 ns |  0.80 |    0.16 | 0.1545 |     648 B |
|                                                       |            |            |             |            |       |         |        |           |
|       LoggerMessageDefine3ValueTypeArgumentsGenerated | 602.700 ns | 20.4500 ns |  60.2900 ns | 579.100 ns |  1.00 |    0.00 | 0.0381 |     160 B |
|     LoggerMessageDefineEx3ValueTypeArgumentsGenerated | 256.800 ns |  5.7000 ns |  15.7900 ns | 254.400 ns |  0.43 |    0.05 | 0.1545 |     648 B |
|                                                       |            |            |             |            |       |         |        |           |
|            LoggerMessageDefine6ReferenceTypeArguments | 788.400 ns | 51.7100 ns | 148.3700 ns |          - |  1.00 |    0.00 | 0.1011 |     424 B |
|          LoggerMessageDefineEx6ReferenceTypeArguments | 453.000 ns |  8.9100 ns |  13.6100 ns |          - |  0.52 |    0.08 | 0.2122 |     888 B |
|                                                       |            |            |             |            |       |         |        |           |
|   LoggerMessageDefine6ReferenceTypeArgumentsGenerated | 647.500 ns | 12.7100 ns |  23.8700 ns |          - |  1.00 |    0.00 | 0.1011 |     424 B |
| LoggerMessageDefineEx6ReferenceTypeArgumentsGenerated | 406.900 ns |  8.0500 ns |  17.3300 ns |          - |  0.63 |    0.04 | 0.2122 |     888 B |
|                                                       |            |            |             |            |       |         |        |           |
|                LoggerMessageDefine6ValueTypeArguments | 844.400 ns | 15.5900 ns |  27.3100 ns |          - |  1.00 |    0.00 | 0.0877 |     368 B |
|              LoggerMessageDefineEx6ValueTypeArguments | 384.400 ns |  7.7400 ns |  15.2800 ns |          - |  0.46 |    0.02 | 0.1760 |     736 B |
|                                                       |            |            |             |            |       |         |        |           |
|       LoggerMessageDefine6ValueTypeArgumentsGenerated | 833.800 ns | 26.6400 ns |  78.5600 ns |          - |  1.00 |    0.00 | 0.0877 |     368 B |
|     LoggerMessageDefineEx6ValueTypeArgumentsGenerated | 339.600 ns | 11.6700 ns |  34.2300 ns |          - |  0.41 |    0.06 | 0.1760 |     736 B |
