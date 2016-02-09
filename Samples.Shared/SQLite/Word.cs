using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace Samples.Shared.SQLite
{
    [Table("Word")]
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Value { get; set; }

        public string SubHeading { get; set; }

        public string ImageName { get; set; }


        public int SectionId { get; set; }
    }
}
