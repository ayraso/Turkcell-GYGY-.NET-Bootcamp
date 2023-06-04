
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


# OAuth 2.0 Farklý Yetkilendirme Akýþlarý

OAuth 2.0, farklý senaryolara ve kullaným durumlarýna göre çeþitli yetkilendirme akýþlarý (authorization flows) sunar. 

**Authorization Code Akýþý (Authorization Code Flow)**: Bu akýþ, güvenli ve önerilen akýþtýr ve OAuth 2.0'nin temelini oluþturur. Ýstemci, kullanýcýyý yetkilendirmek için authorization server'a yönlendirir. Kullanýcý kimlik doðrulamasý yaptýktan sonra, authorization server, istemciye bir yetkilendirme kodu verir. Ýstemci daha sonra yetkilendirme kodunu kullanarak authorization server'dan eriþim tokeni alýr.

**Implicit Akýþ (Implicit Flow)**: Bu akýþ, basit ve hýzlý bir yetkilendirme akýþýdýr, ancak daha düþük bir güvenlik seviyesine sahiptir. Ýstemci, kullanýcýyý doðrudan authorization server'a yönlendirir ve kullanýcý kimlik doðrulamasý yaptýktan sonra authorization server, eriþim tokenini doðrudan istemciye verir.

**Resource Owner Password Credentials Akýþý (Resource Owner Password Credentials Flow)**: Bu akýþ, güvenliðin daha düþük olduðu durumlarda kullanýlan bir akýþtýr. Ýstemci, kullanýcýnýn doðrudan kullanýcý adý ve parolasýný kullanarak authorization server'a yetkilendirme isteði yapar ve eriþim tokenini alýr. Bu akýþ, istemcinin kullanýcý adý ve parolayý doðrudan almasý gerektiði durumlarda (örneðin, güvenli bir mobil uygulamada) kullanýlabilir.

**Client Credentials Akýþý (Client Credentials Flow)**: Bu akýþ, istemcinin (client) kimlik bilgilerini kullanarak authorization server'dan doðrudan eriþim tokeni almasýný saðlar. Bu akýþ, kullanýcý etkileþimi olmadan istemcinin kendi adýna kaynak sunucusuna eriþmesini gerektiren durumlarda kullanýlýr.

# OAuth 2.0 Standardýnýn Akýþý

     +--------+                               +---------------+
     |        |--(A)- Authorization Request ->|   Resource    |
     |        |                               |     Owner     |
     |        |<-(B)-- Authorization Grant ---|               |
     |        |                               +---------------+
     |        |
     |        |                               +---------------+
     |        |--(C)-- Authorization Grant -->| Authorization |
     | Client |                               |     Server    |
     |        |<-(D)----- Access Token -------|               |
     |        |                               +---------------+
     |        |
     |        |                               +---------------+
     |        |--(E)----- Access Token ------>|    Resource   |
     |        |                               |     Server    |
     |        |<-(F)--- Protected Resource ---|               |
     +--------+                               +---------------+


#### (**A**)
Client, Resource Owner'dan yetkilendirme talebi ister. Request, HTTP GET isteði olarak yapýlýr. Bu request, doðrudan þekilde gösterildiði gibi Resource Owner'a yapýlabildiði gibi dolaylý yoldan, Authorization Server'a request atýlarak da yapýlabilir. (Spotify hesabýnýzý baþka bir uygulamaya baðlamak istediðinizde, size uygulamanýn eriþim istediði kaynaklar hakkýnda bilgi verip 'Onaylýyor musunuz?' diye sorar.)

Request Ýçeriði:

**response_type***: Authorization Server'dan hangi response tipinin istendiði belirtilir. "code" deðeri authorization code akýþýný, "token" deðeri implicit akýþýný temsil eder. Implicit akýþ eriþim token'ini doðrudan almayý saðlayan baþka bir akýþtýr. Daha hýzlýdýr ancak güvenlik açýsýndan risklidir.

**client_id**: Client kimlik bilgisini temsil eder. Bu id, uygulamanýn API kullanýmý için kaydolduðu anda Authorization Server tarafýndan Client'a verilmiþtir.

**redirect_uri**: Client'ýn yetkilendirme sonucunu alacaðý callback URL'sini temsil eder. Authorization server, yetkilendirme sonucunu bu URL'ye gönderecektir. Client kayýt olurken bunu da daha önceden belirtmiþ olmalýdýr.

**scope**: Client kayýt olurken API'ýn hangi hizmetlerinden/kaynaklardan faydalanacaðýný belirtmek zorundadýr. Bu parametre doðrultuda Client'ýn yetkileri kontrol altýna alýnýr.

**state**: Güvenlik nedenleriyle kullanýlan bir deðerdir. Rastgele olarak client tarafýndan üretilir. Cross-Site Request Forgery (CSRF) saldýrýlarýna karþý koruma saðlamak için kullanýlýr.
Authorization Response alýndýðýnda, istemci state deðerini kontrol eder ve Authorization Request sýrasýnda gönderilen state deðeriyle eþleþtiðinden emin olur. Bu, istemcinin Authorization Response'un geçerli bir yanýt olduðunu doðrulamasýna yardýmcý olur ve potansiyel bir CSRF saldýrýsýný engeller. Eþleþmeyen veya boþ bir state deðeri, istemcinin Authorization Response'u reddetmesine veya iþleme almamasýna yol açabilir.


#### (**B**) 

#### (**C**)

#### (**D**)

#### (**E**)

#### (**F**)



# Authorization Code Interception Attack

    +~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+
    | End Device (e.g., Smartphone)  |
    |                                |
    | +-------------+   +----------+ | (6) Access Token  +----------+
    | |Legitimate   |   | Malicious|<--------------------|          |
    | |OAuth 2.0 App|   | App      |-------------------->|          |
    | +-------------+   +----------+ | (5) Authorization |          |
    |        |    ^          ^       |        Grant      |          |
    |        |     \         |       |                   |          |
    |        |      \   (4)  |       |                   |          |
    |    (1) |       \  Authz|       |                   |          |
    |   Authz|        \ Code |       |                   |  Authz   |
    | Request|         \     |       |                   |  Server  |
    |        |          \    |       |                   |          |
    |        |           \   |       |                   |          |
    |        v            \  |       |                   |          |
    | +----------------------------+ |                   |          |
    | |                            | | (3) Authz Code    |          |
    | |     Operating System/      |<--------------------|          |
    | |         Browser            |-------------------->|          |
    | |                            | | (2) Authz Request |          |
    | +----------------------------+ |                   +----------+
    +~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~+







# OAuth 2.0 PKCE 

                                                 +-------------------+
                                                 |   Authz Server    |
       +--------+                                | +---------------+ |
       |        |--(A)- Authorization Request ---->|               | |
       |        |       + t(code_verifier), t_m  | | Authorization | |
       |        |                                | |    Endpoint   | |
       |        |<-(B)---- Authorization Code -----|               | |
       |        |                                | +---------------+ |
       |        |                                |                   |
       |        |                                | +---------------+ |
       |        |--(C)-- Access Token Request ---->|               | |
       | Client |          + code_verifier       | |    Token      | |
       |        |                                | |   Endpoint    | |
       |        |<-(D)------ Access Token ---------|               | |
       |        |                                | +---------------+ |
       |        |                                +-------------------+
       |        |
       |        |                                  +---------------+
       |        |--(E)----- Access Token --------->|    Resource   |
       |        |                                  |     Server    |
       |        |<-(F)--- Protected Resource ----->|               |
       +--------+                                  +---------------+