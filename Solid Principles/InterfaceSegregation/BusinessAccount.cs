using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public class BusinessAccount : IPostInteractions, IAccountInteractions, IBusinessAccountFeatures
    {
        public void Advertise()
        {
            throw new NotImplementedException();
        }

        public void Block()
        {
            throw new NotImplementedException();
        }

        public void CommentingOnPost()
        {
            throw new NotImplementedException();
        }

        public void Follow()
        {
            throw new NotImplementedException();
        }

        public void LikePost()
        {
            throw new NotImplementedException();
        }

        public void MakePost()
        {
            throw new NotImplementedException();
        }

        public void SendMessage()
        {
            throw new NotImplementedException();
        }

        public void Unfollow()
        {
            throw new NotImplementedException();
        }

        public void ViewAccountAnalytics()
        {
            throw new NotImplementedException();
        }
    }
}
