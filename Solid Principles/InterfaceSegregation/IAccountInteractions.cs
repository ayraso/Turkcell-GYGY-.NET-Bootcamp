using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IAccountInteractions
    {
        public void SendMessage(IAccountInfo user, string message);
        public void Follow(IAccountInfo user);
        public void Unfollow(IAccountInfo user);
        public void Block(IAccountInfo user);
    }
}
