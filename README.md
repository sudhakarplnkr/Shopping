Grant access to folder
----------------------
sudo chmod -R a+rwx <target folder>

Create development sql server instance
--------------------------------------
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Root@123456" \
   -p 1433:1433 --name devsql \
   -h sql \
   -d mcr.microsoft.com/mssql/server:2019-latest

Get container IP
----------------
sudo docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' <container id>

Migration
---------
   Add
   ----
   dotnet ef migrations add <Name> -s Inventory.WebApi.csproj
   
   Remove
   ------
   dotnet ef migrations remove

   Run
   ---
   dotnet ef database update -s Inventory.WebApi.csproj