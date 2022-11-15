#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7116
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:7116


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SuggestionApp/SuggestionApp.csproj", "SuggestionApp/"]
RUN dotnet restore "SuggestionApp/SuggestionApp.csproj"
COPY . .
WORKDIR "/src/SuggestionApp"
RUN dotnet build "SuggestionApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SuggestionApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SuggestionApp.dll"]