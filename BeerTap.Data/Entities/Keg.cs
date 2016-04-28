using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTap.Data.Entities
{
    public class Keg
    {
        public Keg()
        {
        }

        public Keg(int id, string name, int max, int min)
        {
            Id = id;
            Name = name;
            MaxCapacity = max;
            MinCapacity = min;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int MinCapacity { get; set; }
    }
}
