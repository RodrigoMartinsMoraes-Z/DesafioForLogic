#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Desafio4Logic.Api.Avaliacao/Desafio4Logic.Api.Avaliacao.csproj", "Desafio4Logic.Api.Avaliacao/"]
RUN dotnet restore "Desafio4Logic.Api.Avaliacao/Desafio4Logic.Api.Avaliacao.csproj"
COPY . .
WORKDIR "/src/Desafio4Logic.Api.Avaliacao"
RUN dotnet build "Desafio4Logic.Api.Avaliacao.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desafio4Logic.Api.Avaliacao.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio4Logic.Api.Avaliacao.dll"]