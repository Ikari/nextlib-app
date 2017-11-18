using SQLite;

namespace NextLibApp
{
    public class Book
    {

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
