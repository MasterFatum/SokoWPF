namespace BLL.Entities
{
    public class Courses
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? Evaluation { get; set; }

    }
}