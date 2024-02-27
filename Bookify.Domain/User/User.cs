using Bookify.Domain.Abstractions;
using Bookify.Domain.User.Events;

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
            
            var user = new User(Guid.NewGuid(), email, firstName, lastName);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }
    }
}
