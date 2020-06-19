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
            // foreach (var bookingItem in context.Message.Items)
            // {
            // Validate product Quantity
            // var currentProduct = await _context.Products.FindAsync(orderDetailItem.ProductId);
            // int newQuantity = currentProduct.Quantity - orderDetailItem.Quantity;
            // if (newQuantity < 0)
            // {
            //     throw new Exception("Quantity must be greater than zero");
            // }
            // else
            // {
            //     currentProduct.Quantity = newQuantity;
            // }
            // var hotels = _context.Hotels.Where(h =>h.NumberofReservation==bookingItem.);
            Console.WriteLine("con mua ngang qua:" + context.Message.BookingId);
            Console.WriteLine("con mua ngang qua 1:" + context.Message.Items.Count());

            // }

            await _context.SaveChangesAsync();
        }
    }
}
