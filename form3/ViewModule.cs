using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace form3
{
    public class ViewModel
    {
        private List<Spice> _spices = new();

        public List<Spice> Spices
        {
            get => _spices;
            set { _spices = value; }
        }


        public Dishes Salt {get; set;}
        public Dishes Paper {get; set;}



        public string Organization { get; set; } = "ООО рога&копыта";
        public string OKPO { get; set; } = "54321889";
        public int Number { get; set; } = 0;

        public string Struct { get; set; } = "Столовая N 2";
        public string OKDP { get; set; } = "55.30";
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);


        public string DirectorRole { get; set; } = "Директор";
        public string DirectorName { get; set; } = "Александрова О.А";

        public string WorkerName { get; set; } = "Осипов О.С.";
        public string WorkerRole { get; set; } = "Заведующий";
        public string EconomName { get; set; } = "Мухина С.М.";

        public ViewModel()
        {
            _spices.Add(new Spice());
        }
    }

}
