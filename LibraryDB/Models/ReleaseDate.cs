using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDB.Models
{
    [Table("ReleaseDates")]
    public class ReleaseDate
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime RlsDate { get; set; }
    }
}
