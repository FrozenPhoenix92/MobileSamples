﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace Samples.Shared.SQLite
{
    [Table("Section")]
    public class Section
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
