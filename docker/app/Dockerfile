FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY src/Taiseiue.Nenga2025/Taiseiue.Nenga2025.csproj ./Taiseiue.Nenga2025/
RUN dotnet restore Taiseiue.Nenga2025

COPY ./src/Taiseiue.Nenga2025/. ./Taiseiue.Nenga2025/
WORKDIR /source/Taiseiue.Nenga2025
RUN dotnet publish Taiseiue.Nenga2025.csproj -c Release -o /app --use-current-runtime true

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
# 日本語の設定
ENV LANG ja_JP.UTF-8  
ENV LANGUAGE ja_JP:ja  
ENV LC_ALL ja_JP.UTF-8
WORKDIR /app
COPY --from=build /app/ ./
CMD ["dotnet", "Taiseiue.Nenga2025.dll"]
