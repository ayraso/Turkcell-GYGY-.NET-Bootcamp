using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IPostInteractions
    {
        public Post MakePost(string content);
        public void LikePost(Post post);
        public void CommentingOnPost();
    }
}
