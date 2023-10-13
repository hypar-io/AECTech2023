# Use dotnet 6 as the base
FROM mcr.microsoft.com/devcontainers/dotnet:0-6.0

# Install .NET 7 SDK
RUN wget https://dot.net/v1/dotnet-install.sh \
    && chmod +x dotnet-install.sh \
    && ./dotnet-install.sh -c 7.0 -Version latest \
    && rm dotnet-install.sh