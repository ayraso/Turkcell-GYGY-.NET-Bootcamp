using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IAccountInfo
    {
        public string Username { get; set; }
        public Guid Id { get; set; }
        public int numOfFollowings { get; set; }
        public int numOfFollowers { get; set; }

    }
}
