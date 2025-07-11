using System.Windows;

namespace JTechPixelLED.DrawingPanel
{
    public partial class PixelDelayDialog : Window
    {
        public double Delay { get; private set; }

        public PixelDelayDialog(double initialDelay)
        {
            InitializeComponent();
            DelaySlider.Value = initialDelay;
            DelayBox.Text = initialDelay.ToString("0.00");
        }

        private void DelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (DelayBox != null)
                DelayBox.Text = DelaySlider.Value.ToString("0.00");
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(DelayBox.Text, out double val) && val >= 0.1 && val <= 2.0)
            {
                Delay = val;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a value between 0.1 and 2.0 seconds.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 