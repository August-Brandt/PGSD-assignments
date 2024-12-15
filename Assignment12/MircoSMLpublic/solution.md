# 13

## 13.1

1. What is the result value of running ex09.out?  
    - Int 4
2. What type does the result value have? (Look at the result produced by the inter-
preter)
    - Int
3. What application calls have been annotated as tail calls? Explain how this matches
the intuition behind a tail call.
    - g and f have both been annotated as tail calls. The last thing that f does is to either call g or recursively call itself thus these two things should be tail calls.
4. What type has been annotated for the call sites to the functions f and g? Function
f is called in two places, and g in one place.
    - g (int -> int) | f (int -> int) in both places
5. What is the running time for executing the example using the evaluator, and what
is the running time using the byte code ex09.out using msmlmachine?
   - Elapsed 21ms CPU 30ms | CPU 0ms very fast
6. Now compile the example ex09.sml without optimizations. How many byte
code instructions did the optimization save for this small example?
   - Optimized = 84 | Unoptimized = 91 