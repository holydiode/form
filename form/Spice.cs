using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form
{

    public sealed class TrulyObservableCollection<T> : ObservableCollection<T>
    where T : INotifyPropertyChanged
    {
        public TrulyObservableCollection()
        {
            CollectionChanged += FullObservableCollectionCollectionChanged;
        }

        public TrulyObservableCollection(IEnumerable<T> pItems) : this()
        {
            foreach (var item in pItems)
            {
                this.Add(item);
            }
        }

        private void FullObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
                }
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((T)sender));
            OnCollectionChanged(args);
        }
    }

    public class ViewModel
    {
        private TrulyObservableCollection<Spice> _spices = new();
        public TrulyObservableCollection<Spice> Spices
        {
            get => _spices;
            set { _spices = value; }
        }
        public ViewModel()
        {
            _spices.Add(new Spice());
        }
    }


    public class Spice: INotifyPropertyChanged
    {
        private string _name = "";
        private string _code = "";

        [Display(Name = "Наименование", Order = 1)]
        public string Name { get => _name; set {
                _name = value;
                if (Names.Contains(value))
                {
                    _code = Codes[Names.IndexOf(value)];
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Code"));
                }
            } 
        }  
        [Display(Name = "Код", Order = 2)]
        public string Code { get => _code; set { 
                _code = value;
                if (Codes.Contains(value))
                {
                    _name = Names[Codes.IndexOf(value)];
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Code"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        [Display(GroupName = "Остаток в начале", Name = "Руб.", Order = 3)]
        public int StartRub { get; set; }
        [Display(GroupName = "Остаток в начале", Name = "Коп.", Order = 4)]
        public int StartCop { get; set; }

        [Display(GroupName = "Поступило", Name = "Руб.", Order = 5)]
        public int UpRub { get; set; }
        [Display(GroupName = "Поступило", Name = "Коп.", Order = 6)]
        public int UpCop { get; set; }

        [Display(GroupName = "Остаток в конце", Name = "Руб.", Order = 7)]
        public int EndRub { get; set; }

        [Display(GroupName = "Остаток в конце", Name = "Коп.", Order = 8)]
        public int EndCop { get; set; }

        private static ObservableCollection<string> _spices_name = new()
        {
            "Соль",
            "Перец",
            "Паприка",
            "Ваниль",
            "Корица",
            "Гвоздика",
            "Мускатный орех",
            "Мацис",
            "Анис"
        };

        private static ObservableCollection<string> _code_name = new()
        {
            "14.40.10.143",
            "15.87.20.110",
            "15.87.20.120",
            "15.87.20.130",
            "15.87.20.140",
            "15.87.20.150",
            "15.87.20.151",
            "15.87.20.151",
            "15.87.20.152"
        };

        public event PropertyChangedEventHandler PropertyChanged;

        [Display(AutoGenerateField =false)]
        public static ObservableCollection<string> Names
        {
            get => _spices_name;
            set { _spices_name = value; }
        }

        [Display(AutoGenerateField = false)]
        public static ObservableCollection<string> Codes
        {
            get => _code_name;
            set { _code_name = value; }
        }


        public Spice()
        {
            Name = "Соль";
        }


    }
}
