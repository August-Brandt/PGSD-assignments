#!/usr/bin/env zsh
source ~/.zshrc

fslex --unicode "FunLex.fsl"
fsyacc --module FunPar FunPar.fsy
fsi Util.fs Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs start.fsx