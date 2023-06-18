# Proje Genel Bakışı

Bu projenin çerçevesi bir Finite State Machine (FSM) üzerinde oluşturulmuştur. FSM temel bir yazılım tasarım modeli olup, bu proje dahilinde belirli noktalarda kullanılmıştır. Not edilmesi gereken, bu implementasyonda tam bir FSM entegrasyonu bulunmamaktadır; projede yalnızca enter ve exit transitionlarından faydalanılmıştır.

Projenin çekirdek elemanlarından biri olan FSM sınıfı, (state) yönetimini üstlenirken, State sınıfı ise bir abstract class olarak tanımlanmıştır. Bu yapı sayesinde, state sıralamaları kolaylıkla değiştirilebilir ve statelere yeni özellikler eklenebilir veya mevcut özellikler çıkarılabilir. Her bir state için özel işlemler tanımlanabilir; yalnızca giriş ve çıkış koşullarının belirlenmesi gereklidir.

Proje genelinde, Unity objeleri arasında çapraz bağlantıların kullanılmasından kaçınılmıştır. Bunun yerine, haberleşmeler için event-based bir sistem oluşturulmuştur. Event yönetimi için ScriptableObject kullanılmıştır. Ek olarak, proje 9:16 aspect ratio'ya göre tasarlanmıştır ve kamera ayarları bu orana uygundur.

## Yeni Bir State Ekleme Süreci
Yeni bir state eklenecekse, aşağıdaki adımlar takip edilmelidir:

- State sınıfından türetilmiş bir sınıf oluşturulmalıdır.
- Oluşturulan bu sınıf, FSM sınıfındaki state listesine eklenmelidir.
- Bu sınıftaki Enter ve Exit metodları override edilmelidir.
- State tamamlandığında, FSM sınıfındaki NextState metodu çağırılmalıdır.

## Optimizasyon Stratejileri
Projenin performansını artırmak için bazı optimizasyon stratejileri uygulanmıştır:

- Level içerisindeki objelerden bir kısmı statik olarak işaretlenmiştir.
- 'PaintCheck' isminde bir sınıf oluşturulmuştur. Bu sınıf, çizimin ne kadarının tamamlandığını kontrol eder ve burası Jobs+Burst ile optimize edilebilir.
