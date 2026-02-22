using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory{ HostName = "localhost"};

using var connection = await factory.CreateConnectionAsync();

using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "letterbox", 
    durable:false,
    exclusive:false,
    autoDelete:false,
    arguments:null);

var message = "this is my fist Message";

var encodedMessage = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(string.Empty, "letterbox", encodedMessage);

Console.WriteLine($"Published message: {message}");