using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
            var dialog = new OpenFileDialog();
            dialog.FileName = "Assembly";
            dialog.DefaultExt = ".dll";
            dialog.Filter = "Dynamic link library (.dll)|*.dll";
            dialog.Title = "Select assembly";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                AssemblyPath = dialog.FileName;
                OnPropertyChanged(nameof(AssemblyPath));
            }
        }

        private VMOpenFileCommand? _openFileDial;
        public VMOpenFileCommand OpenFileDialog
        {
            get
            {
                return _openFileDial ??
                  (_openFileDial = new VMOpenFileCommand(o => OpenAssembly()));
            }
        }

        public string AssemblyPath
        {
            get => _assemblyPath;
            set
            {
                _assemblyPath = value;
                AssemblyTree = VMToTree.Convert(Model.GetTree(AssemblyPath));
                OnPropertyChanged(nameof(AssemblyTree));
            }
        }
    }
}
