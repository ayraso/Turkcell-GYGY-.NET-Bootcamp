using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public interface IPostInteractions
    {
        public void MakePost();
        public void LikePost();
        public void CommentingOnPost();
    }
}
