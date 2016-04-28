using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTap.Data.Entities
{
    public class Office
    {
        public Office()
        {
        }

        public Office(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
