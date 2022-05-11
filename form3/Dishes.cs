using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace form3
{
    public class Dishes
    {
        public string Name { get; set; }


        public double Price { get; set; } = 0;


        public int Count { get; set; } = 0;
    }
}
