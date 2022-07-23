#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Pedidos.WebApi/Pedidos.WebApi.csproj", "Pedidos.WebApi/"]
COPY ["Pedidos.Infraestructure/Pedidos.Infraestructure.csproj", "Pedidos.Infraestructure/"]
COPY ["Pedidos.Application/Pedidos.Application.csproj", "Pedidos.Application/"]
COPY ["Pedidos.Domain/Pedidos.Domain.csproj", "Pedidos.Domain/"]
COPY ["ShareKernel/ShareKernel.csproj", "ShareKernel/"]
RUN dotnet restore "Pedidos.WebApi/Pedidos.WebApi.csproj"
COPY . .
WORKDIR "/src/Pedidos.WebApi"
RUN dotnet build "Pedidos.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pedidos.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedidos.WebApi.dll"]