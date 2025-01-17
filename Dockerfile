FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Copy the csproj and restore all of the nugets
COPY *.csproj ./
RUN dotnet restore
# Copy everything else and build
COPY . ./
RUN ls -l /app
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "EmployeeApi.dll"]