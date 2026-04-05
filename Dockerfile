# --- STAGE 1: BUILD ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file first to leverage Docker layer cache for restore
COPY ["CuoiKy_CCMTPTPM.csproj", "./"]
RUN dotnet restore "CuoiKy_CCMTPTPM.csproj"

# Copy source and publish
COPY . .
RUN dotnet publish "CuoiKy_CCMTPTPM.csproj" -c Release -o /app/publish /p:UseAppHost=false

# --- STAGE 2: RUN ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Start the ASP.NET Core app
ENTRYPOINT ["dotnet", "CuoiKy_CCMTPTPM.dll"]
