using System.Windows;
using System.Windows.Controls;

namespace JTechPixelLED
{
    public partial class ModeSelectionDialog : UserControl
    {
        public string SelectedMode { get; private set; }
        public ModeSelectionDialog()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in ((StackPanel)((materialDesign:Card)Content).Content).Children)
            {
                if (child is RadioButton rb && rb.IsChecked == true)
                {
                    SelectedMode = rb.Content.ToString();
                    break;
                }
            }
            // Close dialog or notify parent window
        }

        private void TryDemo_Click(object sender, RoutedEventArgs e)
        {
            // Implement demo mode logic here
            MessageBox.Show("Demo mode not yet implemented.");
        }
    }
}
