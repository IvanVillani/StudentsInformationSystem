using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVMM : DependencyObject, INotifyPropertyChanged
    {
        //set up a private class varialbe that holds the value of the _Backing Property
        private ObservableCollection<string> _BackingProperty;

        //This is the publically viewable Property for this class
        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value; PropChanged("BoundProperty"); }
        }

        //This event will be fired to notify any listeners of a change in a property value.
        public event PropertyChangedEventHandler PropertyChanged;
        //Tell WPF Binding that this property value has changed
        public void PropChanged(String propertyName)
        {
            //Did WPF registerd to listen to this event
            if (PropertyChanged != null)
            {
                //Tell WPF that this property changed
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowVMM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }
    }
}
