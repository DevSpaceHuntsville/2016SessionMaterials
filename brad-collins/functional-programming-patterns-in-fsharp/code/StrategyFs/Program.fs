type Complex = { Re : float; Im : float }
with
    override x.ToString () =
        let sign = if sign x.Im < 0 then '-' else '+'
        sprintf "%0.1f %c i%0.1f" x.Re sign (abs x.Im)

let compareReImAsc x y =
    let re = sign (x.Re - y.Re)
    if re <> 0 then re else sign (x.Im - y.Im)

let compareImReAsc x y =
    let im = sign (x.Im - y.Im)
    if im <> 0 then im else sign (x.Re - y.Re)

[<EntryPoint>]
let main argv = 
    let xs = [ { Re =  4.0; Im =  9.0 }
               { Re = -3.0; Im =  1.0 }
               { Re =  1.0; Im = -6.0 }
               { Re = -3.0; Im = -2.0 }
               { Re =  7.0; Im =  1.0 } ]

    printfn "Ascending by Re, Im"
    xs 
    |> List.sortWith compareReImAsc
    |> List.iter (printfn "%O")
    printfn ""

    printfn "Ascending by Im, Re"
    xs 
    |> List.sortWith compareImReAsc
    |> List.iter (printfn "%O")

    0 // return an integer exit code
