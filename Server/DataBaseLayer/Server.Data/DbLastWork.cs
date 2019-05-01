
namespace Server.Data
{
    public class DbLastWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Experience { get; set; }
        public DbEmployee Employee { get; set; }
    }
}
