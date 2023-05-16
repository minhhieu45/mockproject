using be.Models;

namespace be.Services
{
    public interface IBookingService : IDisposable
    {
        Booking GetBooking(int bookingId);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int bookingId);
        IList<Booking> GetAllBookings();
    }
}
