namespace UserTodoAPI.Models
{
    public class Todo
    {
        public int Id { get; set; } // Otomatik artan ID
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int UserId { get; set; } // Bu görev kime ait
    // Bu da sadece müşteri numarasını değil, doğrudan müşterinin
    // kendisini (tüm bilgilerini) temsil eder.
    // Veritabanından bir "Todo" çekerken, bu sayede ona bağlı
    // olan "User" bilgilerini de kolayca çekebiliriz.
    // Buna da "Navigation Property" (Gezinme Özelliği) denir.
        public User? User { get; set; }
    }
}
