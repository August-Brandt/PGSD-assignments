(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;


(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(ope, e1, e2) ->
        let v1 = eval e1 env
        let v2 = eval e2 env
        match ope with
        | "+" -> v1 + v2
        | "-" -> v1 - v2
        | "*" -> v1 * v2
        | "max" -> if v1 > v2 then v1 else v2
        | "min" -> if v1 < v2 then v1 else v2
        | "==" -> if v1 = v2 then 1 else 0
    | If(e1, e2, e3) -> 
        if eval e1 env <> 0 then eval e2 env else eval e3 env
    | Prim _            -> failwith "unknown primitive";;
    (* Old code match cases
    | Prim("max", e1, e2) -> 
        let v1 = eval e1 env  
        let v2 = eval e2 env
        if v1 > v2 then v1 else v2
    | Prim("min", e1, e2) -> 
        let v1 = eval e1 env
        let v2 = eval e2 env
        if v1 < v2 then v1 else v2
    | Prim("==", e1, e2) -> if eval e1 env = eval e2 env then 1 else 0
    *)

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

// ii. New expressions
let e4 = Prim("max", CstI 5, CstI 8)
let e5 = Prim("min", CstI 5, CstI 8)
let e6 = Prim("==", CstI 5, CstI 8)
let e7 = Prim("==", CstI 5, CstI 5)

let eval4 = eval e4 []
let eval5 = eval e5 []
let eval6 = eval e6 []
let eval7 = eval e7 []

let e8 = If(Var "a", CstI 11, CstI 22)
let e9 = If(CstI 0, CstI 11, CstI 22)
let eval8 = eval e8 env
let eval9 = eval e9 env


type aexpr  =
  | Var of string
  | CstI of int
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr

// Write the representation of the expressions v − (w + z) and 2 ∗ (v − (w + z)) and x + y + z + v.
let ae1 = Sub(Var "v", (Add(Var "w", Var "z")))
let ae2 = Mul(CstI 2, Sub(Var "v", (Add(Var "w", Var "z"))))
let ae3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

let rec fmt aexpr : string = 
    match aexpr with
    | Var x -> x 
    | CstI i -> string i
    | Add(ae1, ae2) -> "(" + fmt ae1 + " + " + fmt ae2 + ")"
    | Sub(ae1, ae2) -> "(" + fmt ae1 + " - " + fmt ae2 + ")"
    | Mul(ae1, ae2) -> "(" + fmt ae1 + " * " + fmt ae2 + ")"

let sae = List.map fmt [ae1; ae2; ae3]


let rec simplify aexpr = 
    match aexpr with
    | Add(e, CstI 0) -> simplify e
    | Add(CstI 0, e) -> simplify e
    | Add(e1, e2) -> simplify (Add(simplify e1, simplify e2))
    | Mul(CstI 1, e) -> simplify e
    | Mul(e, CstI 1) -> simplify e
    | Mul(_, CstI 0) -> CstI 0
    | Mul(CstI 0, _) -> CstI 0
    | Mul(e1,e2) -> simplify (Mul(simplify e1, simplify e2))
    | Sub(e, CstI 0) -> simplify e
    | Sub(e1, e2) when e1 = e2 -> CstI 0
    | Sub(e1,e2) -> simplify (Sub(simplify e1, simplify e2))
    | _ -> aexpr 

let s1 = Add(CstI 0, Var "x")
let s2 = Sub(Var "x", CstI 0)
let s3 = Mul(CstI 1, Var "y") 
let s4 = Add(Var "y", Sub(CstI 4, CstI 4))
let s5 = Mul(Add(CstI 1, CstI 0),Add(Var "x", CstI 0))

let evs1 = List.map simplify [s1; s2; s3; s4; s5]

let rec diffeval aexpr1 aexpr2 = 
    match aexpr1, aexpr2 with
    | CstI _, Var _ -> CstI 0
    | Var x, Var y when x = y  -> CstI 1
    | Var x, Var y when x <> y -> CstI 0
    | Add(e1, e2), v -> Add(diffeval e1 v, diffeval e2 v)
    | Sub(e1, e2), v -> Sub(diffeval e1 v, diffeval e2 v)
    | Mul(e1, e2), v -> Add(Mul(diffeval e1 v, e2), Mul(diffeval e2 v, e1))
    | _ -> failwith "oops illegal operation straight to jail you are under arrest"


let de2 = diffeval (Var "x") (Var "x")
let de3 = diffeval (Var "x") (Var "y")
let de1 = diffeval (CstI 1) (Var "x")