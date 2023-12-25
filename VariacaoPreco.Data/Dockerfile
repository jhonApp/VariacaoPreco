#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VariacaoPreco.Data/VariacaoPreco.Data.csproj", "VariacaoPreco.Data/"]
RUN dotnet restore "VariacaoPreco.Data/VariacaoPreco.Data.csproj"
COPY . .
WORKDIR "/src/VariacaoPreco.Data"
RUN dotnet build "VariacaoPreco.Data.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VariacaoPreco.Data.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VariacaoPreco.Data.dll"]