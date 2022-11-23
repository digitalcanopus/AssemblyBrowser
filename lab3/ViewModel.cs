using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace lab3
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string _assemblyPath = "";
        private List<VMNode> _assemblyTree;

        public List<VMNode> AssemblyTree
        {
            get => _assemblyTree;
            set => _assemblyTree = value;
        }

        private void OpenAssembly()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Assembly";
            dialog.DefaultExt = ".dll";
            dialog.Filter = "Dynamic link library (.dll)|*.dll";
            dialog.Title = "Select assembly";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                //smth
            }
        }
    }
}
