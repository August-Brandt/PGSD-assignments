fslex --unicode ExprLex.fsl
fsyacc --module ExprPar ExprPar.fsy

dotnet fsi -r ~/Documents/ITU/5._Semester/ProgramsAsData/ProgramsAsDataCodeE2024/fsharp/FsLexYacc.Runtime.dll Absyn.fs Expr.fs ExprPar.fs ExprLex.fs Parse.fs