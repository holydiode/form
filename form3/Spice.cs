using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form3
{


    public class Spice
    {


        [Display(Name = "Наименование")]
        public string Name { get; set; }           

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Остаток в начале")]
        public double Start { get; set; }

        [Display(Name = "Поступило")]
        public double Up { get; set; }

        [Display(Name = "Остаток в конце")]
        public double End { get; set; }

        public Spice()
        {
            Name = "Соль";
        }


    }
}
