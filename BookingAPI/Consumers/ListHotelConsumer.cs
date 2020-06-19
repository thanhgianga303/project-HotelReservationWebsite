using System;
using System.Threading.Tasks;
using MassTransit;
using MessageTypes.HotelReservation;

namespace BookingAPI.Consumers
{
    public class ListHotelConsumer : IConsumer<ListHotelMessage>
    {
        public Task Consume(ConsumeContext<ListHotelMessage> context)
        {
            Console.WriteLine($"{context.Message.Message}");
            return Task.CompletedTask;
        }
    }
}
