using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public class RatingErrors
{
    public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");
}