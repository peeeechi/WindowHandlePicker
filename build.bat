cd .\WindowHandlePicker
dotnet restore
dotnet clean
dotnet publish -r win-x64 -o .\WindowHandlePicker

cd ..\winforms-sample
dotnet restore
dotnet clean
dotnet publish -r win-x64 -o .\winforms-sample

cd ..