
# OAuth Nedir?
**Third party** uygulamalara, API'lar tarafýndan bazý hizmetler saðlanýr. Bu hizmetler temelde ikiye ayrýlýr: 
1. API saðlayýcýsý uygulamanýn, User'lara saðladýðý hizmetlerin third party bir uygulamanýn eriþimine sunmasý.
2. API saðlayýcýsý uygulamanýn, kendi service'lerine eriþim sunmasý.    


Bu iþlemler esnasýnda uygulama isteklerinin esas client'tan geldiðine emin olunmasý ihtiyacý doðmaktadýr. Çünkü, bir iþletim sistemi üzerinde veya web browser üzerinde çalýþan uygulamalarýn kimlik doðrulama bilgileri genel olarak eriþilebilirdir. Bu tarz uygulamalarýn kimlik bilgileri kullanýcýlarýn cihaz belleðinde veya depolama alanýnda saklanýrlar ve bu alanlarýn OS veya browserdaki baþka bir uygulama tarafýndan eriþilemediði garanti edilemez. Yani burada bir güvenlik açýðý kolayca doðabilir. OAuth, bu güvenlik açýðýný önlemek için geliþtirilen bir standarttýr.

# OAuth Standardýnýn Bileþenleri
4 temel bileþeni vardýr:

1. **Resource Owner**: Korunan bir kaynaða (dosyaya veya hizmete) eriþim verme yetkisini elinde tutan bileþen. Çoðu senaryoda aslýnda "User/end-user"a karþýlýk gelir. 

2. **Resource Server**: Korunan kaynaklarý (dosya ve hizmetleri) bünyesinde barýndýran ve kullaným request'lerine yanýt veren sunucudur.

3. **Client**: User'ýn yetkilendirmesi dahilinde kaynaklarý kullanan uygulamalardýr.
Birden çok uygulamanýn barýndýrýldýðý bir tarayýcýda ya da iþletim sistemi üzerinde çalýþan uygulamalar "**public client**" olarak adlandýrýlýr. Kendi güvenliðini saðlayabilen server üzerinde çalýþan uygulamlara ise "**confidential client**" adý verilir.

4. **Authorization Server**: Kaynaklara eriþim talep eden uygulamalarý ve user'larý doðrulamaktan sorumlu olan ve eriþim yetkisini kontrol eden sunucudur.
Yetkilendirme iþlemleri için token saðlamak ve token'leri yönetmekle sorumludur.





