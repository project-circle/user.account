FROM microsoft/dotnet:2.2-sdk as builder

WORKDIR /app

COPY ./src/* ./

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2.2-runtime-alpine3.8

WORKDIR /app

COPY --from=builder app/out/* ./

ENTRYPOINT [ "dotnet", "app/user.account.dll" ]