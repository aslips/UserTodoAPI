using Microsoft.AspNetCore.Mvc;
using UserTodoAPI.Data;
using UserTodoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UserTodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context; // Veritabanı bağlantısı için DbContext alıyoruz
        }

        // GET: api/todo
        [HttpGet]
        public IActionResult GetTodos()
        {
            // Tüm görevleri ve ilişkili kullanıcıyı getiriyoruz
            var todos = _context.Todos.Include(t => t.User).ToList();
            return Ok(todos); // HTTP 200 ile geri döndür
        }

        // GET: api/todo/{id} 
        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            // ID’ye göre görevi bul ve kullanıcıyla birlikte getir
            var todo = _context.Todos.Include(t => t.User).FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound(); // Bulamazsa 404 döndür
            return Ok(todo); // Görevi döndür
        }

        // POST: api/todo 
        [HttpPost]
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            // Görevi eklemeden önce kullanıcı var mı kontrol et
            var user = _context.Users.Find(todo.UserId);
            if (user == null)
            {
                return BadRequest("User not found."); // Kullanıcı yoksa 400 döndür
            }

            todo.User = user; // Görevi kullanıcıyla ilişkilendir
            _context.Todos.Add(todo); // Yeni görev ekle
            _context.SaveChanges(); // Değişiklikleri kaydet

            // HTTP 201 ve eklenen görevi döndür
            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }

        // PUT: api/todo/{id} 
        [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, [FromBody] Todo updatedTodo)
        {
            var todo = _context.Todos.Find(id); // Güncellenecek görevi bul
            if (todo == null) return NotFound(); // Yoksa 404 döndür

            todo.Title = updatedTodo.Title; // Başlığı güncelle
            todo.IsCompleted = updatedTodo.IsCompleted; // Durumu güncelle

            _context.SaveChanges(); // Değişiklikleri kaydet
            return NoContent(); // Başarılı ama veri döndürme (HTTP 204)
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _context.Todos.Find(id); // Silinecek görevi bul
            if (todo == null) return NotFound(); // Yoksa 404 döndür

            _context.Todos.Remove(todo); // Görevi sil
            _context.SaveChanges(); // Değişiklikleri kaydet
            return NoContent(); // Başarılı ama veri döndürme (HTTP 204)
        }
    }
}
