# Benchmarks

## Delegate vs Interface

```
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.134 (1809/October2018Update/Redstone5)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3190.0
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


    Method |  Job | Runtime |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |
---------- |----- |-------- |---------:|----------:|----------:|---------:|------:|--------:|
    Direct |  Clr |     Clr | 4.727 ns | 0.1549 ns | 0.1293 ns | 4.722 ns |  1.00 |    0.00 |
  Delegate |  Clr |     Clr | 5.619 ns | 0.4763 ns | 1.3667 ns | 5.059 ns |  1.42 |    0.24 |
 Interface |  Clr |     Clr | 4.509 ns | 0.1426 ns | 0.1264 ns | 4.467 ns |  0.95 |    0.04 |
           |      |         |          |           |           |          |       |         |
    Direct | Core |    Core | 4.298 ns | 0.1703 ns | 0.2091 ns | 4.278 ns |  1.00 |    0.00 |
  Delegate | Core |    Core | 4.364 ns | 0.1193 ns | 0.1116 ns | 4.368 ns |  1.00 |    0.05 |
 Interface | Core |    Core | 4.530 ns | 0.1516 ns | 0.1418 ns | 4.499 ns |  1.03 |    0.05 |
```

## Equals: OrdinalIgnoreCase vs InvariantCultureIgnoreCase vs ToUpper

```
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.194 (1809/October2018Update/Redstone5)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3260.0
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


                           Method |  Job | Runtime |      Mean |      Error |    StdDev |    Median | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
--------------------------------- |----- |-------- |----------:|-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
          EqualsOrdinalIgnoreCase |  Clr |     Clr |  15.76 ns |  0.4849 ns |  1.407 ns |  15.66 ns |           - |           - |           - |                   - |
 EqualsInvariantCultureIgnoreCase |  Clr |     Clr | 106.85 ns |  2.9591 ns |  8.150 ns | 108.23 ns |           - |           - |           - |                   - |
                    EqualsToUpper |  Clr |     Clr | 276.29 ns | 16.7876 ns | 46.518 ns | 258.82 ns |      0.0186 |           - |           - |                80 B |
          EqualsOrdinalIgnoreCase | Core |    Core |  25.55 ns |  0.6241 ns |  1.750 ns |  25.41 ns |           - |           - |           - |                   - |
 EqualsInvariantCultureIgnoreCase | Core |    Core | 105.41 ns |  2.1510 ns |  2.944 ns | 104.53 ns |           - |           - |           - |                   - |
                    EqualsToUpper | Core |    Core | 104.47 ns |  2.1157 ns |  5.499 ns | 103.42 ns |      0.0190 |           - |           - |                80 B |
```

## Concatenation methods: string.Concat vs string.Format vs concatenation vs interpolation (10, 100 and 1000 times)

