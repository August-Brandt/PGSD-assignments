open Icon;;
//let p = (Every(Prim("+",FromTo(1,10),(Every(Write(FromTo(1,10)))))));;
let p = (Every(Write(Prim("*",FromTo(1,10),FromTo(1,10)))));;
run p;;
printfn "%A" it;;