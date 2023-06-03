
# Hangfire Neden Kullanılır?

Web uygulamalarında, arka planda farklı periyotlarda ve farklı bağımlılıklara sahip görevlerin çalışmasını istediğimiz çeşitli durumlarla karşılaşırız. Rapor oluşturma işlemleri, mail/sms gönderme işlemleri, veritabanı yedeklemeleri, uzun süren veritabanı sorguları, ticaret sitelerindeki kampanyaların otomatik başlatılması gibi arka plan işlemlerinin yönetilmesini sağlar. Bu işler birer "job" olarak tanımlanır ve uygulamanın domain nesneleri ile uygulama verilerinin tutulduğu veri tabanından farklıdır. 

# Hangfire'ın Özellikleri
* Job'ların Sıralanması: Job'ları sırayla ve önceliklerine göre yönetmeyi sağlar.
* Tekrar Deneme ve Hata İşleme: Job'ların başarısız olması durumunda otomatik olarak tekrar deneme yapar ve bu başarısız job'lar hata, uyarı durumlarıyla birlikte kaydedilir.
* Job'ların Durumu: Dashboard sayesinde çalışan job'ların durumu takip edilebilir.
* Ölçeklenebilirlik: Hangfire, birden çok sunucuda çalışabilme yeteneğine sahiptir. Bu sayede, işleri paralel olarak dağıtabilir ve yüksek trafikli uygulamalarda ölçeklendirme yapabilirsiniz. Örneğin, bir sunucu yüksek iş yükü altındayken diğer sunuculara işleri dağıtabilir ve böylece performansı artırabilirsin

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

# Hangfire'ın Kullandığı Tablolar
1. **Hangfire.Job**: Tanımlanan işlerin bilgilerini içerir. Job'ın adı, parametreleri, başlangıç ve bitiş zamanı gibi bilgiler bu tabloda tutulur.
2. **Hangfire.State**: İşlerin durumlarını temsil eder. İşlerin hangi aşamada olduğunu (başarılı, başarısız, iptal edildi vb.) ve ilgili hata veya ayrıntı bilgilerini depolar.
3. **Hangfire.Hash**: Hangfire'ın dağıtılmış görev durumlarını depolamak için kullanılır. Örneğin, bir işin birden fazla adıma sahip olduğu durumlarda, adımların durumları bu tabloda tutulur.
4. **Hangfire.Server**: Hangfire sunucusunun bilgilerini içerir. Sunucu adı, son kontrol zamanı gibi bilgiler bu tabloda tutulur.
5. **Hangfire.Lock**: Hangfire'ın eş zamanlılık ve senkronizasyonu sağlamak için kullanılan kilitleme mekanizmasını destekler. Birden fazla işin aynı anda çalışmasını, aynı kaynağı kullanmasını engellemek için bu tablo kullanılır. Lock'ın adı, sahibi, son değişiklik zamanı gibi bilgiler tutulur.
6. **Hangfire.AggregatedCounter**: İşlerin veya iş gruplarının istatistiksel bilgilerini toplamak için kullanılan tablodur. İşin türü, tarihi gibi bilgileri içerir. Örneğin, bir işin ne sıklıkla çalıştığını veya belirli bir türdeki işlerin toplam sayısını takip etmek için kullanılabilir.
7. **Hangfire.Counter**: İşlerin veya iş gruplarının sayaç bilgilerini saklamak için kullanılan tablodur. İşin türü, kimliği gibi bilgileri içerir. Örneğin, bir işin başarılı veya başarısız denemelerinin sayısını tutmak veya bir iş grubunun toplam iş sayısını saklamak için kullanılabilir.
8. **Hangfire.JobParameter**: İşlerin parametrelerini saklamak için kullanılan tablodur.
9. **Hangfire.JobQueue**: İşlerin çalışma sırasını yönetmek için kullanılan tablodur. Queue adı, JobId gibi bilgileri içerir. İşlerin hangi sırada çalışacaklarını belirlemek ve işleri planlamak için kullanılır.
10. **Hangfire.Set**: İşlerin veya verilerin küme halinde saklanması için kullanılan tablodur. Kümeler, belirli bir anahtar (Key) altında gruplanan veri noktalarını içerir. Örneğin, zamanlanmış işlerin tutulduğu bir küme veya işlerin önceliklerini belirlemek için kullanılan bir küme oluşturulabilir.
11. **Hangfire.Schema**: Hangfire tablolarının veritabanında doğru bir şekilde oluşturulduğunu izlemek için kullanılan tablodur. Hangfire'ın tablolarını ve şema sürümünü takip etmek için kullanılır.


