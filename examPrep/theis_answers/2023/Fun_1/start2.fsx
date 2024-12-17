open ParseAndRunHigher;;
run(fromString "let id x = x in [id] end ");;
printfn "%A" it;;