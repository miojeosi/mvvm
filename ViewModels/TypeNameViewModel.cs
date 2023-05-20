using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace учет_бюджета4.ViewModels
{
    internal class TypeNameViewModel : BaseViewModel
    {
        private ICommand onAddCommand;

        public string TypeName { get; set; }
        public ICommand OnAddCommand 
        { 
            get => onAddCommand;
            set 
            { 
                if(onAddCommand != value)
                {
                    onAddCommand = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
