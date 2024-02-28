using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Bookings.GetBooking;

internal sealed class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, Result<BookingResponse>>
{
    public Task<Result<BookingResponse>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}