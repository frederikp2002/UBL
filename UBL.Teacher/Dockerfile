FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UBL.Teacher/UBL.Teacher.csproj", "UBL.Teacher/"]
RUN dotnet restore "UBL.Teacher/UBL.Teacher.csproj"
COPY . .
WORKDIR "/src/UBL.Teacher"
RUN dotnet build "UBL.Teacher.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UBL.Teacher.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UBL.Teacher.dll"]
