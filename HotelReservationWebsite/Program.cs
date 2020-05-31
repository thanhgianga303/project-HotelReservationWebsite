using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HotelReservationWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
            // Received();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
        // public static void Received()
        // {
        //     var factory = new ConnectionFactory() { HostName = "localhost" };
        //     using (var connection = factory.CreateConnection())
        //     using (var channel = connection.CreateModel())
        //     {
        //         channel.QueueDeclare(queue: "hello",
        //                              durable: false,
        //                              exclusive: false,
        //                              autoDelete: false,
        //                              arguments: null);

        //         var consumer = new EventingBasicConsumer(channel);
        //         consumer.Received += (model, ea) =>
        //         {
        //             var body = ea.Body;
        //             var message = Encoding.UTF8.GetString(body.ToArray());
        //             // var x = "dd";
        //             // var test = JsonConvert.DeserializeObject<User>(message);
        //             Console.WriteLine(" [x] Received {0}", message);
        //             // _serviceAPIIdentity.Create(message)
        //         };

        //         channel.BasicConsume(queue: "hello",
        //                              autoAck: true,
        //                              consumer: consumer);

        //         Console.WriteLine(" Press [enter] to exit.");
        //         Console.ReadLine();
        //     }


        // }
    }
}
