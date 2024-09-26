module merge

let merge ls1 ls2 = List.sort (ls1 @ ls2)
// with fold2???

let ex1 = merge [1;2;4] [3;5;7]