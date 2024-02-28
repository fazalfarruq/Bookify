using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;

        var price = apartment.Price.Amount * period.LengthInDays;
        var priceForPeriod = new Money(price, currency);

        decimal percentageUpCharge = 0;
        foreach (var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning => 0.01m,
                Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var totalPrice = Money.Zero();
        var amenitiesUpCharge = Money.Zero();
        if (percentageUpCharge > 0)
        {
            var upCharge = priceForPeriod.Amount * percentageUpCharge;
            amenitiesUpCharge = new Money(upCharge, currency);
        }


        totalPrice += priceForPeriod;
        totalPrice += amenitiesUpCharge;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}