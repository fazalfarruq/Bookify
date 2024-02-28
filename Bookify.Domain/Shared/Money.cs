namespace Bookify.Domain.Shared;

public record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new ApplicationException("Cannot add money with different currencies");
        }
        return new Money(left.Amount + right.Amount, left.Currency);
    }


    public static Money Zero() => new Money(0, Currency.None);
    public static Money Zero(Currency currency) => new Money(0, currency);

        
    public bool IsZero() => this == Zero(Currency);
    

}