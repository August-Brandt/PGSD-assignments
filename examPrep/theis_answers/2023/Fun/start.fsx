open Parse;;
let ex11 = fromString @"let l1 = [2, 3] in
let l2 = [1, 4] in
l1 @ l2 = [2, 3, 1, 4]
end
end";;

ex11;;
printfn "%A" it;;