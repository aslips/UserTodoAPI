namespace UserTodoAPI.Models
{
    public class User
    {
        public int Id { get; set; } //Otomatik artan ID
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public string? Password { get; set; }
    // BU KISIM ÇOK ÖNEMLİ:
    // Bu, kullanıcıya ait tüm görevlerin listesidir.
    // Her kullanıcı kendine ait bir todo listesi oluşturabilir.
    // "= new List<Todo>()" ifadesi, yeni bir user kaydı oluşturulduğunda
    // bu todo listesinin boş olarak başlamasını sağlar.
        public List<Todo> Todos {get; set;} = new List<Todo>();
    }
}