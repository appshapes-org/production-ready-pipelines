FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
WORKDIR /app
EXPOSE 5079
COPY . ./
RUN dotnet publish "Api/Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=builder /app/publish .

ENTRYPOINT ["dotnet", "Api.dll"]