
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Unknown processor
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
  Job-SOGKAI : .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT

EvaluateOverhead=True  Server=True  Toolchain=.NET Core 3.1  
Namespace=dotNetTips.Utility.Benchmarks.Logging  Categories=LoggingHelper  

                       Method |     Mean |   Error |  StdDev |  StdErr |      Min |       Q1 |   Median |       Q3 |      Max |        Op/s | CI99.9% Margin | Iterations | Kurtosis | MValue | Skewness | Rank | LogicalGroup | Baseline |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size |
----------------------------- |---------:|--------:|--------:|--------:|---------:|---------:|---------:|---------:|---------:|------------:|---------------:|-----------:|---------:|-------:|---------:|-----:|------------- |--------- |-------:|------:|------:|----------:|----------:|
 **RetrieveAllExceptionMessages** | **701.2 ns** | **6.87 ns** | **6.09 ns** | **1.63 ns** | **689.3 ns** | **696.6 ns** | **700.3 ns** | **706.9 ns** | **708.7 ns** | **1,426,226.7** |       **6.870 ns** |      **14.00** |    **1.734** |  **2.000** |  **-0.2346** |    **2** |            ***** |       **No** | **0.0877** |     **-** |     **-** |     **824 B** |     **412 B** |
        **RetrieveAllExceptions** | **321.9 ns** | **1.34 ns** | **1.25 ns** | **0.32 ns** | **318.5 ns** | **321.4 ns** | **321.9 ns** | **322.6 ns** | **323.6 ns** | **3,106,999.1** |       **1.340 ns** |      **15.00** |    **3.924** |  **2.000** |  **-0.8813** |    **1** |            ***** |       **No** | **0.0563** |     **-** |     **-** |     **528 B** |    **1830 B** |
