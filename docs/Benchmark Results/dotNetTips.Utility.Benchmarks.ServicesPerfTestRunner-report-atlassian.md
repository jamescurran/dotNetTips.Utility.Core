{noformat}

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Unknown processor
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
  Job-SOGKAI : .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT

EvaluateOverhead=True  Server=True  Toolchain=.NET Core 3.1  
Namespace=dotNetTips.Utility.Benchmarks  Categories=Services  

{noformat}
||       Method ||      Mean ||  Error || StdDev || StdErr ||       Min ||        Q1 ||    Median ||        Q3 ||       Max ||   Op/s ||CI99.9% Margin ||Iterations ||Kurtosis ||MValue ||Skewness ||Rank ||LogicalGroup ||Baseline ||Code Size || Gen 0 || Gen 1 ||Gen 2 ||Allocated ||
|   *AllServices* |   *981.9 μs* | *6.11 μs* | *5.10 μs* | *1.42 μs* |   *968.2 μs* |   *980.0 μs* |   *982.1 μs* |   *984.5 μs* |   *990.5 μs* | *1,018.4* |       *6.112 μs* |      *13.00* |    *4.663* |  *2.000* |  *-1.0583* |    *1* |            *** |       *No* |   *0.18 KB* | *9.7656* | *3.9063* |     *-* | *105.17 KB* |
| *ServiceExists* | *1,023.0 μs* | *2.30 μs* | *2.16 μs* | *0.56 μs* | *1,018.8 μs* | *1,021.9 μs* | *1,023.0 μs* | *1,024.0 μs* | *1,027.0 μs* |   *977.5* |       *2.304 μs* |      *15.00* |    *2.383* |  *2.000* |   *0.0503* |    *2* |            *** |       *No* |   *0.17 KB* | *9.7656* | *3.9063* |     *-* | *105.23 KB* |
| *ServiceStatus* | *1,012.0 μs* | *7.00 μs* | *5.46 μs* | *1.58 μs* | *1,003.3 μs* | *1,009.8 μs* | *1,010.8 μs* | *1,013.9 μs* | *1,025.0 μs* |   *988.2* |       *6.997 μs* |      *12.00* |    *3.416* |  *2.000* |   *0.7384* |    *2* |            *** |       *No* |   *0.14 KB* | *9.7656* | *3.9063* |     *-* | *105.24 KB* |
