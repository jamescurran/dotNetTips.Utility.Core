## .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
```assembly
; dotNetTips.Utility.Benchmarks.TypeHelperPerfTestRunner.DoesObjectEqualInstance()
       push      rdi
       push      rsi
       sub       rsp,38
       mov       rsi,rcx
       mov       dword ptr [rsp+20],0F
       mov       dword ptr [rsp+28],19
       mov       dword ptr [rsp+30],8
       mov       rcx,offset MD_dotNetTips.Utility.Standard.Tester.RandomData.GeneratePerson(Int32, Int32, Int32, Int32, Int32, Int32)
       mov       edx,19
       mov       r8d,0F
       mov       r9d,0F
       call      dotNetTips.Utility.Standard.Tester.RandomData.GeneratePerson[[System.__Canon, System.Private.CoreLib]](Int32, Int32, Int32, Int32, Int32, Int32)
       mov       rdi,rax
       mov       dword ptr [rsp+20],0F
       mov       dword ptr [rsp+28],19
       mov       dword ptr [rsp+30],8
       mov       rcx,offset MD_dotNetTips.Utility.Standard.Tester.RandomData.GeneratePerson(Int32, Int32, Int32, Int32, Int32, Int32)
       mov       edx,19
       mov       r8d,0F
       mov       r9d,0F
       call      dotNetTips.Utility.Standard.Tester.RandomData.GeneratePerson[[System.__Canon, System.Private.CoreLib]](Int32, Int32, Int32, Int32, Int32, Int32)
       cmp       rdi,rax
       sete      al
       movzx     eax,al
       mov       rdx,[rsi+8]
       mov       [rdx+44],al
       add       rsp,38
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 147
```
```assembly
; dotNetTips.Utility.Standard.Tester.RandomData.GeneratePerson[[System.__Canon, System.Private.CoreLib]](Int32, Int32, Int32, Int32, Int32, Int32)
; 			var person = new T
; 			^^
; 			{
; 			^^
; 				Id = RandomData.GenerateKey(),
; 			^^
; 				Address1 = RandomData.GenerateWord(addressLength),
; 			^^
; 				Address2 = RandomData.GenerateWord(addressLength),
; 			^^
; 				BornOn = DateTimeOffset.Now.Subtract(new TimeSpan(365 * GenerateInteger(1, 75), 0, 0, 0)),
; 			^^
; 				CellPhone = GeneratePhoneNumberUSA(),
; 			^^
; 				City = RandomData.GenerateWord(cityLength),
; 			^^
; 				Country = RandomData.GenerateWord(countryLength),
; 			^^
; 				Email = RandomData.GenerateEmailAddress(),
; 			^^
; 				FirstName = RandomData.GenerateWord(firstNameLength),
; 			^^
; 				HomePhone = GeneratePhoneNumberUSA(),
; 			^^
; 				LastName = RandomData.GenerateWord(lastNameLength),
; 			^^
; 				PostalCode = RandomData.GenerateNumber(postalCodeLength)
; 			^^
; 			};
; 			^^
; 			return person;
; 			^^^^^^^^^^^^^^
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,0A8
       vzeroupper
       xor       eax,eax
       mov       [rsp+90],rax
       mov       [rsp+98],rax
       mov       [rsp+0A0],rcx
       mov       esi,edx
       mov       edi,r8d
       mov       ebx,r9d
       mov       rdx,[rcx+10]
       mov       rax,[rdx+8]
       test      rax,rax
       jne       short M01_L00
       mov       rdx,7FF88A98DD88
       call      CORINFO_HELP_RUNTIMEHANDLE_METHOD
M01_L00:
       mov       rcx,rax
       call      System.Activator.CreateInstance[[System.__Canon, System.Private.CoreLib]]()
       mov       rbp,rax
       lea       rcx,[rsp+68]
       call      System.Guid.NewGuid()
       vmovdqu   xmm0,xmmword ptr [rsp+68]
       vmovdqu   xmmword ptr [rsp+48],xmm0
       lea       rcx,[rsp+48]
       call      dotNetTips.Utility.Standard.Extensions.GuidExtensions.ToDigits(System.Guid)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04A8
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04A8]
       mov       ecx,esi
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateWord(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04B0
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04B0]
       mov       ecx,esi
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateWord(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04B8
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04B8]
       lea       rax,[rsp+58]
       vxorps    xmm0,xmm0,xmm0
       vmovdqu   xmmword ptr [rax],xmm0
       call      System.DateTime.get_Now()
       mov       rdx,rax
       lea       rcx,[rsp+58]
       call      System.DateTimeOffset..ctor(System.DateTime)
       vmovdqu   xmm0,xmmword ptr [rsp+58]
       vmovdqu   xmmword ptr [rsp+90],xmm0
       xor       ecx,ecx
       mov       [rsp+88],rcx
       mov       ecx,1
       mov       edx,4B
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateInteger(Int32, Int32)
       imul      edx,eax,16D
       xor       ecx,ecx
       mov       [rsp+20],ecx
       mov       [rsp+28],ecx
       lea       rcx,[rsp+88]
       xor       r8d,r8d
       xor       r9d,r9d
       call      System.TimeSpan..ctor(Int32, Int32, Int32, Int32, Int32)
       lea       rcx,[rsp+90]
       lea       rdx,[rsp+78]
       mov       r8,[rsp+88]
       call      System.DateTimeOffset.Subtract(System.TimeSpan)
       vmovdqu   xmm0,xmmword ptr [rsp+78]
       vmovdqu   xmmword ptr [rsp+38],xmm0
       mov       rcx,rbp
       lea       rdx,[rsp+38]
       mov       r11,7FF88A5C04C0
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04C0]
       call      dotNetTips.Utility.Standard.Tester.RandomData.GeneratePhoneNumberUSA()
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04C8
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04C8]
       mov       ecx,edi
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateWord(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04D0
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04D0]
       mov       ecx,ebx
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateWord(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04D8
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04D8]
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateEmailAddress()
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04E0
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04E0]
       mov       ecx,[rsp+0F0]
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateWord(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04E8
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04E8]
       call      dotNetTips.Utility.Standard.Tester.RandomData.GeneratePhoneNumberUSA()
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04F0
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04F0]
       mov       ecx,[rsp+0F8]
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateWord(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C04F8
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D04F8]
       mov       ecx,[rsp+100]
       call      dotNetTips.Utility.Standard.Tester.RandomData.GenerateNumber(Int32)
       mov       rdx,rax
       mov       rcx,rbp
       mov       r11,7FF88A5C0500
       cmp       [rcx],ecx
       call      qword ptr [7FF88A9D0500]
       mov       rax,rbp
       add       rsp,0A8
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
; Total bytes of code 647
```

