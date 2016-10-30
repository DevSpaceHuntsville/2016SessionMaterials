type State =
| NoQuarter of int
| HasQuarter of int
| SoldOut

type Event = 
| InsertQuarter 
| EjectQuarter
| Dispense

let execute event state =
    match event, state with
    | InsertQuarter, NoQuarter n -> HasQuarter n
    | EjectQuarter, HasQuarter n -> NoQuarter n
    | Dispense, HasQuarter gumballs ->
        match gumballs with
        | 1 -> SoldOut
        | _ -> NoQuarter (gumballs - 1)
    | _ -> state

[<EntryPoint>]
let main argv = 
    let events = 
      [ InsertQuarter
        Dispense
        InsertQuarter
        EjectQuarter
        Dispense
        InsertQuarter
        Dispense
        InsertQuarter
        Dispense
        InsertQuarter
        Dispense ]
    let init = EjectQuarter, NoQuarter 3
    events
    |> Seq.scan (fun current event -> 
                    let _, state = current
                    event, execute event state)
                init
    |> Seq.skip 1
    |> Seq.iter (fun (evt, state) -> printfn "%A -> %A" evt state)

    
    0 // return an integer exit code
