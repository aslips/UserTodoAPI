using Microsoft.AspNetCore.Mvc;
using UserTodoAPI.Data;
using UserTodoAPI.Models;


namespace UserTodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context; //Bu AppDbContext olan özel erişim kartıdır. Bu olmadan veri alıp veremez.

        public UserController(AppDbContext context)
        {
            _context = context; // Veritabanı bağlantısı için DbContext alıyoruz
        }

        // GET: api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList(); // Tüm kullanıcıları listele
            return Ok(users); // HTTP 200 ile geri döndür
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id); // ID’ye göre kullanıcı bul
            if (user == null) return NotFound(); // Bulamazsa 404 döndür
            return Ok(user); // Kullanıcıyı döndür
        }

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _context.Users.Add(user); // Yeni kullanıcı ekle
            _context.SaveChanges(); // Değişiklikleri kaydet
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user); // HTTP 201 ve kullanıcıyı döndür
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _context.Users.Find(id); // Güncellenecek kullanıcıyı bul
            if (user == null) return NotFound(); // Yoksa 404 döndür

            user.Name = updatedUser.Name; // Adını güncelle
            user.Email = updatedUser.Email; // Emailini güncelle
            user.Password = updatedUser.Password; // Şifreyi güncelle

            _context.SaveChanges(); // Değişiklikleri kaydet
            return NoContent(); // Başarılı ama veri döndürme (HTTP 204)
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id); // Silinecek kullanıcıyı bul
            if (user == null) return NotFound(); // Yoksa 404 döndür

            _context.Users.Remove(user); // Kullanıcıyı sil
            _context.SaveChanges(); // Değişiklikleri kaydet
            return NoContent(); // Başarılı ama veri döndürme (HTTP 204)
        }
    }
}
