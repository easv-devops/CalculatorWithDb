# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Calculator.csproj", "./"]
RUN dotnet restore "Calculator.csproj"
COPY . .
RUN dotnet build "Calculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calculator.csproj" -c Release -o /app/publish

# Generate runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calculator.dll"]