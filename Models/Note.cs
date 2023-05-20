using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using учет_бюджета4.ViewModels;

namespace учет_бюджета4
{
    public class Note : BaseViewModel
    {
        private bool isIncome;

        public string Name { get; set; }
        public string TypeName { get; set; }
        public decimal Money { get; set; }
        public bool IsIncome 
        { 
            get => isIncome;
            set
            {
                if(value != isIncome)
                {
                    isIncome = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date { get; set; }
    }
}
