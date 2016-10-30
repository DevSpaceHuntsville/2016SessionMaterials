[<EntryPoint>]
let main argv = 
    let startsWith prefix (str : string) =
        str.StartsWith prefix

    let words = [ "Lorem";      "ipsum"
                  "dolor";      "sit"
                  "amet";       "consectetur"
                  "adipiscing"; "elit" ]

    let startsWithL = startsWith "L"
    words
    |> List.filter startsWithL
//    |> List.filter (startsWith "L")
    |> List.iter (printfn "%s")

    let startsWithA = startsWith "a"
    words
    |> List.filter startsWithA
//    |> List.filter (startsWith "a")
    |> List.iter (printfn "%s")

    0 // return an integer exit code
