FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Prolexy.IssueInsurance/Prolexy.IssueInsurance.csproj", "Prolexy.IssueInsurance/"]
RUN dotnet restore "Prolexy.IssueInsurance/Prolexy.IssueInsurance.csproj"
COPY . .
WORKDIR "/src/Prolexy.IssueInsurance"
RUN dotnet build "Prolexy.IssueInsurance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prolexy.IssueInsurance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prolexy.IssueInsurance.dll"]
