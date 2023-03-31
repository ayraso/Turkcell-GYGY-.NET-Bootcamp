using InterfaceSegregation;

PersonalAccount SalvorHardin = new PersonalAccount("salvor");
PersonalAccount HaroldFinch = new PersonalAccount("harold");
BusinessAccount PrimeVideoTr = new BusinessAccount("primevideotr");

Post post1 = HaroldFinch.MakePost("Good Morning!");
Post post2 = PrimeVideoTr.MakePost("Bir bölüm daha, sonra yatıyorum.");

SalvorHardin.LikePost(post1);
SalvorHardin.LikePost(post2);
HaroldFinch.LikePost(post2);

Console.WriteLine($"{post1.TotalLikes} kişi {post1.Creator.Username}'in gönderisini beğendi.");
Console.WriteLine($"{post2.TotalLikes} kişi {post2.Creator.Username}'in gönderisini beğendi.");

SalvorHardin.Follow(PrimeVideoTr);
HaroldFinch.Follow(PrimeVideoTr);
SalvorHardin.Follow(HaroldFinch);
HaroldFinch.Follow(SalvorHardin);

Console.WriteLine($"{SalvorHardin.Username} hesabının {SalvorHardin.numOfFollowers} adet takipçisi var.");
Console.WriteLine($"{HaroldFinch.Username} hesabının {HaroldFinch.numOfFollowers} adet takipçisi var.");
Console.WriteLine($"{PrimeVideoTr.Username} hesabının {PrimeVideoTr.numOfFollowers} adet takipçisi var.");

