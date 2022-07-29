ARG NET_IMAGE=5.0
FROM mcr.microsoft.com/dotnet/aspnet:${NET_IMAGE} AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:${NET_IMAGE} AS build
WORKDIR /src

COPY ["./Pedidos.WebApi", "./Pedidos.WebApi/"]
COPY ["./ShareKernel", "./ShareKernel/"]
RUN dotnet restore "Pedidos.WebApi/Pedidos.WebApi.csproj"
COPY . .
WORKDIR "/src/Pedidos.WebApi"
RUN dotnet build "Pedidos.WebApi.csproj" -c Release -o /app/build