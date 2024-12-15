Compiling and loading the micro-SML compiler (MicroSML/README.TXT)
------------------------------------------------------------------

A. Building the micro-SML command line compiler microsmlc:

  fslex --unicode FunLex.fsl
  fsyacc --module FunPar FunPar.fsy    

  dotnet build microsmlc.fsproj

Compiling the test program test01.sml:
  dotnet run test01.sml

Compiling the test program with tail call and other optimizations:
  dotnet run -opt test01.sml

Compiling AND evaluating the program with the evaluator in
HigherFun.fs:
  dotnet run -eval test01.sml

Compiling AND output intermediate AST's
  dotnet run -verbose test01.sml

The command line parameters can be combined.

C. Building the virtual machine

  The virtual machine is in the Visual Studio Project MsmlVM.

  On Unix / Mac:
  Go to directory MsmlVM/src where you find the C file msmlmachine.c
    
    gcc -Wall msmlmachine.c -o msmlmachine

  On Windows:
    You can use the Visual Studio 2019 solution MsmlVM.sln and
    compile for 32 or 64 bit.

Running the compiled test program on Mac:

  ./MsmlVM/src/msmlmachine test.out

The command line parameter -trace will write trace information on
stdout. The parameter -silent will supress garbage collection output
etc.

D. To replace the continuation based compiler with the simpler forward
compiler, simply replace Contcomp.fs with Comp.fs in the
microsmlc.fsproj file.
