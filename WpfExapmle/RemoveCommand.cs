using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExapmle
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            var nameList = parameter as NamesList;
            return nameList != null && nameList.SelectedName != null;
        }
        public void Execute(object parameter)
        {
            var nameList = parameter as NamesList;
            var oldName = nameList.SelectedName;
            nameList.Names.Remove(oldName);
        }
    }
}
