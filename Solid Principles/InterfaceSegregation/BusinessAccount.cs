using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    public class BusinessAccount : IPostInteractions, IAccountInteractions, IBusinessAccountFeatures, IAccountInfo
    {
        public BusinessAccount(string username) 
        {
            this.Id = Guid.NewGuid();
            this.Username = username;
        }
        public string Username { get; set; }
        public Guid Id { get; set; }
        public int numOfFollowings { get; set; }
        public int numOfFollowers { get; set; }

        public void Advertise()
        {
            Console.WriteLine("Reklam içeriği dolaşıma sokuldu.");
        }

        public void Block(IAccountInfo user)
        {
            Console.WriteLine($"{user.Username} kullanıcısı engellendi.");
            Console.WriteLine($"Warning!\nTakipçilerinizi engellemeniz görüntülenme istatistiklerinizi etkileyebilir.");

        }

        public void CommentingOnPost(Post post, string comment)
        {
            post.TotalComments++;
            Console.WriteLine($"Hint!\nKendi gönderilerinize gelen yorumları cevaplamanız sizi öne çıkartır.");
        }

        public void Follow(IAccountInfo user)
        {
            user.numOfFollowers++;
            this.numOfFollowings++;
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

        public void SendMessage(IAccountInfo user, string message)
        {
            Console.WriteLine($"The message has been sent.");
        }

        public void Unfollow(IAccountInfo user)
        {
            user.numOfFollowers--;
            this.numOfFollowings--;
        }

        public void ViewAccountAnalytics()
        {
            Console.WriteLine("Ayrıntılı hesap analiziniz gösteriliyor.");
        }
    }
}
