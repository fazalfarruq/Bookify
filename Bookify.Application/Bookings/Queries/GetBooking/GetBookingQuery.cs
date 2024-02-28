using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.Queries.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;