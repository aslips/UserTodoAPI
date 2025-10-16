using Microsoft.EntityFrameworkCore;
using UserTodoAPI.Data;
// Uygulamanın iskeletini inşa etmeye başlıyoruz.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//Bu komut, projenin içindeki Controller'ları bulur
// ve onları dışarıdan gelecek istekleri dinlemeye hazırlar.

// DbContext ve SQLite ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=todo.db"));
// Bu en önemli adımlardan biridir. Burada iki şey yapıyoruz:
// a) AppDbContext'i sisteme bir "hizmet" olarak kaydediyoruz.
// b) Ona diyoruz ki: "Senin veritabanın bir SQLite dosyası olacak ve
//    dosyanın adı da 'todo.db' olacak."

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Bu iki satır, kullandığın Swagger arayüzünü oluşturur.
// Bu arayüz sayesinde kullanıcı ve todoları kolayca görürsün.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // "kullanıcılarla olan tüm konuşmaları şifreli yap!"
// Bu bir güvenlik önlemidir. HTTP yerine daha güvenli olan HTTPS kullanılmasını sağlar.

app.UseAuthorization(); // Bu satır, gelecekte "sadece kullanıcılar girebilir" gibi kurallar koymak
// istersen diye yetkilendirme sistemini devreye sokar.

app.MapControllers(); // Bu komut, Controller'lardaki adresleri ([Route("api/[controller]")]) aktif hale getirir.
// Artık "api/todo" adresine bir istek geldiğinde kimin bakacağı bellidir.

app.Run();
