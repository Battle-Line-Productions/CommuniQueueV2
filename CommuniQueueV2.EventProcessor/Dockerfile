FROM public.ecr.aws/lambda/dotnet:9 AS base

# Set working directory
WORKDIR /var/task

# Copy csproj and restore as distinct layers
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CommuniQueueV2.EventProcessor.csproj", "./"]
RUN dotnet restore "CommuniQueueV2.EventProcessor.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "CommuniQueueV2.EventProcessor.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CommuniQueueV2.EventProcessor.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /var/task
COPY --from=publish /app/publish .
CMD ["CommuniQueueV2.EventProcessor::CommuniQueueV2.EventProcessor.Function::FunctionHandler"]
