using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace form
{
    public class Dishes
    {
        [ReadOnly(true)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }


        [Display(GroupName = "стоймость включенная в блюдо", Name = "Руб.")]
        public int Rub { get; set; }
        [Display(GroupName = "стоймость включенная в блюдо", Name = "Коп.")]
        public int Cop { get; set; }


        [Display(Name = "Количество блюд")]
        public int Count { get; set; }
    }

    public class ViewModelDishes
    {

        private ObservableCollection<Dishes> _spices = new();

        public ObservableCollection<Dishes> Dishes
        {
            get => _spices;
            set { _spices = value; }
        }

        public ViewModelDishes()
        {
            _spices.Add(new Dishes() { Name = "Соль" });
            _spices.Add(new Dishes() { Name = "Специи" });
        }
    }


}
