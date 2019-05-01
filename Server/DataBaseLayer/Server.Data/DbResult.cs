
namespace Server.Data
{
    public class DbResult
    {
        public int Id { get; set; }
        public int? Test { get; set; }
        public string Result1 { get; set; }
        public DbEmployee Employee { get; set; }
        public DbVacancy Vacancy { get; set; }
    }
}