## .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
```assembly
; dotNetTips.Utility.Benchmarks.TypeHelperPerfTestRunner.FindDerivedTypes()
       push      rsi
       sub       rsp,20
       mov       rsi,rcx
       mov       rcx,offset MT_dotNetTips.Utility.Standard.Tester.Models.PersonProper
       call      CORINFO_HELP_TYPEHANDLE_TO_RUNTIMETYPE
       mov       rcx,rax
       mov       edx,1
       call      dotNetTips.Utility.Standard.TypeHelper.FindDerivedTypes(System.Type, Boolean)
       mov       rcx,[rsi+8]
       mov       edx,[rcx]
       add       rcx,10
       mov       rdx,rax
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       nop
       add       rsp,20
       pop       rsi
       ret
; Total bytes of code 61
```
```assembly
; dotNetTips.Utility.Standard.TypeHelper.FindDerivedTypes(System.Type, Boolean)
       push      rdi
       push      rsi
       sub       rsp,28
       mov       rsi,rcx
       mov       edi,edx
       call      System.Reflection.Assembly.GetEntryAssembly()
       mov       rcx,rax
       mov       rax,[rax]
       mov       rax,[rax+48]
       call      qword ptr [rax+30]
       mov       rcx,rax
       call      System.IO.Path.GetDirectoryName(System.String)
       mov       rcx,rax
       movzx     r9d,dil
       mov       r8,rsi
       xor       edx,edx
       mov       rax,offset dotNetTips.Utility.Standard.TypeHelper.FindDerivedTypes(System.String, System.IO.SearchOption, System.Type, Boolean)
       add       rsp,28
       pop       rsi
       pop       rdi
       jmp       rax
; Total bytes of code 68
```

## .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
```assembly
; dotNetTips.Utility.Benchmarks.TypeHelperPerfTestRunner.GetDefault()
       mov       rax,[rcx+8]
       mov       edx,[rax]
       add       rax,10
       xor       edx,edx
       mov       [rax],rdx
       ret
; Total bytes of code 16
```

