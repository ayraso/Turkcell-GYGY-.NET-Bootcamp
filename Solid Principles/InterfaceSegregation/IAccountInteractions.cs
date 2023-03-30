using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IAccountInteractions
    {
        public void SendMessage();
        public void Follow();
        public void Unfollow();
        public void Block();
    }
}
