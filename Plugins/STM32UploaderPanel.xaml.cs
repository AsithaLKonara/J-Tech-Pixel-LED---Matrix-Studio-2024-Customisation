using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;

namespace JTechPixelLED.Plugins
{
    public partial class STM32UploaderPanel : UserControl
    {
        public STM32UploaderPanel()
        {
            InitializeComponent();
            DataContext = new STM32UploaderViewModel(UploadSnackbar);
        }
    }

    public class STM32UploaderViewModel : INotifyPropertyChanged
    {
        private string filePath;
        public string FilePath { get => filePath; set { filePath = value; OnPropertyChanged(); } }
        private string port;
        public string Port { get => port; set { port = value; OnPropertyChanged(); } }
        private string baudRate = "57600";
        public string BaudRate { get => baudRate; set { baudRate = value; OnPropertyChanged(); } }
        private string log;
        public string Log { get => log; set { log = value; OnPropertyChanged(); } }
        private bool isUploading;
        public bool IsUploading { get => isUploading; set { isUploading = value; OnPropertyChanged(); } }
        public ICommand BrowseCommand { get; }
        public ICommand UploadCommand { get; }

        private ISnackbarMessageQueue _snackbarQueue;
        public STM32UploaderViewModel(Snackbar snackbar)
        {
            _snackbarQueue = snackbar.MessageQueue;
            BrowseCommand = new RelayCommand(_ => Browse());
            UploadCommand = new RelayCommand(_ => Upload());
        }

        private void Browse()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog { Filter = "BIN Files|*.bin|All Files|*.*" };
            if (dlg.ShowDialog() == true)
            {
                FilePath = dlg.FileName;
                _snackbarQueue?.Enqueue("File selected: " + FilePath);
            }
        }

        private async void Upload()
        {
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                _snackbarQueue?.Enqueue("Please select a file to upload.");
                return;
            }
            if (string.IsNullOrWhiteSpace(Port))
            {
                _snackbarQueue?.Enqueue("Please enter a port (e.g., COM3).");
                return;
            }
            IsUploading = true;
            _snackbarQueue?.Enqueue("Uploading...");
            try
            {
                await Task.Delay(1000); // Simulate upload
                // TODO: Replace with actual upload logic
                _snackbarQueue?.Enqueue("Upload successful!");
                Log += $"Upload to {Port} complete.\n";
            }
            catch (Exception ex)
            {
                _snackbarQueue?.Enqueue("Upload failed: " + ex.Message);
                Log += $"Error: {ex.Message}\n";
            }
            finally
            {
                IsUploading = false;
            }
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