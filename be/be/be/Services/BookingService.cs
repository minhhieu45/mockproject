using be.Models;

namespace be.Services
{
    public class BookingService : IBookingService
    {
        private readonly DbFourSeasonHotelContext _context;

        public BookingService()
        {
            _context = new DbFourSeasonHotelContext();
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(int bookingId)
        {
            var item = _context.Bookings.Find(bookingId);
            _context.Bookings.Remove(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IList<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public Booking GetBooking(int bookingId)
        {
            return _context.Bookings.Find(bookingId);
        }

        public void UpdateBooking(Booking booking)
        {
            Booking updateBooking = _context.Bookings.Find(booking.BookingId);
            updateBooking = booking;
            _context.SaveChanges();
        }
    }
}
