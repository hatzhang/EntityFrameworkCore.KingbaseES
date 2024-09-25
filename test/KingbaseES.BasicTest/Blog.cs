using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KingbaseES.BasicTest
{
    [Table("blogs")]
    public class Blog
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public BlogType BlogType { get; set; }
    }

    public enum BlogType
    {
        Personal,
        Company
    }

    public class BlogFilter
    {
        public BlogType[] Type { get; init; }
    }
}
