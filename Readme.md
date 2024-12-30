# Restaurant Sistemi

Bu README dosyası, restoran siparişlerini yönetmek için tasarlanmış bir restoran yönetim sistemi uygulamasının kodunu açıklamaktadır. Uygulama, Nesne Yönelimli Programlama (OOP) ilkelerini ve Bağımlılık Ters çevirme Prensibi'ni (DIP) kullanarak yazılmıştır.

## Nesne Yönelimli Programlama (OOP) İlkeleri

*   **Sınıflar (Classes):** Kodumuzda `MenuItem`, `food_class`, `drink_class`, ve `Order` olmak üzere birden fazla sınıf kullanırız. Her sınıf, restoran sipariş sistemindeki belirli bir kavramı temsil eder.
*   **Nesneler (Objects):** Sınıflar birer şablondur, nesneler ise bu şablonlardan oluşturulan örneklerdir. Örneğin, `food_class` sınıfından bir nesne oluşturduğumuzda, belirli bir yemeğin adını, fiyatını, malzemelerini vb. bilgileri içeren bir "yemek" nesnesi oluştururuz.
*   **Miras (Inheritance):** `food_class` ve `drink_class` sınıfları `MenuItem` sınıfından miras alır. Bu sayede, tüm menü öğeleri ortak özellikleri `MenuItem` sınıfında tutarken, `food_class` ve `drink_class` sınıfları yiyecek ve içeceğe özgü özellikleri tanımlayabilir.
*   **Polimorfizm (Polymorphism):** `MenuItem` sınıfında tanımlanan `DisplayDetails()` metodu soyuttur (`abstract`). Bu sayede, `food_class` ve `drink_class` sınıfları, kendilerine özgü bilgileri görüntüleyen kendi `DisplayDetails()` metodlarını yazabilir.

## Bağımlılık Ters çevirme Prensibi (DIP)

Uygulamamızda DIP prensibini, yüksek seviyeli modüllerin düşük seviyeli modüllere değil, soyutlamalara bağımlı olması prensibini uygulayarak kullanırız. Örneğin, `Order` sınıfı, siparişe eklenen öğeleri bir `List<MenuItem>` ile tutar. Bu sayede, `Order` sınıfı yemek ve içecek sınıflarının ayrıntılarına bağımlı olmaz, sadece bir menü öğesi olduğunu bilir. Böylece, gelecekte farklı menü öğesi türleri eklenirse, `Order` sınıfını değiştirmeye gerek kalmaz.

## Komut Satırı Arayüzü (CLI) Kullanım Örnekleri

*   **Programı çalıştırmak:** Uygulamayı çalıştırmak için komut satırında `dotnet run` komutunu kullanabilirsiniz.
*   **Öğrenci indirimi:** Program başlatıldığında, öğrenci olup olmadığınızı sorar. "evet" derseniz, tüm yemeklere %20 indirim uygulanır.
*   **Menü öğeleri eklemek:** "1. Yiyecek Ekle" veya "2. İçecek Ekle" seçeneklerini kullanarak siparişinize yiyecek ve içecek ekleyebilirsiniz.
*   **Sipariş görüntüleme:** "3. Sipariş Göster" seçeneği ile siparişinizdeki tüm öğeleri görebilirsiniz.
*   **Sipariş türüne göre görüntüleme:** "4. Sipariş Türüne Göre Görüntüle" seçeneği ile siparişinizi yiyecek ve içecek olarak ayrılmış şekilde görebilirsiniz.
*   **Öğe arama:** "5. Öğe Ara" seçeneği ile siparişinizde belirli bir öğeyi arayabilirsiniz.
*   **Siparişten öğe çıkarmak:** "6. Öğe Çıkar" seçeneğini kullanarak siparişinizden bir öğe kaldırabilirsiniz.
*   **En çok satın alınan ürünleri görüntüleme:** "7. En Çok Satın Alınan Ürünler" seçeneği ile en çok sipariş edilen ürünleri görebilirsiniz.
*   **Toplam sipariş fiyatı hesaplama:** "8. Toplam Hesapla" seçeneği ile öğrenci indirimi uygulanmış (eğer öğrenciyseniz) toplam sipariş fiyatını hesaplayabilirsiniz.
*   **Programdan çıkış:** "9. Çıkış" seçeneği ile programı sonlandırabilirsiniz.

## Sonuç

Bu restoran yönetim sistemi uygulaması, OOP ilkelerini ve DIP prensibini kullanarak yazılmıştır. Bu sayede, kod okunaklı, esnek ve bakımı kolaydır. Komut satırı arayüzü ile kullanıcılar siparişlerini kolayca oluşturabilir ve yönetebilir.