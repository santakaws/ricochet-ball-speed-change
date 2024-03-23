echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo Compile speedChangerUI.cs to create the file: speedChangerUI.dll
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:speedChangerUI.dll speedChangerUI.cs

echo Compile speedChangerMain.cs and link the two previously created dll files to create an executable file. 
mcs -r:System -r:System.Windows.Forms -r:speedChangerUI.dll -out:speedChng.exe speedChangerMain.cs

echo View the list of files in the current folder
ls -l

echo Run the Assignment 1 program.
./speedChng.exe

echo The script has terminated.
