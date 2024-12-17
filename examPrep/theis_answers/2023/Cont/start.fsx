open Icon;;
let numbers = FromTo(5,12)
//let p = Every(And(Write(Prim("<", FromTo(5,11), numbers)), Prim("<",CstI 11, FromTo(5,11)Write(CstS "test")));;
//let p = Every(And(Write(Prim("<", FromTo(5,11), numbers)), Every(If(FromTo(5,12),Write (CstS "test"),Write(CstS "test")))))
let chars = FromToChar('C','L');;
let p = (Every(Write(Prim("<", CstS "G", chars))))
run p;;
// run (Every(Write(chars)));;
printfn "%A" it;;