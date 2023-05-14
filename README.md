# Endless Runner 

- Bu proje iş görüşmesi için case çalışması olarak yapılmıştır.

- Oyunu basitçe açıklamak gerekirse bu bir endless runner yani sonu gelmeyen bir yol ve rastgele çıkan engellerden oluşan bir oyundur.

- Oyunun amacı engellere çarpmadan sürekli olarak koşmaya devam etmektedir.

## Oynayış

<img src="https://github.com/Sefa4177/EndlessRunnerCP/blob/main/Screenshot_2023-05-14-16-49-21-915_com.SCPGaming.EndlessRunnerCP.jpg" width="auto">

- Oyunda Hareketler Sağ, Sol ve Üst Swipe (yani parmak kaydırma) hareketi ile olmaktadır.

- Oyuna başlandığında karakterimiz otomatik ve sürekli olarak ileri doğru koşmaya başlar ve bu koşma hızı sürekli olarak her saniye hızın %1'i oranında artar.

- Oyunda hareket kodları konusunda bir çok deneme yapıp, hareket kodlarını 4 kere baştan yazdıktan sonra  Lane mantığını kullanmaya karar verdim yani karakter oyuna orta lane de başlar ve sağ ve sol swipe ile sağ ve sol Lane'e geçebilir bu şekilde oyunun oynanışı daha güzel oldu ve bu Lane geçişlerini belli bir hızda yaparak anlık geçişler değilde daha yumusak sanki kayak yaparken yapılan zikzak hareketleri tadında yaparak hareketi daha da güzelleştirdim bu şekilde oynayan kişiye engellerden kacabilmek için daha fazla özgürlük vermiş oldum.

- Karakter ilerledikçe önündeki yol sürekli olarak devam eder ve önüne çıkan engeller random pozisyonlarda olur.

- Karakter bu engellerden yanlara kayarak veya zıplayarak kaçabilir.

- Oyun, karakter bir engele çarpana kadar devam eder ve karakter engele çarptığında oynayan kişinin puanını ve kazandığı puana göre bir yıldız sayısı ekrana belirir ve oyuncunun oyuna tekrar başlayabilmesi için "Play Again" butonu bu ekranda yer alır.

- Play Again butonuna basılır ise oyun en baştan başlar karakterin hızı başlangıç hızına dönmüş olur.

  

## Optimizasyon

Optimizasyon için yaptığım şeyler şunlar :

- Mümkün olduğunca script ve kod sayısını düşürdüm.

- Kodumda mümkün olduğunca herşeyi method haline getirip sadece gerekli şeyleri update, fixedUpdate gibi methodlarin içine ekledim.

- Oyundaki standart ve bu oyun için gereksiz olan: Gölgelerin kalitesini düşürdüm, Texture kalitelerini düşürdüm, Gökyüzü için skybox yerine solid color kullandım ve daha bir çok görüntü ayarını bu oyun için gereksiz olduğu için kıstım.

- Oyundaki sonsuz yolları ve engelleri sürekli olarak oluşturup silmek yerine object pooling yönteminin ana prensibini benimseyerek birazda kendi yorumumu kattım ve bu mekaniği şu şekilde yaptım : 

    - Oyunda toplamda iki parça yol ve üzerinde belirli sayıda engel var. Ve Her yolun bitiminin biraz ilerisinde bir tetikleyici box collider bulunuyor. Karakter ileri doğru koştukça ve tetikleyici colliderın içinden geçtiğinde arkada kalan yol şuan üzerinde bulunduğumuz yolun ileri ucuna transform.position u kullanılarak ekleniyor ve bu eklenme sırasında üzerindeki engellerin yeri random olarak değişiyor bu şekilde sürekli obje klonlayıp ve sürekli destroy ederek uzun vadede işlemciyi yormamış oluyoruz oyun ne kadar oynansa da oyundaki obje sayısı her zaman sabit oluyor sadece yerleri değişmiş oluyor.
