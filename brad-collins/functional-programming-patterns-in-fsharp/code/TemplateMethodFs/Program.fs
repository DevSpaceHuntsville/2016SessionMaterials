type Product = { Name : string; Category : string; Price : decimal }

let calculateTax calcFedTax calcStateTax calcLocalTax items =
    calcFedTax items + 
    calcStateTax items + 
    calcLocalTax items

let getPrice item = item.Price
let taxAt rate subtotal = rate * subtotal
let buildTaxCalculator exemptCategories rate =
    let isTaxable item = exemptCategories 
                         |> List.contains item.Category
                         |> not

    Seq.filter isTaxable
    >> Seq.map getPrice
    >> Seq.sum
    >> taxAt rate

let calculateTaxInAgnor = 
    let calcFedTax _ = 0.0m
    let calcStateTax = buildTaxCalculator [] 0.06m
    let calcLocalTax = buildTaxCalculator [] 0.03m

    calculateTax calcFedTax calcStateTax calcLocalTax

let calculateTaxInBristol = 
    let calcFedTax = buildTaxCalculator [] 0.20m
    let calcStateTax _ = 0.0m
    let calcLocalTax = buildTaxCalculator ["Food"; "Medical"] 0.015m

    calculateTax calcFedTax calcStateTax calcLocalTax

[<EntryPoint>]
let main argv = 
    let items = [
        { Name = "Fan"; Category = "Appliance"; Price = 19.99m }
        { Name = "Nexium"; Category = "Medical"; Price = 69.99m }
        { Name = "Chicken Thighs"; Category = "Food"; Price = 7.99m }
        { Name = "Corn Flakes"; Category = "Food"; Price = 4.99m }
        { Name = "Bed Sheets"; Category = "Linen"; Price = 129.99m }
        { Name = "Adjustable Wrench"; Category = "Hardware"; Price = 6.99m }
    ]
    
    let subtotal =
        items
        |> Seq.map getPrice
        |> Seq.sum

    let agnorTax = calculateTaxInAgnor items
    let bristolTax = calculateTaxInBristol items

    printfn "Tax on $%.2f of goods in Agnor: $%.2f" subtotal agnorTax
    printfn "Tax on $%.2f of goods in Bristol: $%.2f" subtotal bristolTax

    0 // return an integer exit code
