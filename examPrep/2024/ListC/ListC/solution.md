# 10.1
(i) Write 3–10 line descriptions of how the abstract machine executes each of the
following instructions:
- ADD, which adds two integers.
We fetch the value located at the top of the stack using the current value of our stackpointer as well as the value below using sp-1. Untag both values which treats them as ints we can then add the two numbers together and tag the result. We then place this at the location of sp-1 and decrement the stackpointer to point at this location now

- CSTI i, which pushes integer constant i.
We grab the next value from the program using the programcounter(pc)+1 which will be the integer we would like to add to the stack. We then this value and put it on the stack at sp+1 and then we increment the stackpointer to point at this.

- NIL, which pushes a nil reference. What is the difference between NIL and CSTI 0?
It puts the actual value of 0 on the stack at sp+1 and increments the stack pointer. This will be seen as a reference to 0 as the least significant bit will be 0. CstI 0 would tag the result thus setting the lsb to 1 this would therefore not be seen as a reference.

- IFZERO, which tests whether an integer is zero, or a reference is nil.
Pops a value off the stack and stores it in var v. We then check if v is an int or a reference. If int we untag and check if == 0 if not an int we just check if v is == 0. if either of these are true then we fetch the address to jump to from the program at the pc if not we increment the pc. We then set the pc to whatever was decided on. PCP 

- CONS
We create a pointer to a word using allocate with the values of a CONSTAG (which is always 0), the length of the Cons Cell which is always 2 as well as the stack and the stack pointer. We then set  index 0 of the new CONS cell to the header, index 1 is the sp-1 value of the stack and index 2 is the value at the top of the stack. We then insert the reference to the new Conscell on the stack at sp-1 and then decrement the stack pointer so it points to this.

- CAR
We access a Cons cell and check that it is not 0 (if it is we die). We then take the first value of the Conscell (index 1) and put it on the top of th stack overriding the pointer to the Conscell.

- SETCAR
We pop a value off the stack. We then save the pointer to the Cons cell in a variable and replace the index 1 of the cons cell with the value we took from the stack.

(ii) Describe the result of applying each C macro Length, Color and Paint from
Sect. 10.7.4 to a block header ttttttttnnnnnnnnnnnnnnnnnnnnnngg, that
is, a 32-bit word, as described in the source code comments.
- Length takes the header and shifts it to the right by 2 removing the color bits. It then ands with the hex value of 0x003FFFFF which will exclude all the t values and will be all 1´s for the n values meaning we will get back all the n´s that are 1 which gives us the length 
- Color ands the header with the integer value 3 which is 11 in binary which will give us the value of gg
- Paint it zeroes the color of the header with the binary 00 = (&(~3)) we then or it with the new color setting the color to that. Crazy so cool. wow

(iii) When does the abstract machine, or more precisely, its instruction interpretation
loop, call the allocate(…) function? Is there any other interaction between the
abstract machine (also called the mutator) and the garbage collector?

It calls allocate in Cons. When you try to allocate and there is no more free space on the freelist we can call the garbage collector to try and free some space. If this fails twice we die.

(iv) In what situation will the garbage collector’s collect(…) function be called?  
See above

# 10.2
