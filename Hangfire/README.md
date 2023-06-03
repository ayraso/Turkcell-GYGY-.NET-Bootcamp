# Hangfire Neden Kullanılır?

Web uygulamalarında, arka planda farklı periyotlarda ve farklı bağımlılıklara sahip görevlerin çalışmasını istediğimiz çeşitli durumlarla karşılaşırız. Rapor oluşturma işlemleri, mail/sms gönderme işlemleri, veritabanı yedeklemeleri, uzun süren veritabanı sorguları, ticaret sitelerindeki kampanyaların otomatik başlatılması gibi arka plan işlemlerinin yönetilmesini sağlar. Bu işler birer "job" olarak tanımlanır ve uygulamanın domain nesneleri ile uygulama verilerinin tutulduğu veri tabanından farklıdır. 

# Hangfire'ın Özellikleri
* Job'ların Sıralanması: Job'ları sırayla ve önceliklerine göre yönetmeyi sağlar.
* Tekrar Deneme ve Hata İşleme: Job'ların başarısız olması durumunda otomatik olarak tekrar deneme yapar ve bu başarısız job'lar hata, uyarı durumlarıyla birlikte kaydedilir.
* Job'ların Durumu: Dashboard sayesinde çalışan job'ların durumu takip edilebilir.

# Job Türleri
Job'lar çalışma şekline, zamanına ve periyoduna göre sınıflandırılır.
1. **Fire-and-Forget Jobs**: Job oluşturulduktan hemen sonra yalnızca bir kez çalışıtırlır. 

2. **Delayed Jobs**: Belirtilen süre sonra çalışmaları için zamanlanmış yalnızca 1 kez çalışan job'lardır. Ör.:Bildirim gönderme işlemleri

3. **Recurring Jobs**: Belirli bir periyotla tekrarlanacak şekilde zamanlanır. Ör.: Her ay sonu rapor oluşturup gönderme işlemleri
Bu job türünde periyor belirtmek için CRON ayarı yapılmalıdır.
Expression için yardımcı site: https://crontab.guru/.

4. **Continuations Jobs**: Kendisinin başlaması, başka bir job'ın bitmesine bağlı olan işlemler bu türde tanımlanır. Ör.: Kullanıcı kayıt olduğunda, otomatik olarak hoşgeldiniz epostası göndermek

5. **Batch Jobs**: Birden çok işin bir araya getirildiği ve grup olarak çalıştırıldığı işlerdir. Ör.: Toplu e-posta gönderme işlemleri
6. **Batch Continuations Jobs**: Birden çok işin bir araya getiriildiği bir parent batch'in bitmesine bağlı olarak çalışmaya başlayan iş gruplarıdır.

Not: "Batch Jobs" ve "Batch Continuations Jobs" türleri yalnızca Pro sürümünde, ücretli olarak sunulmaktadır. 


# Hangfire Projeye Nasıl Entegre Edilir?
**Package Dependencies**

Projenize aşağıdaki Nuget paketlerini eklemeniz gerekmektedir.
1. Hangfire
2. Hangfire.SqlServer
3. Microsoft.Data.SqlClient
