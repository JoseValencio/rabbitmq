using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory{ HostName = "localhost"};

using var connection = await factory.CreateConnectionAsync();

using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "letterbox", 
    durable:false,
    exclusive:false,
    autoDelete:false,
    arguments:null);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync +=  async (model, ea) => {
   var body = ea.Body.ToArray();
   var message = Encoding.UTF8.GetString(body);
   Console.WriteLine($"Received message: {message}");
};

await channel.BasicConsumeAsync(queue: "letterbox", autoAck: true, consumer: consumer);

Console.ReadKey();