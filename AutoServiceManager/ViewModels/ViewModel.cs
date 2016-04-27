using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoServiceModel;

namespace AutoServiceManager.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        public List<WorksAutoOrder> AutoServiceList { get; set; }

        private string _toolTipText;

        public string ToolTipText
        {
            get
            {
                return _toolTipText;
            }
            set
            {
                _toolTipText = value;
                OnPropertyChanged("ToolTipText");
            }
        }

        public ViewModel()
        {
            var context = new AutoServiceEntities();
            AutoServiceList = context.WorksAutoOrder.Select(x => x).ToList();
            ToolTipText = "Text";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
