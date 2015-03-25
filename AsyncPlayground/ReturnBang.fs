namespace AsyncPlayground

open Utilities

module ReturnBang =

    let returnBang(x,y) = async{
        return! async{return swap (x,y)}
        }

    let ignore x y = returnBang(x,y) |> Async.Ignore

    let ignoreStart x y = returnBang(x,y) |> Async.Ignore |> Async.Start

    let runSync x y = returnBang(x,y) |> Async.RunSynchronously

    let startAsTaskAwait x y = returnBang(x,y) |> Async.StartAsTask |> Async.AwaitTask

    let startAsTaskAwaitRunSync x y = returnBang(x,y) |> Async.StartAsTask |> Async.AwaitTask |> Async.RunSynchronously

    let startChild x y = returnBang(x,y) |> Async.StartChild 

    let startChildAsTask x y = returnBang(x,y) |> Async.StartChildAsTask 

    let startChildAsTaskRun x y = returnBang(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously

    let startChildAsTaskRunAwait x y = returnBang(x,y) |> Async.StartChildAsTask |> Async.RunSynchronously |> Async.AwaitTask

    let startChildRunRunSync x y = returnBang(x,y) |> Async.StartChild |> Async.RunSynchronously |> Async.RunSynchronously  

    let startChildRunSync x y = returnBang(x,y) |> Async.StartChild |> Async.RunSynchronously