using Bookify.Domain.Abstractions;

namespace Bookify.Domain.User
{
    public sealed class User : Entity
    {
        private User(Guid id, Email email,
            FirstName firstName,
            LastName lastName) : base(id)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public Email Email { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        public static User Create(Email email, FirstName firstName, LastName lastName)
        {
            return new User(Guid.NewGuid(), email, firstName, lastName);
        }
    }
}
