using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDB.Models
{
    [Table("Books")]
    public class Book
    {
            [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Editorial { get; set; }
        public string Description { get; set; }
        public string Autor { get; set; }

        [ForeignKey(typeof(ReleaseDate))]
        public int FKReleaseDateId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public ReleaseDate ReleaseDate { get; set; }

    }
}
