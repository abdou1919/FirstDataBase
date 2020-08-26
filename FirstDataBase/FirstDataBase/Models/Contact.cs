﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FirstDataBase.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }

        
        public string Magazzino { get; set; }
        public DateTime Date { get; set; }
    }
}
