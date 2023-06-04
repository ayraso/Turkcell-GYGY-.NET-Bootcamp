
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





