using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloomAssignment.Models
{
   public class LocalItemsModel
    {
        [PrimaryKey][AutoIncrement]
        public int ItemId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FeaturedImage { get; set; }
    }
}
