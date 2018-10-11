#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 7564
EXPOSE 44385

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Black.Beard.Workflow.Service/Black.Beard.Workflow.Service.csproj", "Black.Beard.Workflow.Service/"]
RUN dotnet restore "Black.Beard.Workflow.Service/Black.Beard.Workflow.Service.csproj"
COPY . .
WORKDIR "/src/Black.Beard.Workflow.Service"
RUN dotnet build "Black.Beard.Workflow.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Black.Beard.Workflow.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Black.Beard.Workflow.Service.dll"]