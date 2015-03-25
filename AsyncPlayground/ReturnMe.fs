namespace AsyncPlayground

open Utilities

module ReturnMe =

    (*swap
    .method public static class [mscorlib]System.Tuple`2<!!b, !!a> swap<a, b> (
            !!a x,
            !!b y
        ) cil managed 
    {
        IL_0000: nop
        IL_0001: ldarg.1
        IL_0002: ldarg.0
        IL_0003: newobj instance void class [mscorlib]System.Tuple`2<!!b, !!a>::.ctor(!0,  !1)
        IL_0008: ret
    }
    *)
    (*
    .method public static class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync`1<class [mscorlib]System.Tuple`2<!!b, !!a>> returnMe<a, b> (
            !!a x,
            !!b y
        ) cil managed 
    {
        IL_0000: nop
        IL_0001: call class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsyncBuilder [FSharp.Core]Microsoft.FSharp.Core.ExtraTopLevelOperators::get_DefaultAsyncBuilder()
        IL_0006: ldarg.0
        IL_0007: ldarg.1
        IL_0008: newobj instance void class AsyncPlayground.ReturnMe/returnMe@8<!!a, !!b>::.ctor(!0,  !1)
        IL_000d: tail.
        IL_000f: callvirt instance class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync`1<class [mscorlib]System.Tuple`2<!!1, !!0>> [FSharp.Core]Microsoft.FSharp.Control.FSharpAsyncBuilder::Delay<class [mscorlib]System.Tuple`2<!!b, !!a>>(class [FSharp.Core]Microsoft.FSharp.Core.FSharpFunc`2<class [FSharp.Core]Microsoft.FSharp.Core.Unit, class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync`1<class [mscorlib]System.Tuple`2<!!1, !!0>>>)
        IL_0014: ret
    }
    *)
    let returnMe(x,y) = async{
        return swap (x,y)
        }

    let ignore x y = returnMe(x,y) |> Async.Ignore

    let ignoreStart x y = returnMe(x,y) |> Async.Ignore |> Async.Start

    (*
    .method public static class [mscorlib]System.Tuple`2<!!b, !!a> runSync<a, b> (
            !!a x,
            !!b y
        ) cil managed 
    {
        .custom instance void [FSharp.Core]Microsoft.FSharp.Core.CompilationArgumentCountsAttribute::.ctor(int32[]) = (
            01 00 02 00 00 00 01 00 00 00 01 00 00 00 00 00
        )
        .locals init (
            [0] class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync`1<class [mscorlib]System.Tuple`2<!!b, !!a>> V_0
        )

        IL_0000: nop
        IL_0001: ldarg.0
        IL_0002: ldarg.1
        IL_0003: call class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync`1<class [mscorlib]System.Tuple`2<!!1, !!0>> 
            AsyncPlayground.ReturnMe::returnMe<!!a, !!b>(!!0,  !!1)
        IL_0008: stloc.0
        IL_0009: ldloc.0
        IL_000a: ldnull
        IL_000b: ldnull
        IL_000c: tail.
        IL_000e: call class [mscorlib]System.Tuple`2<!!1, !!0>
             [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync::RunSynchronously<class [mscorlib]System.Tuple`2<!!b, !!a>>(class [FSharp.Core]Microsoft.FSharp.Control.FSharpAsync`1<class [mscorlib]System.Tuple`2<!!1, !!0>>,  class [FSharp.Core]Microsoft.FSharp.Core.FSharpOption`1<int32>,  class [FSharp.Core]Microsoft.FSharp.Core.FSharpOption`1<valuetype [mscorlib]System.Threading.CancellationToken>)
        IL_0013: ret
    }
    *)
    let runSync x y = returnMe(x,y) |> Async.RunSynchronously

    let startAsTaskAwait x y = returnMe(x,y) |> Async.StartAsTask |> Async.AwaitTask

    let startAsTaskAwaitRunSync x y = returnMe(x,y) |> Async.StartAsTask |> Async.AwaitTask |> Async.RunSynchronously

    let startChild x y = returnMe(x,y) |> Async.StartChild 

    let startChildAsTask x y = returnMe(x,y) |> Async.StartChildAsTask 

    let startChildAsTaskRun x y = returnMe(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously

    let startChildAsTaskRunAwait x y = returnMe(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously |> Async.AwaitTask

    let startChildRunRunSync x y = returnMe(x,y) |> Async.StartChild |> Async.RunSynchronously |> Async.RunSynchronously

    let startChildRunSync x y = returnMe(x,y) |> Async.StartChild |> Async.RunSynchronously