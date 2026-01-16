runas /noprofile /user:hjl_admin@MOTORDATA.local\navsvc "dotnet \"C:\Users\hjl_admin\VS Code Repos\Nav-Jobs\bin\Debug\net48\Nav-Jobs.exe\""

runas /noprofile /user:MOTORDATA\navsvc "dotnet \"C:\Users\hjl_admin\VS Code Repos\Nav-Jobs\bin\Debug\net48\Nav-Jobs.exe\""

#dotnet clean
#dotnet build
#dotnet run


# Update Service Reference
# 1. Make sure tool is installed
dotnet tool install --global dotnet-svcutil
# vertify tool
dotnet-svcutil
# Remove the old generated reference (important)
Get-ChildItem -Directory  ## get reference name
Get-ChildItem ServiceReferene -Recurse
Remove-Item -Recurse -Force ServiceReferene
# crate new service reference
dotnet-svcutil "http://localhost:7649/DynamicsNAVCarloTEST/WS/MOTORFORUM%20DRAMMEN/Codeunit/TestNavWs?wsdl" --outputDir ServiceReferene --namespace "*,ServiceReference" --targetFramework net48

