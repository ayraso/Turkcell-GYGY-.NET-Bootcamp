```JavaScript
var ctx = canvas.getContext("2d");
```
Bir canvas html elementi için 2D çizim bağlamı oluşturur.

## Farklı çizim bağlamları
-**2d**: 2 boyutlu çizimler ve grafikler için kullanılır.

-**webgl**: 3 boyutlu grafikler ve animasyonlar için kullanılır. Bu bağlam, OpenGL ES 2.0 standardını kullanır.

-**webgl2**: WebGL 2.0 standardına dayanan gelişmiş bir 3 boyutlu çizim bağlamıdır.

-**bitmaprenderer**: Bir bitmap grafikleri bağlamıdır. Bu bağlam, bir "ImageBitmap" nesnesini çizmek veya örneklemek için kullanılabilir.

```JavaScript
ctx.rect(20, 40, 50, 50);
```
*parametre 1:*(20)      dikdörtgenin **sol üst köşesinin x** koordinatı
*parametre 2:*(40)      dikdörtgenin **sol üst köşesinin y** koordinatı
*parametre 3:*(50)      dikdörtgenin **genişliği**
*parametre 4:*(50)      dikdörtgenin **yüksekliği**

```JavaScript
ctx.arc(240, 160, 20, 0, Math.PI * 2, false)
```
*parametre 1:*(240)             dairenin merkezinin x koordinatı
*parametre 2:*(160)             dairenin merkezinin y koordinatı
*parametre 3:*(20)              dairenin yarıçapı
*parametre 4:*(0)               dairenin başlangıç açısı, radyan cinsinden. 0,  x-ekseni yönünde olan pozitif yönle aynı hizadaki konumu ifade eder.
*parametre 5:*(Math.PI * 2):    dairenin bitiş açısı, radyan cinsinden. Math.PI * 2, tam bir daireyi ifade eder (360 derece).
*parametre 6:*(false)           dairenin çizilme yönü. Saat yönünde çizmek için true, saat yönünün tersine çizmek için false değeri kullanılır.
##
