namespace AsyncPlayground

open Utilities

module BindAndReturn =

    let bindAndReturn(x,y) = async{
        let! myBind = async{return swap (x,y)}
        return myBind
        }

    let ignore x y = bindAndReturn(x,y) |> Async.Ignore

    let ignoreStart x y = bindAndReturn(x,y) |> Async.Ignore |> Async.Start

    let runSync x y = bindAndReturn(x,y) |> Async.RunSynchronously

    let startAsTaskAwait x y = bindAndReturn(x,y) |> Async.StartAsTask |> Async.AwaitTask
 
    let startAsTaskAwaitRunSync x y = bindAndReturn(x,y) |> Async.StartAsTask |> Async.AwaitTask |> Async.RunSynchronously

    let startChild x y = bindAndReturn(x,y) |> Async.StartChild 

    let startChildAsTask x y = bindAndReturn(x,y) |> Async.StartChildAsTask 

    let startChildAsTaskRun x y = bindAndReturn(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously

    let startChildAsTaskRunAwait x y = bindAndReturn(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously |> Async.AwaitTask

    let startChildRunRunSync x y = bindAndReturn(x,y) |> Async.StartChild |> Async.RunSynchronously |> Async.RunSynchronously

    let startChildRunSync x y = bindAndReturn(x,y) |> Async.StartChild |> Async.RunSynchronously