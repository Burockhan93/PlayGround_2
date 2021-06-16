Kisaca surda bir bakalm Gizmos nasil yapilir nedir?

Bunlar aslinda sadece görsel referasn birsey yapmiolar. Isiklarin gösterimi gizmodur, herhangi boir sekil veya meshlerin kenari gibi hersey gizmodur. Bos gameObjectlerin nerde oldugunu görmek icin birebir uygulama.

Bütün Gizmolar OnDrawgizmos metodunun icinde olmak zorunda.
veyA OndrawGizms Selected . Bu da sahnede sectigin zaman bir objeyi calisio.

Gizmo ciziildikten sonra gizmoya tiklayip bagli olan nesneyi secebilioz.

Bunu da TipsandTrick icine yazacam UIeventsteki.

static propertiler : Gizmos.Color, Gizmos.exposure, gizmos.matrix, Gizmos.probesize

sirasiyla rengi, ? , nesnenin transform bilgisini gloabele tasimak icin kullanilan matrix :Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, Vector3.one); , ve ?


Asagi yukari tüm kodlar ayni calisio.

void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

Gizmos.DrawFrustum(Camera.main.transform.position, 1, 100, 1, 1); kameranin saheneye bakisini cizio

DrawGUITexture resim atio Canvasa

DrawIcon icon atio tiff formatinda. ama bende niyeyse beyaz kagit cizdi

DrawLine bir hedefe ray gibi atio bit cizgi

Drawmeshe e bir palmiye koyduk

Draw Ray bir isin üretip atiyor boyu falan olmasi layim bnu yazmadm

DrawSphere(transform.position, 1);

Bunlar bir de Wirela yazilabilio.







