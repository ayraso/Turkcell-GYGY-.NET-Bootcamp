using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public class PersonalAccount : IPostInteractions, IAccountInteractions, IAccountInfo
    {
        public PersonalAccount(string username) 
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
        }
        public string Username { get; set; }
        public Guid Id { get; set; }
        public int numOfFollowings { get; set; }
        public int numOfFollowers { get; set; }

        public void Block()
        {
            throw new NotImplementedException();
        }

        public void CommentingOnPost()
        {
            throw new NotImplementedException();
        }

        public void Follow(IAccountInfo user)
        {
            user.numOfFollowers++;
            this.numOfFollowings++;
        }

        public void Follow()
        {
            throw new NotImplementedException();
        }

        public void LikePost(Post post)
        {
            post.TotalLikes += 1;
        }

        public Post MakePost(string content)
        {
            Post newPost = new Post(content, this);
            Console.WriteLine("A new post!");
            Console.WriteLine($"{this.Username}: {newPost.Content}");
            return newPost;
        }

        public void SendMessage()
        {
            throw new NotImplementedException();
        }

        public void Unfollow(IAccountInfo user)
        {
            user.numOfFollowers--;
            this.numOfFollowings--;
        }

        public void Unfollow()
        {
            throw new NotImplementedException();
        }
    }
}
