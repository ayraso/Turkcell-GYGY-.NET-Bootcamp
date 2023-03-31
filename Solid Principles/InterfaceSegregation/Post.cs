using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public class Post
    {
        public Post(string content, IAccountInfo user) 
        {
            this.Id = Guid.NewGuid();
            this.Content = content;
            this.Creator = user;
        }
        public Guid Id { get; private set; }
        public IAccountInfo Creator { get; set; }
        public string Content { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }


    }
}
