
dotnet publish --framework netcoreapp3.1 ".\src\TodoServer\TodoServer.csproj" -c Release -o ".\dist\"
if %errorlevel% neq 0 (
  pause
  exit %errorlevel%
)