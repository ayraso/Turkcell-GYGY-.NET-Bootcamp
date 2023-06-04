
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


# OAuth 2.0 Protokol Ak���

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


**A**. Client, Resource Owner'dan yetkilendirme talebi ister. Request, HTTP GET iste�i olarak yap�l�r. 
��eri�i:
**response_type***: Authorization Server'dan hangi response tipinin istendi�i belirtilir. "code" de�eri authorization code ak���n�, "token" de�eri implicit ak���n� temsil eder.

**client_id**: Client kimlik bilgisini temsil eder. Bu id, uygulaman�n API kullan�m� i�in kaydoldu�u anda Authorization Server taraf�ndan Client'a verilmi�tir.

**redirect_uri**: Client'�n yetkilendirme sonucunu alaca�� callback URL'sini temsil eder. Authorization server, yetkilendirme sonucunu bu URL'ye g�nderecektir. Client kay�t olurken bunu da daha �nceden belirtmi� olmal�d�r.

**scope**: Client kay�t olurken API'�n hangi hizmetlerinden/kaynaklardan faydalanaca��n� belirtmek zorundad�r. Bu parametre do�rultuda Client'�n yetkileri kontrol alt�na al�n�r.

**state**: G�venlik nedenleriyle kullan�lan bir de�erdir. Rastgele olarak client taraf�ndan �retilir. Cross-Site Request Forgery (CSRF) sald�r�lar�na kar�� koruma sa�lamak i�in kullan�l�r.
Authorization Response al�nd���nda, istemci state de�erini kontrol eder ve Authorization Request s�ras�nda g�nderilen state de�eriyle e�le�ti�inden emin olur. Bu, istemcinin Authorization Response'un ge�erli bir yan�t oldu�unu do�rulamas�na yard�mc� olur ve potansiyel bir CSRF sald�r�s�n� engeller. E�le�meyen veya bo� bir state de�eri, istemcinin Authorization Response'u reddetmesine veya i�leme almamas�na yol a�abilir.


**B**. 

**C**.

**D**.

**E**.

**F**.