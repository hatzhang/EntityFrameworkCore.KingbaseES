﻿using System.ComponentModel.DataAnnotations;
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
        public DateTime CreatedDateTime { get; set; }

        public Author Author { get; set; }


    }

    public class Author
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public DateTime BirthTime { get; set; }
    }
}
