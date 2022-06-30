#!/bin/sh

JAVAHOME=/Library/Java/JavaVirtualMachines/microsoft-11.jdk/Contents/Home

cd mylib
rm -rf ./build
$JAVAHOME/bin/javac -d ./build *.java
cd build
$JAVAHOME/bin/jar cvf mylib.jar *
cd ../..

dotnet build ./MyApp
