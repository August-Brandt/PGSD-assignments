# Jan 2023 - Solution 

## Opgave 1

### 1:
Every(Write(FromTo(5,12)))

`FromTo` giver os sekvensen *5 6 7 8 9 10 11 12*
`Write` udskriver et resultat
`Every` Tvinger `Write` til at udskrive alle resultater i sekvensen

### 2:
Every(Write(Prim("<", CstI 10, FromTo(5,12))))

`Prim("<", CstI 10, FromTo(5,12))` giver kun succesfulde værdier når 10 er mindre end resultatet. Dermed får vi sekvensen *11 12*
`Every(Write(...)` udskriver alle værdierne i den endelige sekvens

### 3:
Every(Write(Prim("<", FromTo(5,11), Or(FromTo(5,12), Every(Write(CstS "\n"))))))

`Prim("<", FromTo(5,11), FromTo(5,12))` giver en sekvensen: 6 7 8 9 10 11 12 7 8 9 10 11 12 8 9 10 11 12 osv. 
`Or(FromTo(5,12), Every(Write(CstS "\n")))` Sørger for at lave et newline i slutningen af hver linje
`Every(Write(...)` Sørger for at alle tallene i hver linje bliver udskrevet

### 4:
Kode ændringer:
```
(* Char lookup *)

let CharTable =
  [('A', 0); 
    ('B', 1); 
    ('C', 2); 
    ('D', 3); 
    ('E', 4); 
    ('F', 5); 
    ('G', 6); 
    ('H', 7);
    ('I', 8);
    ('J', 9);
    ('K', 10);
    ('L', 11);
    ('M', 12);
    ('N', 13);
    ('O', 14);
    ('P', 15);
    ('Q', 16);
    ('R', 17);
    ('S', 18);
    ('T', 19);
    ('U', 20);
    ('V', 21);
    ('W', 22);
    ('X', 23);
    ('Y', 24);
    ('Z', 25)]

...

let rec eval (e : expr) (cont : cont) (econt : econt) = 
    match e with
    ...
    | FromToChar(c1, c2) ->
        let c1i = snd (List.find (fun c -> fst c = c1) CharTable)
        let c2i = snd (List.find (fun c -> fst c = c2) CharTable)
        let rec loop i =
            if i <= c2i then
            cont (Str (string (fst (List.find (fun c -> snd c = i) CharTable)))) (fun () -> loop (i+1))
            else 
            econt ()
        loop c1i
```

### 5:
Kode ændringer:
```
let rec eval (e : expr) (cont : cont) (econt : econt) = 
    match e with
    ...
    | Prim(ope, e1, e2) ->
        ...
        | ("<", Str s1, Str s2) -> 
                    let i1 = snd (List.find (fun c -> fst c = char s1) CharTable)
                    let i2 = snd (List.find (fun c -> fst c = char s2) CharTable)
                    if i1<i2 then 
                        cont (Str s2) econt2
                    else
                        econt2 ()
```

### 6:
Every(Write(FromToChar('H', 'L')))

`FromToChar('H', 'L')` laver sekvensen fra `H` til `L`: `H I J K L`
`Every(Write(...))` udskriver hele sekvensen

## Opgave 2