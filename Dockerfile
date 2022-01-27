from archlinux
RUN pacman --noconfirm -Syu&&pacman --noconfirm -S mysql aspnet-runtime dotnet-runtime dotnet-sdk dotnet-host
WORKDIR /RecImage
COPY . .
CMD ["dotnet","run"]
