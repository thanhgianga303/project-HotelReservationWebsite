using System;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationWebsiteAPI.Data;
using MassTransit;
using MessageTypes.BookingService;

namespace HotelReservationWebsiteAPI.Consumers
{
    public class CreateBookingConsumer : IConsumer<CreateBookingMessage>
    {
        readonly HotelReservationWebsiteContext _context;
        public CreateBookingConsumer(HotelReservationWebsiteContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<CreateBookingMessage> context)
        {
            var count = 0;
            foreach (var hotel in _context.Hotels)
            {

                foreach (var item in context.Message.Items)
                {
                    if (item.HotelId == hotel.HotelID.ToString())
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    hotel.NumberofReservation++;
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
