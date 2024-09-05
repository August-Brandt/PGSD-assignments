# Answers for HelloLex exercises

## Question 1
['0' - '9'] - A singular digit from 0 to 9
A string of the digit from 0 - 9

## Question 2
- The file generated is "hello.fs" and "hello.fsi"
- There are 3 states as foretold by the command line gods

## Question 3
It runs :D

## Question 4
Done and done look in the hello2.fsl file

## Question 5
Done see hello3.fsl

## Question 6
- The first input gets caught by the last group that being [0-9]+ that being 1 or more digits. Since the other groups are 0 or 1 then there is just 0 in this case
- The second input `34.24` is caught by the by group 2 and 3 that being (['0'-'9']*['.'])?['0'-'9']+ the `34.` = (['0'-'9']*['.'])? | `...24` = ['0'-'9']+
- The input `34,24` is reduced to `34` because the last group `['0'-'9']+` pick up the first `34` and the hits the `,` which is not recognized by the regex 

