fun test t = fn r -> print (t = r)


(* Functions continued *)

(* Example: two function definitions: a comparison and Fibonacci *)
val tfun30 =
  let fun ge2 x = 1 < x
  in let fun fib n = if ge2 n then fib(n-1) + fib(n-2) else 1
     in fib 10 end
  end

val tfun31 =
  let fun ge2 x = 1 < x
      and fib n = if ge2 n then fib(n-1) + fib(n-2) else 1
  in fib 10 end

val tfun32 = (* Mixing global and closure variables *)
  let val x = 42
      val y = 41
  in (fn z -> z+x+y) 1 end

val tfun33 = (* Mixing global, closure and local variables *)
  let val x = 42
  in let val y = 41
     in ((fn z -> let val l = 40 in let val m = 39 in m+l+z+x+y end end) 1)
     end
  end

fun tfun34 i = fn j -> if i <= 0 then 0 else tfun34' (i-1) + tfun34 (i-1) j
and tfun34' i = tfun34 (i-1) i	   

fun tfun35 i = fn j -> fn k -> fn l ->
  let
    fun add m = i + j + k + l + m
  in
    add 1
  end

(* Sequence Expression *)
val tseq01 = false ; 1 ; true ; 42

begin
  test tfun30 89;
  test tfun31 89;
  test tfun32 84;
  test tfun33 163;
  test (tfun34 4 10) 0;
  test (tfun35 1 2 3 4) 11;
  
  test tseq01 42

end