## .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
```assembly
; dotNetTips.Utility.Benchmarks.TypeHelperPerfTestRunner.GetInstanceHashCode()
       push      rsi
       sub       rsp,20
       mov       rsi,rcx
       mov       rcx,[rsi+28]
       call      dotNetTips.Utility.Standard.TypeHelper.GetInstanceHashCode(System.Object)
       mov       rdx,[rsi+8]
       mov       [rdx+30],eax
       add       rsp,20
       pop       rsi
       ret
; Total bytes of code 30
```
```assembly
; dotNetTips.Utility.Standard.TypeHelper.GetInstanceHashCode(System.Object)
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,28
       mov       rsi,rcx
       mov       rcx,offset MT_dotNetTips.Utility.Standard.TypeHelper+<>c__DisplayClass11_0
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       lea       rcx,[rdi+8]
       mov       rdx,rsi
       call      CORINFO_HELP_ASSIGN_REF
       cmp       qword ptr [rdi+8],0
       setne     dl
       movzx     edx,dl
       mov       r9,285F5373060
       mov       r9,[r9]
       mov       r8,285E5371050
       mov       r8,[r8]
       mov       rcx,offset MD_dotNetTips.Utility.Standard.OOP.Encapsulation.TryValidateParam(Boolean, System.String, System.String)
       call      dotNetTips.Utility.Standard.OOP.Encapsulation.TryValidateParam[[System.__Canon, System.Private.CoreLib]](Boolean, System.String, System.String)
       mov       rcx,[rdi+8]
       call      00007FF8EA182020
       mov       rcx,rax
       call      System.Reflection.RuntimeReflectionExtensions.GetRuntimeProperties(System.Type)
       mov       rsi,rax
       mov       rcx,285F537BB60
       mov       rbx,[rcx]
       test      rbx,rbx
       jne       short M01_L00
       mov       rcx,offset MT_System.Func`2[[System.Reflection.PropertyInfo, System.Private.CoreLib],[System.Boolean, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rbx,rax
       mov       rdx,285F537BB58
       mov       rdx,[rdx]
       test      rdx,rdx
       je        near ptr M01_L03
       lea       rcx,[rbx+8]
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,offset dotNetTips.Utility.Standard.TypeHelper+<>c.<GetInstanceHashCode>b__11_0(System.Reflection.PropertyInfo)
       mov       [rbx+18],rdx
       mov       rcx,285F537BB60
       mov       rdx,rbx
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
M01_L00:
       mov       rcx,offset MT_System.Func`2[[System.Reflection.PropertyInfo, System.Private.CoreLib],[System.Object, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rbp,rax
       mov       r8,rbx
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Where(System.Collections.Generic.IEnumerable`1<!!0>, System.Func`2<!!0,Boolean>)
       call      System.Linq.Enumerable.Where[[System.__Canon, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, System.Func`2<System.__Canon,Boolean>)
       mov       rsi,rax
       lea       rcx,[rbp+8]
       mov       rdx,rdi
       call      CORINFO_HELP_ASSIGN_REF
       mov       r8,offset dotNetTips.Utility.Standard.TypeHelper+<>c__DisplayClass11_0.<GetInstanceHashCode>b__1(System.Reflection.PropertyInfo)
       mov       [rbp+18],r8
       mov       r8,rbp
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Select(System.Collections.Generic.IEnumerable`1<!!0>, System.Func`2<!!0,!!1>)
       call      System.Linq.Enumerable.Select[[System.__Canon, System.Private.CoreLib],[System.__Canon, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, System.Func`2<System.__Canon,System.__Canon>)
       mov       rsi,rax
       mov       rcx,285F537BB68
       mov       r8,[rcx]
       test      r8,r8
       jne       short M01_L01
       mov       rcx,offset MT_System.Func`2[[System.Object, System.Private.CoreLib],[System.Boolean, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rdi,rax
       mov       rdx,285F537BB58
       mov       rdx,[rdx]
       test      rdx,rdx
       je        near ptr M01_L04
       lea       rcx,[rdi+8]
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,offset dotNetTips.Utility.Standard.TypeHelper+<>c.<GetInstanceHashCode>b__11_2(System.Object)
       mov       [rdi+18],rdx
       mov       rcx,285F537BB68
       mov       rdx,rdi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       r8,rdi
M01_L01:
       mov       rdx,rsi
       mov       rcx,offset MD_System.Linq.Enumerable.Where(System.Collections.Generic.IEnumerable`1<!!0>, System.Func`2<!!0,Boolean>)
       call      System.Linq.Enumerable.Where[[System.__Canon, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, System.Func`2<System.__Canon,Boolean>)
       mov       rdi,rax
       mov       rcx,285F537BB70
       mov       r9,[rcx]
       test      r9,r9
       jne       short M01_L02
       mov       rcx,offset MT_System.Func`3[[System.Int32, System.Private.CoreLib],[System.Object, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]]
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       rdx,285F537BB58
       mov       rdx,[rdx]
       test      rdx,rdx
       je        short M01_L05
       lea       rcx,[rsi+8]
       call      CORINFO_HELP_ASSIGN_REF
       mov       rdx,offset dotNetTips.Utility.Standard.TypeHelper+<>c.<GetInstanceHashCode>b__11_3(Int32, System.Object)
       mov       [rsi+18],rdx
       mov       rcx,285F537BB70
       mov       rdx,rsi
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       mov       r9,rsi
M01_L02:
       mov       rdx,rdi
       mov       r8d,0FFFFFFFF
       mov       rcx,offset MD_System.Linq.Enumerable.Aggregate(System.Collections.Generic.IEnumerable`1<!!0>, !!1, System.Func`3<!!1,!!0,!!1>)
       call      System.Linq.Enumerable.Aggregate[[System.__Canon, System.Private.CoreLib],[System.Int32, System.Private.CoreLib]](System.Collections.Generic.IEnumerable`1<System.__Canon>, Int32, System.Func`3<Int32,System.__Canon,Int32>)
       nop
       add       rsp,28
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       ret
M01_L03:
       mov       rcx,rbx
       call      System.MulticastDelegate.ThrowNullThisInDelegateToInstance()
       int       3
M01_L04:
       mov       rcx,rdi
       call      System.MulticastDelegate.ThrowNullThisInDelegateToInstance()
       int       3
M01_L05:
       mov       rcx,rsi
       call      System.MulticastDelegate.ThrowNullThisInDelegateToInstance()
       int       3
; Total bytes of code 586
```

## .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
```assembly
; dotNetTips.Utility.Benchmarks.TypeHelperPerfTestRunner.GetTypeDisplayNameTypeTest()
       push      rsi
       sub       rsp,30
       mov       rsi,rcx
       mov       rcx,offset MT_dotNetTips.Utility.Standard.Tester.Models.PersonProper
       call      CORINFO_HELP_TYPEHANDLE_TO_RUNTIMETYPE
       mov       rcx,rax
       mov       dword ptr [rsp+20],7C
       mov       edx,1
       mov       r8d,1
       mov       r9d,1
       call      dotNetTips.Utility.Standard.TypeHelper.GetTypeDisplayName(System.Type, Boolean, Boolean, Boolean, Char)
       mov       rcx,[rsi+8]
       mov       edx,[rcx]
       add       rcx,8
       mov       rdx,rax
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       nop
       add       rsp,30
       pop       rsi
       ret
; Total bytes of code 81
```
```assembly
; dotNetTips.Utility.Standard.TypeHelper.GetTypeDisplayName(System.Type, Boolean, Boolean, Boolean, Char)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,30
       xor       eax,eax
       mov       [rsp+28],rax
       mov       rsi,rcx
       mov       edi,edx
       mov       ebx,r8d
       mov       ebp,r9d
       test      rsi,rsi
       je        near ptr M01_L00
       mov       rcx,offset MT_System.Text.StringBuilder
       call      CORINFO_HELP_NEWSFAST
       mov       r14,rax
       mov       dword ptr [r14+20],7FFFFFFF
       mov       rcx,offset MT_System.Char[]
       mov       edx,10
       call      CORINFO_HELP_NEWARR_1_VC
       lea       rcx,[r14+8]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       movzx     r8d,dil
       movzx     ecx,bpl
       movzx     edx,bl
       mov       edi,[rsp+80]
       movzx     eax,di
       lea       r9,[rsp+28]
       mov       [r9],r8b
       mov       [r9+1],dl
       mov       [r9+2],cl
       mov       [r9+4],ax
       lea       r8,[rsp+28]
       mov       rcx,r14
       mov       rdx,rsi
       call      dotNetTips.Utility.Standard.TypeHelper.ProcessType(System.Text.StringBuilder, System.Type, DisplayNameOptions ByRef)
       mov       rcx,r14
       call      qword ptr [7FF88A9A7010]
       nop
       add       rsp,30
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M01_L00:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,261
       mov       rdx,7FF88A95F288
       call      CORINFO_HELP_STRCNS
       mov       rdi,rax
       mov       ecx,26B
       mov       rdx,7FF88A95F288
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rdi
       mov       rcx,rsi
       call      System.ArgumentNullException..ctor(System.String, System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 258
```

## .NET Core 3.1.14 (CoreCLR 4.700.21.16201, CoreFX 4.700.21.16208), X64 RyuJIT
```assembly
; dotNetTips.Utility.Benchmarks.TypeHelperPerfTestRunner.GetTypeDisplayNameVariableTest()
       push      rsi
       sub       rsp,30
       mov       rsi,rcx
       mov       rcx,[rsi+28]
       test      rcx,rcx
       je        short M00_L00
       call      00007FF8EA182020
       mov       rcx,rax
       mov       dword ptr [rsp+20],2B
       mov       edx,1
       xor       r8d,r8d
       mov       r9d,1
       call      dotNetTips.Utility.Standard.TypeHelper.GetTypeDisplayName(System.Type, Boolean, Boolean, Boolean, Char)
       jmp       short M00_L01
M00_L00:
       xor       eax,eax
M00_L01:
       mov       rcx,[rsi+8]
       mov       edx,[rcx]
       add       rcx,8
       mov       rdx,rax
       call      CORINFO_HELP_CHECKED_ASSIGN_REF
       nop
       add       rsp,30
       pop       rsi
       ret
; Total bytes of code 81
```
```assembly
; dotNetTips.Utility.Standard.TypeHelper.GetTypeDisplayName(System.Type, Boolean, Boolean, Boolean, Char)
       push      r14
       push      rdi
       push      rsi
       push      rbp
       push      rbx
       sub       rsp,30
       xor       eax,eax
       mov       [rsp+28],rax
       mov       rsi,rcx
       mov       edi,edx
       mov       ebx,r8d
       mov       ebp,r9d
       test      rsi,rsi
       je        near ptr M01_L00
       mov       rcx,offset MT_System.Text.StringBuilder
       call      CORINFO_HELP_NEWSFAST
       mov       r14,rax
       mov       dword ptr [r14+20],7FFFFFFF
       mov       rcx,offset MT_System.Char[]
       mov       edx,10
       call      CORINFO_HELP_NEWARR_1_VC
       lea       rcx,[r14+8]
       mov       rdx,rax
       call      CORINFO_HELP_ASSIGN_REF
       movzx     r8d,dil
       movzx     ecx,bpl
       movzx     edx,bl
       mov       edi,[rsp+80]
       movzx     eax,di
       lea       r9,[rsp+28]
       mov       [r9],r8b
       mov       [r9+1],dl
       mov       [r9+2],cl
       mov       [r9+4],ax
       lea       r8,[rsp+28]
       mov       rcx,r14
       mov       rdx,rsi
       call      dotNetTips.Utility.Standard.TypeHelper.ProcessType(System.Text.StringBuilder, System.Type, DisplayNameOptions ByRef)
       mov       rcx,r14
       call      qword ptr [7FF88A997010]
       nop
       add       rsp,30
       pop       rbx
       pop       rbp
       pop       rsi
       pop       rdi
       pop       r14
       ret
M01_L00:
       mov       rcx,offset MT_System.ArgumentNullException
       call      CORINFO_HELP_NEWSFAST
       mov       rsi,rax
       mov       ecx,261
       mov       rdx,7FF88A94F288
       call      CORINFO_HELP_STRCNS
       mov       rdi,rax
       mov       ecx,26B
       mov       rdx,7FF88A94F288
       call      CORINFO_HELP_STRCNS
       mov       r8,rax
       mov       rdx,rdi
       mov       rcx,rsi
       call      System.ArgumentNullException..ctor(System.String, System.String)
       mov       rcx,rsi
       call      CORINFO_HELP_THROW
       int       3
; Total bytes of code 258
```

