{noformat}

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Unknown processor
.NET Core SDK=5.0.300-preview.21180.15
  [Host]     : .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
  Job-SOGKAI : .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT

EvaluateOverhead=True  Server=True  Toolchain=.NET Core 3.1  
Namespace=dotNetTips.Utility.Benchmarks.Security  Categories=SecurityHelper,String,Security  

{noformat}
||                  Method ||        Mean ||      Error ||     StdDev ||   StdErr ||         Min ||          Q1 ||      Median ||          Q3 ||         Max ||       Op/s ||CI99.9% Margin ||Iterations ||Kurtosis ||MValue ||Skewness || Ratio ||RatioSD ||  Welch(10%)/p-values ||Rank ||                                                           LogicalGroup ||Baseline ||Code Size || Gen 0 ||Gen 1 ||Gen 2 ||Allocated ||
|     *CompareSecureStrings* | *146,320.9 ns* | *1,497.68 ns* | *1,250.63 ns* | *346.86 ns* | *142,975.7 ns* | *146,432.4 ns* | *146,539.2 ns* | *146,760.1 ns* | *148,144.1 ns* |     *6,834.3* |   *1,497.680 ns* |      *13.00* |    *4.431* |  *2.000* |  *-1.2334* | *250.96* |    *2.16* | *Slower: 0.0000|1.0000* |    *4* | *Job-SOGKAI(EvaluateOverhead=True, Server=True, Toolchain=.NET Core 3.1)* |       *No* |     *371 B* |      *-* |     *-* |     *-* |     *656 B* |
|         *LoadSecureString* |  *68,312.4 ns* | *1,006.67 ns* |   *941.64 ns* | *243.13 ns* |  *66,633.5 ns* |  *67,588.8 ns* |  *68,215.5 ns* |  *69,047.4 ns* |  *69,793.1 ns* |    *14,638.6* |   *1,006.669 ns* |      *15.00* |    *1.693* |  *2.000* |   *0.0314* | *117.50* |    *1.45* | *Slower: 0.0000|1.0000* |    *2* | *Job-SOGKAI(EvaluateOverhead=True, Server=True, Toolchain=.NET Core 3.1)* |       *No* |     *116 B* |      *-* |     *-* |     *-* |     *256 B* |
| *'Read String Characters'* |     *583.0 ns* |     *1.20 ns* |     *1.00 ns* |   *0.28 ns* |     *581.6 ns* |     *582.4 ns* |     *582.9 ns* |     *583.7 ns* |     *584.8 ns* | *1,715,154.8* |       *1.202 ns* |      *13.00* |    *1.719* |  *2.000* |   *0.2932* |   *1.00* |    *0.00* |             *Base: ?|?* |    *1* | *Job-SOGKAI(EvaluateOverhead=True, Server=True, Toolchain=.NET Core 3.1)* |      *Yes* |     *428 B* | *0.1726* |     *-* |     *-* |    *1632 B* |
|         *ReadSecureString* |  *72,713.6 ns* | *1,307.27 ns* | *1,091.63 ns* | *302.76 ns* |  *70,929.1 ns* |  *72,107.2 ns* |  *72,474.4 ns* |  *73,252.9 ns* |  *74,751.2 ns* |    *13,752.6* |   *1,307.269 ns* |      *13.00* |    *2.237* |  *2.000* |   *0.3587* | *124.72* |    *1.90* | *Slower: 0.0000|1.0000* |    *3* | *Job-SOGKAI(EvaluateOverhead=True, Server=True, Toolchain=.NET Core 3.1)* |       *No* |     *261 B* |      *-* |     *-* |     *-* |     *328 B* |
