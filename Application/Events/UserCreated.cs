using Coravel.Events.Interfaces;
using TransferBase.Application.Models;

namespace TransferBase.Application.Events
{
    public class UserCreated : IEvent
    {
        public User User { get; set; }

        public UserCreated(User user)
        {
            this.User = user;
        }
    }
}