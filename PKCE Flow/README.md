
# OAuth Nedir?
**Third party** uygulamalara, API'lar taraf�ndan baz� hizmetler sa�lan�r. Bu hizmetler temelde ikiye ayr�l�r: 
1. API sa�lay�c�s� uygulaman�n, User'lara sa�lad��� hizmetlerin third party bir uygulaman�n eri�imine sunmas�.
2. API sa�lay�c�s� uygulaman�n, kendi service'lerine eri�im sunmas�.    


Bu i�lemler esnas�nda uygulama isteklerinin esas client'tan geldi�ine emin olunmas� ihtiyac� do�maktad�r. ��nk�, bir i�letim sistemi �zerinde veya web browser �zerinde �al��an uygulamalar�n kimlik do�rulama bilgileri genel olarak eri�ilebilirdir. Bu tarz uygulamalar�n kimlik bilgileri kullan�c�lar�n cihaz belle�inde veya depolama alan�nda saklan�rlar ve bu alanlar�n OS veya browserdaki ba�ka bir uygulama taraf�ndan eri�ilemedi�i garanti edilemez. Yani burada bir g�venlik a���� kolayca do�abilir. OAuth, bu g�venlik a����n� �nlemek i�in geli�tirilen bir standartt�r.


# OAuth Standard�n�n Bile�enleri
4 temel bile�eni vard�r:

1. **Resource Owner**: Korunan bir kayna�a (dosyaya veya hizmete) eri�im verme yetkisini elinde tutan bile�en. �o�u senaryoda asl�nda "User/end-user"a kar��l�k gelir. 

2. **Resource Server**: Korunan kaynaklar� (dosya ve hizmetleri) b�nyesinde bar�nd�ran ve kullan�m request'lerine yan�t veren sunucudur.

3. **Client**: User'�n yetkilendirmesi dahilinde kaynaklar� kullanan uygulamalard�r.
Birden �ok uygulaman�n bar�nd�r�ld��� bir taray�c�da ya da i�letim sistemi �zerinde �al��an uygulamalar "**public client**" olarak adland�r�l�r. Kendi g�venli�ini sa�layabilen server �zerinde �al��an uygulamlara ise "**confidential client**" ad� verilir.

4. **Authorization Server**: Kaynaklara eri�im talep eden uygulamalar� ve user'lar� do�rulamaktan sorumlu olan ve eri�im yetkisini kontrol eden sunucudur.
Yetkilendirme i�lemleri i�in token sa�lamak ve token'leri y�netmekle sorumludur.


# OAuth 2.0 Farkl� Yetkilendirme Ak��lar�

OAuth 2.0, farkl� senaryolara ve kullan�m durumlar�na g�re �e�itli yetkilendirme ak��lar� (authorization flows) sunar. 

**Authorization Code Ak��� (Authorization Code Flow)**: Bu ak��, g�venli ve �nerilen ak��t�r ve OAuth 2.0'nin temelini olu�turur. �stemci, kullan�c�y� yetkilendirmek i�in authorization server'a y�nlendirir. Kullan�c� kimlik do�rulamas� yapt�ktan sonra, authorization server, istemciye bir yetkilendirme kodu verir. �stemci daha sonra yetkilendirme kodunu kullanarak authorization server'dan eri�im tokeni al�r.

**Implicit Ak�� (Implicit Flow)**: Bu ak��, basit ve h�zl� bir yetkilendirme ak���d�r, ancak daha d���k bir g�venlik seviyesine sahiptir. �stemci, kullan�c�y� do�rudan authorization server'a y�nlendirir ve kullan�c� kimlik do�rulamas� yapt�ktan sonra authorization server, eri�im tokenini do�rudan istemciye verir.

**Resource Owner Password Credentials Ak��� (Resource Owner Password Credentials Flow)**: Bu ak��, g�venli�in daha d���k oldu�u durumlarda kullan�lan bir ak��t�r. �stemci, kullan�c�n�n do�rudan kullan�c� ad� ve parolas�n� kullanarak authorization server'a yetkilendirme iste�i yapar ve eri�im tokenini al�r. Bu ak��, istemcinin kullan�c� ad� ve parolay� do�rudan almas� gerekti�i durumlarda (�rne�in, g�venli bir mobil uygulamada) kullan�labilir.

**Client Credentials Ak��� (Client Credentials Flow)**: Bu ak��, istemcinin (client) kimlik bilgilerini kullanarak authorization server'dan do�rudan eri�im tokeni almas�n� sa�lar. Bu ak��, kullan�c� etkile�imi olmadan istemcinin kendi ad�na kaynak sunucusuna eri�mesini gerektiren durumlarda kullan�l�r.

# OAuth 2.0 Standard�n�n Ak���

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
Client, Resource Owner'dan yetkilendirme talebi ister. Request, HTTP GET iste�i olarak yap�l�r. Bu request, do�rudan �ekilde g�sterildi�i gibi Resource Owner'a yap�labildi�i gibi dolayl� yoldan, Authorization Server'a request at�larak da yap�labilir. (Spotify hesab�n�z� ba�ka bir uygulamaya ba�lamak istedi�inizde, size uygulaman�n eri�im istedi�i kaynaklar hakk�nda bilgi verip 'Onayl�yor musunuz?' diye sorar.)

Request ��eri�i:

**response_type***: Authorization Server'dan hangi response tipinin istendi�i belirtilir. "code" de�eri authorization code ak���n�, "token" de�eri implicit ak���n� temsil eder. Implicit ak�� eri�im token'ini do�rudan almay� sa�layan ba�ka bir ak��t�r. Daha h�zl�d�r ancak g�venlik a��s�ndan risklidir.

**client_id**: Client kimlik bilgisini temsil eder. Bu id, uygulaman�n API kullan�m� i�in kaydoldu�u anda Authorization Server taraf�ndan Client'a verilmi�tir.

**redirect_uri**: Client'�n yetkilendirme sonucunu alaca�� callback URL'sini temsil eder. Authorization server, yetkilendirme sonucunu bu URL'ye g�nderecektir. Client kay�t olurken bunu da daha �nceden belirtmi� olmal�d�r.

**scope**: Client kay�t olurken API'�n hangi hizmetlerinden/kaynaklardan faydalanaca��n� belirtmek zorundad�r. Bu parametre do�rultuda Client'�n yetkileri kontrol alt�na al�n�r.

**state**: G�venlik nedenleriyle kullan�lan bir de�erdir. Rastgele olarak client taraf�ndan �retilir. Cross-Site Request Forgery (CSRF) sald�r�lar�na kar�� koruma sa�lamak i�in kullan�l�r.
Authorization Response al�nd���nda, istemci state de�erini kontrol eder ve Authorization Request s�ras�nda g�nderilen state de�eriyle e�le�ti�inden emin olur. Bu, istemcinin Authorization Response'un ge�erli bir yan�t oldu�unu do�rulamas�na yard�mc� olur ve potansiyel bir CSRF sald�r�s�n� engeller. E�le�meyen veya bo� bir state de�eri, istemcinin Authorization Response'u reddetmesine veya i�leme almamas�na yol a�abilir.


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