namespace AsyncPlayground

open ReturnMe

module console1 =
    [<EntryPoint>]
    let main argv = 
        printfn "%A" argv

        let x = returnMe(3,4) |> Async.RunSynchronously

        printfn "%A" x

        printfn "Hit any key to exit."
        System.Console.ReadKey() |> ignore
        0
