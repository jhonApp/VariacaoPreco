#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VariacaoPreco.Core/VariacaoPreco.Core.csproj", "VariacaoPreco.Core/"]
RUN dotnet restore "VariacaoPreco.Core/VariacaoPreco.Core.csproj"
COPY . .
WORKDIR "/src/VariacaoPreco.Core"
RUN dotnet build "VariacaoPreco.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VariacaoPreco.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VariacaoPreco.Core.dll"]