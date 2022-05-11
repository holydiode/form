using Syncfusion.UI.Xaml.Grid;
using System.Windows;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace form
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            //context.Spices.CollectionChanged += (e, v) => {
            //    table.View.Refresh();
            //    };
            //this.table.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowDataShaping;
            //table.OnDependencyPropertyChanged("Name", new DependencyPropertyChangedEventArgs());
            //table.OnDependencyPropertyChanged("Code", new DependencyPropertyChangedEventArgs());
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var w = table.Columns[2].ActualWidth / 2;


            table.Columns[2].Width = w;
            table.Columns[3].Width = w;
            table.Columns[4].Width = w;
            table.Columns[5].Width = w;
            table.Columns[6].Width = w;
            table.Columns[7].Width = w;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var excel = new Excel.Application();
            var wb = excel.Workbooks.Open("E:\\temp.xlsx");
            var sheet = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            int index = 0;
            foreach(var spice in this.context.Spices)
            {
                sheet.Cells[25 + index, "A"] = index + 1;
                sheet.Cells[25 + index, "E"] = spice.Name;
                sheet.Cells[25 + index, "S"] = spice.Code;

                sheet.Cells[25 + index, "W"] =  spice.StartRub + ((double)spice.StartCop)/100;
                sheet.Cells[25 + index, "AD"] =  spice.UpRub + ((double)spice.UpCop) /100;
                sheet.Cells[25 + index, "AK"] =  spice.EndRub + ((double)spice.EndCop) /100;

                sheet.Cells[25 + index, "AS"] =  spice.StartRub + ((double)spice.StartCop)/100    + spice.UpRub + ((double)spice.UpCop) / 100 - spice.EndRub + ((double)spice.EndCop) / 100;
                index++;
            }


            sheet.Cells[32, "W"] = this.context.Spices.Sum(spice => spice.StartRub + ((double)spice.StartCop) / 100);
            sheet.Cells[32, "AD"] = this.context.Spices.Sum(spice => spice.UpRub + ((double)spice.UpCop) / 100);
            sheet.Cells[32, "AK"] = this.context.Spices.Sum(spice => spice.EndRub + ((double)spice.EndCop) / 100);
            sheet.Cells[32, "AS"] = this.context.Spices.Sum(spice => spice.StartRub + ((double)spice.StartCop) / 100 + spice.UpRub + ((double)spice.UpCop) / 100 - spice.EndRub + ((double)spice.EndCop) / 100);

            sheet.Cells[40, "C"] = this.dcontext.Dishes[0].Rub;
            sheet.Cells[40, "T"] = this.dcontext.Dishes[0].Cop;
            sheet.Cells[40, "AE"] = this.dcontext.Dishes[0].Count;
            sheet.Cells[40, "AL"] = this.dcontext.Dishes[0].Count * (this.dcontext.Dishes[0].Rub + ((float)this.dcontext.Dishes[0].Cop)/100);

            sheet.Cells[43, "C"] = this.dcontext.Dishes[1].Rub;
            sheet.Cells[43, "T"] = this.dcontext.Dishes[1].Cop;
            sheet.Cells[42, "AE"] = this.dcontext.Dishes[1].Count;
            sheet.Cells[42, "AL"] = this.dcontext.Dishes[1].Count * (this.dcontext.Dishes[0].Rub + ((float)this.dcontext.Dishes[0].Cop) / 100);

            sheet.Cells[43, "C"] = this.dcontext.Dishes[1].Rub;
            sheet.Cells[43, "T"] = this.dcontext.Dishes[1].Cop;


            sheet.Cells[45, "AL"] = this.dcontext.Dishes[1].Count * (this.dcontext.Dishes[0].Rub + ((float)this.dcontext.Dishes[0].Cop) / 100) + this.dcontext.Dishes[1].Count * (this.dcontext.Dishes[0].Rub + ((float)this.dcontext.Dishes[0].Cop) / 100);
            sheet.Cells[46, "AL"] = this.context.Spices.Sum(spice => spice.StartRub + ((double)spice.StartCop) / 100 + spice.UpRub + ((double)spice.UpCop) / 100 - spice.EndRub + ((double)spice.EndCop) / 100);
            sheet.Cells[47, "AL"] = this.dcontext.Dishes[1].Count * (this.dcontext.Dishes[0].Rub + ((float)this.dcontext.Dishes[0].Cop) / 100) + this.dcontext.Dishes[1].Count * (this.dcontext.Dishes[0].Rub + ((float)this.dcontext.Dishes[0].Cop) / 100) -
                this.context.Spices.Sum(spice => spice.StartRub + ((double)spice.StartCop) / 100 + spice.UpRub + ((double)spice.UpCop) / 100 - spice.EndRub + ((double)spice.EndCop) / 100);


            sheet.Cells[6, "A"] = this.acontext.Organization;
            sheet.Cells[6, "AQ"] = this.acontext.OKPO;
            sheet.Cells[8, "A"] = this.acontext.Struct;
            sheet.Cells[9, "AQ"] = this.acontext.OKDP;

            sheet.Cells[13, "AR"] = this.acontext.DirectorName;
            sheet.Cells[15, "AS"] = this.acontext.DirectorRole;


            sheet.Cells[16, "Q"] = this.acontext.Number;
            sheet.Cells[16, "W"] = this.acontext.CreationDate.ToShortDateString();
            sheet.Cells[16, "AC"] = this.acontext.StartDate.ToShortDateString();
            sheet.Cells[16, "AG"] = this.acontext.EndDate.ToShortDateString();


            sheet.Cells[17, "AM"] = this.acontext.CreationDate.Day;
            sheet.Cells[17, "AO"] = CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames[this.acontext.CreationDate.Month];
            sheet.Cells[17, "AW"] = this.acontext.CreationDate.Year;

            sheet.Cells[49, "P"] = this.acontext.WorkerRole;
            sheet.Cells[49, "AH"] = this.acontext.WorkerName;



            sheet.Cells[51, "P"] = this.acontext.EconomName;

            excel.Visible = true;
        }
    }
}
