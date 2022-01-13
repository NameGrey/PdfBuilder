FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PdfBuilder/PdfBuilder.csproj", "PdfBuilder/"]
RUN dotnet restore "PdfBuilder/PdfBuilder.csproj"
COPY . .
WORKDIR "/src/PdfBuilder"
RUN dotnet build "PdfBuilder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PdfBuilder.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PdfBuilder.dll"]