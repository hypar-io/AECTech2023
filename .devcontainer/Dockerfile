# Use dotnet 7 as the base
FROM mcr.microsoft.com/devcontainers/dotnet:0-7.0

# Install .NET 6 SDK
RUN wget https://dot.net/v1/dotnet-install.sh \
    && chmod +x dotnet-install.sh \
    && ./dotnet-install.sh -c 6.0 -Version latest \
    && rm dotnet-install.sh