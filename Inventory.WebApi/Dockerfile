FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Inventory.WebApi/Inventory.WebApi.csproj", "./"]
RUN dotnet restore "Inventory.WebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Inventory.WebApi/Inventory.WebApi.csproj" -c Release -o /app/build
RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef database update -s Inventory.WebApi/Inventory.WebApi.csproj --configuration Release

FROM build AS publish
RUN dotnet publish "Inventory.WebApi/Inventory.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./Inventory.WebApi/wait-for-it.sh ./wait-for-it.sh
RUN chmod +x wait-for-it.sh
ENTRYPOINT ["./wait-for-it.sh", "db:1433", "-t", "120", "--", "dotnet", "Inventory.WebApi.dll"]