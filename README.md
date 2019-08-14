# Azure Function RabbitMQ Example

```
# start RabbitMQ Server
docker run -d --hostname my-rabbit --name my-rabbit -p 5671:5671 -p 5672:5672 -p 15672:15672 rabbitmq:3-management

# build and run
dotnet publish AzureFunctionRabbitMQ.csproj --output ./release

# set environment variable: AzureWebJobsStorage 
$env:AzureWebJobsStorage = "DefaultEndpointsProtocol=https;AccountName=cosymaplayground;AccountKey=TODO;EndpointSuffix=core.windows.net"

# start executable
dotnet .\release\AzureFunctionRabbitMQ.dll
```

## RabbitMQ Extension

The folder `azure-functions-rabbitmq-extension` contains the source code for the RabbitMQ Extension (not published yet for NuGet yet).

```
update RabbitMQ Extension
git clone git@github.com:Azure/azure-functions-rabbitmq-extension.git
```

## RabbitMQ on windows
```
# install
choco install erlang
choco install rabbitmq

# visit Management Interace (guest, guest)
http://localhost:15672/#/
```



