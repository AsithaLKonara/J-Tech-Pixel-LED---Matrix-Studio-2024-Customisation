using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JTechPixelLED
{
    public partial class ExportDialog : UserControl
    {
        public ExportDialog()
        {
            InitializeComponent();
            DataContext = new ExportDialogViewModel();
        }
    }

    public class ExportDialogViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Modes { get; } = new ObservableCollection<string> { "Normal", "Buduras Mala", "Viyans", "DJ Panel", "Edit Drawing" };
        private string selectedMode;
        public string SelectedMode { get => selectedMode; set { selectedMode = value; OnPropertyChanged(); } }
        public bool IsHex { get => isHex; set { isHex = value; OnPropertyChanged(); } }
        public bool IsBin { get => isBin; set { isBin = value; OnPropertyChanged(); } }
        public bool IsDat { get => isDat; set { isDat = value; OnPropertyChanged(); } }
        private bool isHex = true, isBin, isDat;
        private string exportPath;
        public string ExportPath { get => exportPath; set { exportPath = value; OnPropertyChanged(); } }
        public ICommand BrowseCommand { get; }
        public ICommand ExportCommand { get; }

        public ExportDialogViewModel()
        {
            BrowseCommand = new RelayCommand(_ => Browse());
            ExportCommand = new RelayCommand(_ => Export());
        }

        private void Browse()
        {
            var dlg = new Microsoft.Win32.SaveFileDialog { Filter = "All Files|*.*" };
            if (dlg.ShowDialog() == true)
                ExportPath = dlg.FileName;
        }

        private void Export()
        {
            // TODO: Implement export logic
            MessageBox.Show($"Exporting {SelectedMode} as {(IsHex ? ".hex" : IsBin ? ".bin" : ".dat")} to {ExportPath}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand
    {
        private readonly System.Action<object> execute;
        private readonly System.Func<object, bool> canExecute;
        public RelayCommand(System.Action<object> execute, System.Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);
        public void Execute(object parameter) => execute(parameter);
        public event System.EventHandler CanExecuteChanged { add { } remove { } }
    }
} 