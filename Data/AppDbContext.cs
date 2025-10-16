using Microsoft.EntityFrameworkCore; 
// "Microsoft.EntityFrameworkCore", bu veritabanının tüm temel yeteneklerini (veritabanına bağlanma,
// veri ekleme, silme vb.) içerir.
using UserTodoAPI.Models;
// "UserTodoAPI.Models", veritabanının hangi şablonlarla (User ve Todo) çalışacağını
// bilmesi için gereklidir. Şablonlar olmadan neyi kaydedeceğini bilemez.
namespace UserTodoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!; // Bu satır, veritabanında "Users" adında bir tablo oluşturulmasını sağlar.
        public DbSet<Todo> Todos { get; set; } = null!;// Bu satır, veritabanında "Todos" adında bir tablo oluşturulmasını sağlar
    }
}
