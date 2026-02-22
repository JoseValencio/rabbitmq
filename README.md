RabbitMQ .NET 9 - Producer & Consumer (Async v7)

Neste projeto, apliquei os novos padrões da biblioteca RabbitMQ.Client v7:

Conexões Assíncronas: Uso de CreateConnectionAsync e CreateChannelAsync.

AsyncEventingBasicConsumer: Implementação de eventos de recebimento que não bloqueiam a thread principal.

 Tecnologias
.NET 9

RabbitMQ Client v7.2.0

Docker (para o Broker)

Como rodar o ambiente
Para subir o RabbitMQ rapidamente com interface de gerenciamento, utilize o Docker:

Bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
Acesse o painel em: http://localhost:15672 (User: guest | Pass: guest)

Estrutura do Projeto
O projeto está dividido em duas partes:

Producer: Envia mensagens para a fila letterbox.

Consumer: Escuta a fila e processa as mensagens de forma assíncrona.

Como executar
Inicie o Consumer:

Bash
cd Consumer
dotnet run
Inicie o Producer:

Bash
cd Producer
dotnet run