```
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.471 (1803/April2018Update/Redstone4)
Intel Core i7-7600U CPU 2.80GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.101
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT  [AttachedDebugger]
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3260.0
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


             Method |  Job | Runtime | Size |         Mean |       Error |       StdDev |       Median | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
------------------- |----- |-------- |----- |-------------:|------------:|-------------:|-------------:|------------:|------------:|------------:|--------------------:|
  UsingStringFormat |  Clr |     Clr |   10 |   1,815.1 ns |   136.45 ns |    400.18 ns |   1,682.2 ns |      0.3700 |           - |           - |               784 B |
  UsingStringConcat |  Clr |     Clr |   10 |   1,561.9 ns |   125.57 ns |    370.25 ns |   1,481.3 ns |      0.4234 |           - |           - |               896 B |
 UsingConcatenation |  Clr |     Clr |   10 |   1,044.6 ns |    37.47 ns |    108.72 ns |   1,020.8 ns |      0.4253 |           - |           - |               896 B |
 UsingInterpolation |  Clr |     Clr |   10 |   1,152.9 ns |    22.82 ns |     56.82 ns |   1,142.5 ns |      0.3719 |           - |           - |               784 B |
  UsingStringFormat | Core |    Core |   10 |     749.8 ns |    36.66 ns |    103.41 ns |     724.5 ns |      0.2050 |           - |           - |               432 B |
  UsingStringConcat | Core |    Core |   10 |     782.6 ns |    51.24 ns |    151.07 ns |     750.0 ns |      0.4263 |           - |           - |               896 B |
 UsingConcatenation | Core |    Core |   10 |     601.2 ns |    15.12 ns |     42.88 ns |     591.4 ns |      0.4263 |           - |           - |               896 B |
 UsingInterpolation | Core |    Core |   10 |     836.8 ns |    29.60 ns |     85.39 ns |     820.9 ns |      0.2050 |           - |           - |               432 B |
  UsingStringFormat |  Clr |     Clr |  100 |   9,801.1 ns |   229.51 ns |    658.51 ns |   9,619.0 ns |      4.4708 |           - |           - |              9384 B |
  UsingStringConcat |  Clr |     Clr |  100 |   7,959.5 ns |   171.79 ns |    492.91 ns |   7,770.0 ns |      3.6850 |           - |           - |              7736 B |
 UsingConcatenation |  Clr |     Clr |  100 |   7,260.1 ns |   143.26 ns |    175.93 ns |   7,265.0 ns |      3.6774 |           - |           - |              7736 B |
 UsingInterpolation |  Clr |     Clr |  100 |   9,098.9 ns |   181.58 ns |    282.70 ns |   9,098.8 ns |      4.4708 |           - |           - |              9384 B |
  UsingStringFormat | Core |    Core |  100 |   5,379.9 ns |   116.20 ns |    215.39 ns |   5,360.4 ns |      2.9297 |           - |           - |              6152 B |
  UsingStringConcat | Core |    Core |  100 |   4,221.7 ns |    83.73 ns |    148.82 ns |   4,235.4 ns |      3.6850 |           - |           - |              7736 B |
 UsingConcatenation | Core |    Core |  100 |   4,335.8 ns |    83.80 ns |    105.98 ns |   4,319.9 ns |      3.6850 |           - |           - |              7736 B |
 UsingInterpolation | Core |    Core |  100 |   5,443.0 ns |   105.14 ns |    132.97 ns |   5,417.0 ns |      2.9297 |           - |           - |              6152 B |
  UsingStringFormat |  Clr |     Clr | 1000 | 100,461.2 ns | 2,124.19 ns |  3,430.16 ns |  99,707.0 ns |     45.4102 |           - |           - |             95794 B |
  UsingStringConcat |  Clr |     Clr | 1000 |  85,211.2 ns | 3,643.09 ns | 10,334.85 ns |  80,552.2 ns |     36.9873 |           - |           - |             77947 B |
 UsingConcatenation |  Clr |     Clr | 1000 |  78,872.1 ns | 1,908.54 ns |  2,197.88 ns |  78,475.6 ns |     36.9873 |           - |           - |             77947 B |
 UsingInterpolation |  Clr |     Clr | 1000 | 101,636.3 ns | 2,193.12 ns |  4,813.95 ns | 100,306.7 ns |     45.4102 |           - |           - |             95794 B |
  UsingStringFormat | Core |    Core | 1000 |  60,603.9 ns | 1,394.41 ns |  3,932.97 ns |  59,450.2 ns |     30.2734 |           - |           - |             63752 B |
  UsingStringConcat | Core |    Core | 1000 |  47,857.8 ns |   950.73 ns |    889.31 ns |  48,027.8 ns |     36.9873 |           - |           - |             77944 B |
 UsingConcatenation | Core |    Core | 1000 |  48,499.3 ns |   827.47 ns |    690.98 ns |  48,587.6 ns |     36.9873 |           - |           - |             77944 B |
 UsingInterpolation | Core |    Core | 1000 |  57,846.2 ns | 1,136.62 ns |  1,437.46 ns |  57,656.3 ns |     30.2734 |           - |           - |             63752 B |
```