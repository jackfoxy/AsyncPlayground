namespace AsyncPlayground

open Utilities

module Bind2AndReturn =

    let bind2AndReturn1(x,y) = async{
        let! myBind1 = async{return swap (x,y)}
        let! myBind2 = async{return swap (x,y)}
        return myBind1,myBind2
        }

    let ignore x y = bind2AndReturn1(x,y) |> Async.Ignore

    let ignoreStart x y = bind2AndReturn1(x,y) |> Async.Ignore |> Async.Start

    let runSync x y = bind2AndReturn1(x,y) |> Async.RunSynchronously

    let startAsTaskAwait x y = bind2AndReturn1(x,y) |> Async.StartAsTask |> Async.AwaitTask

    let startAsTaskAwaitRunSync x y = bind2AndReturn1(x,y) |> Async.StartAsTask |> Async.AwaitTask |> Async.RunSynchronously

    let startChild x y = bind2AndReturn1(x,y) |> Async.StartChild 

    let startChildAsTask x y = bind2AndReturn1(x,y) |> Async.StartChildAsTask 

    let startChildAsTaskRun x y = bind2AndReturn1(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously

    let startChildAsTaskRunAwait x y = bind2AndReturn1(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously |> Async.AwaitTask

    let startChildRunRunSync x y = bind2AndReturn1(x,y) |> Async.StartChild |> Async.RunSynchronously |> Async.RunSynchronously

    let startChildRunSync x y = bind2AndReturn1(x,y) |> Async.StartChild |> Async.RunSynchronously 