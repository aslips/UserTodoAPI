**User-Todo API Projesi**

Bu proje, .NET 6 Web API kullanılarak geliştirilmiş basit bir Kullanıcı (User) ve Görev (Todo) yönetim sistemidir. Temel CRUD (Create, Read, Update, Delete) operasyonlarını içeren bu API, Entity Framework Core ile SQLite veritabanı üzerinde çalışmaktadır ve modern backend geliştirme prensiplerini sergilemek amacıyla oluşturulmuştur.

Özellikler

•	Kullanıcı Yönetimi (CRUD):
	◦	Yeni kullanıcı oluşturma
	◦	Tüm kullanıcıları listeleme
	◦	ID'ye göre tek bir kullanıcı getirme
	◦	Kullanıcı bilgilerini (isim, e-posta, şifre) güncelleme
	◦	Kullanıcı silme
  
•	Görev Yönetimi (CRUD):
	◦	Mevcut bir kullanıcıya yeni bir görev atama
	◦	Tüm görevleri, ilişkili kullanıcı bilgileriyle birlikte (JOIN) listeleme
	◦	ID'ye göre tek bir görevi, sahibi olan kullanıcıyla birlikte getirme
	◦	Bir görevin başlığını ve tamamlanma durumunu güncelleme
	◦	Görevi silme
  
•	API Dokümantasyonu:
	◦	Tüm API endpoint'lerinin test edilebilmesi için entegre Swagger arayüzü.

Kullanılan Teknolojiler
	•	Backend: C#, .NET 6
	•	API Framework: ASP.NET Core Web API
	•	ORM (Object-Relational Mapping): Entity Framework Core 6
	•	Veritabanı: SQLite
	•	API Test ve Dokümantasyon: Swagger (Swashbuckle)

Kurulum ve Çalıştırma
Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyebilirsiniz.
Projeyi Klonlayın: 
    git clone https://github.com/aslips/UserTodoAPI.git
		cd [UserTodoAPI]   
    
Gerekli .NET Paketlerini Yükleyin: Proje dizinindeyken aşağıdaki komutu çalıştırarak gerekli paketlerin indirildiğinden emin olun.  
    dotnet restore
    
Veritabanını Oluşturun: Entity Framework Core migrations kullanarak SQLite veritabanı dosyasını (todo.db) oluşturun.
    dotnet ef database update
    
!Eğer dotnet ef komutu çalışmazsa, önce global olarak kurmanız gerekebilir: 
    dotnet tool install --global dotnet-ef

Projeyi Çalıştırın:
    dotnet run

Swagger Arayüzüne Erişin: Uygulama çalıştırıldıktan sonra tarayıcınızdan aşağıdaki adrese giderek API'yi test etmeye başlayabilirsiniz: 
    https://localhost:7123/swagger (Port numarası sizde farklılık gösterebilir, terminalde yazan adresi kullanın.)
