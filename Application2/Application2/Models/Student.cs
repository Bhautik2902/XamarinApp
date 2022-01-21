using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Application2.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public int std { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
