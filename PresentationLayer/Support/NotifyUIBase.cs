using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Support
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Very minimal implementation of INotifyPropertyChanged matching msdn
        // Note that this is dependent on .net 4.5+ because of CallerMemberName
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

