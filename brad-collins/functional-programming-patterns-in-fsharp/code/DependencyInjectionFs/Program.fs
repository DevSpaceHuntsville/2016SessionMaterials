type Person = { FirstName : string; LastName : string }
with
    override x.ToString () = sprintf "%s %s" x.FirstName x.LastName

let repository log loadPerson id =
    let person = loadPerson id
    log (sprintf "Loaded Person: %O" person)
    person

let logger = printfn "%s"
let dataSvc id =
    [ { FirstName = "Selena"; LastName = "Scarlett" }
      { FirstName = "Marshall"; LastName = "Mustard" }
      { FirstName = "Goodwin"; LastName = "Green" }
      { FirstName = "Wanda"; LastName = "White" }
      { FirstName = "Patsy"; LastName = "Peacock" }
      { FirstName = "Percival"; LastName = "Plum" }
      { FirstName = "Bruno"; LastName = "Boddy" } ]
    |> List.tryItem id

[<EntryPoint>]
let main argv = 
    let getPerson = repository logger dataSvc
    let person = getPerson 5
    printfn "Fetched from repo: %O" person

    0 // return an integer exit code
