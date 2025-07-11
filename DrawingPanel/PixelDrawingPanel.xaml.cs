using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Threading;

namespace JTechPixelLED.DrawingPanel
{
    public partial class PixelDrawingPanel : UserControl
    {
        private List<FrameData> Frames = new List<FrameData>();
        private int currentFrame = 0;
        private int gridSize = 16;
        private bool rgbMode = false;
        private bool isPlaying = false;
        private CancellationTokenSource playbackCts;

        public PixelDrawingPanel()
        {
            InitializeComponent();
            Frames.Add(new FrameData(gridSize, gridSize));
            UpdateUI();
        }

        private void UpdateUI()
        {
            FrameLabel.Text = $"Frame {currentFrame + 1} / {Frames.Count}";
            gridSize = (int)GridSizeSlider.Value;
            rgbMode = RgbModeCheck.IsChecked == true;
            PixelGrid.Rows = gridSize;
            PixelGrid.Columns = gridSize;
            PixelGrid.Children.Clear();
            var frame = Frames[currentFrame];
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    var pixel = frame.Pixels[x, y];
                    var btn = new Button
                    {
                        Margin = new Thickness(1),
                        Tag = (x, y),
                        ToolTip = $"Delay: {pixel.Delay:0.00}s",
                        Background = pixel.IsOn ? (rgbMode && pixel.Color.HasValue ? new SolidColorBrush(pixel.Color.Value) : Brushes.LimeGreen) : Brushes.Black,
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(0.5),
                        Content = null
                    };
                    btn.Click += Pixel_Click;
                    btn.MouseRightButtonUp += Pixel_RightClick;
                    PixelGrid.Children.Add(btn);
                }
            }
        }

        private void Pixel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is ValueTuple<int, int> pos)
            {
                int x = pos.Item1, y = pos.Item2;
                var pixel = Frames[currentFrame].Pixels[x, y];
                pixel.IsOn = !pixel.IsOn;
                if (rgbMode && pixel.IsOn)
                {
                    // For demo: cycle through a few colors
                    pixel.Color = pixel.Color == Colors.Red ? Colors.Green : pixel.Color == Colors.Green ? Colors.Blue : Colors.Red;
                }
                UpdateUI();
            }
        }

        private void Pixel_RightClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button btn && btn.Tag is ValueTuple<int, int> pos)
            {
                int x = pos.Item1, y = pos.Item2;
                var pixel = Frames[currentFrame].Pixels[x, y];
                var dlg = new PixelDelayDialog(pixel.Delay);
                if (dlg.ShowDialog() == true)
                {
                    pixel.Delay = dlg.Delay;
                    UpdateUI();
                }
            }
        }

        private void PrevFrame_Click(object sender, RoutedEventArgs e)
        {
            if (currentFrame > 0)
            {
                currentFrame--;
                UpdateUI();
            }
        }

        private void NextFrame_Click(object sender, RoutedEventArgs e)
        {
            if (currentFrame < Frames.Count - 1)
            {
                currentFrame++;
                UpdateUI();
            }
        }

        private void AddFrame_Click(object sender, RoutedEventArgs e)
        {
            Frames.Insert(currentFrame + 1, new FrameData(gridSize, gridSize));
            currentFrame++;
            UpdateUI();
        }

        private void DeleteFrame_Click(object sender, RoutedEventArgs e)
        {
            if (Frames.Count > 1)
            {
                Frames.RemoveAt(currentFrame);
                if (currentFrame >= Frames.Count) currentFrame = Frames.Count - 1;
                UpdateUI();
            }
        }

        private void CloneFrame_Click(object sender, RoutedEventArgs e)
        {
            var src = Frames[currentFrame];
            var clone = new FrameData(gridSize, gridSize);
            for (int x = 0; x < gridSize; x++)
                for (int y = 0; y < gridSize; y++)
                {
                    clone.Pixels[x, y].IsOn = src.Pixels[x, y].IsOn;
                    clone.Pixels[x, y].Delay = src.Pixels[x, y].Delay;
                    clone.Pixels[x, y].Color = src.Pixels[x, y].Color;
                }
            Frames.Insert(currentFrame + 1, clone);
            currentFrame++;
            UpdateUI();
        }

        private void GridSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newSize = (int)e.NewValue;
            if (Frames.Count > 0 && (Frames[0].Width != newSize || Frames[0].Height != newSize))
            {
                // Resize all frames
                for (int i = 0; i < Frames.Count; i++)
                {
                    var old = Frames[i];
                    var resized = new FrameData(newSize, newSize);
                    for (int x = 0; x < Math.Min(old.Width, newSize); x++)
                        for (int y = 0; y < Math.Min(old.Height, newSize); y++)
                        {
                            resized.Pixels[x, y].IsOn = old.Pixels[x, y].IsOn;
                            resized.Pixels[x, y].Delay = old.Pixels[x, y].Delay;
                            resized.Pixels[x, y].Color = old.Pixels[x, y].Color;
                        }
                    Frames[i] = resized;
                }
            }
            UpdateUI();
        }

        private async void PlayAnimation_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying) return;
            isPlaying = true;
            playbackCts = new CancellationTokenSource();
            SetToolbarEnabled(false);
            PlayButton().IsEnabled = false;
            StopButton().IsEnabled = true;
            try
            {
                for (int f = 0; f < Frames.Count; f++)
                {
                    if (playbackCts.Token.IsCancellationRequested) break;
                    currentFrame = f;
                    UpdateUI();
                    double minDelay = 2.0;
                    var frame = Frames[f];
                    for (int x = 0; x < gridSize; x++)
                        for (int y = 0; y < gridSize; y++)
                            if (frame.Pixels[x, y].IsOn)
                                minDelay = Math.Min(minDelay, frame.Pixels[x, y].Delay);
                    if (minDelay == 2.0) minDelay = 0.1;
                    await Task.Delay(TimeSpan.FromSeconds(minDelay), playbackCts.Token);
                }
            }
            catch (TaskCanceledException) { }
            finally
            {
                isPlaying = false;
                SetToolbarEnabled(true);
                PlayButton().IsEnabled = true;
                StopButton().IsEnabled = true;
            }
        }

        private void StopAnimation_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying && playbackCts != null)
            {
                playbackCts.Cancel();
            }
        }

        private void SetToolbarEnabled(bool enabled)
        {
            foreach (var child in ((StackPanel)((DockPanel)Content).Children[0]).Children)
            {
                if (child is Button btn)
                {
                    if (btn.Content.ToString() == "Play")
                        btn.IsEnabled = enabled && !isPlaying;
                    else if (btn.Content.ToString() == "Stop")
                        btn.IsEnabled = enabled || isPlaying;
                    else
                        btn.IsEnabled = enabled;
                }
                else if (child is Control ctrl)
                {
                    ctrl.IsEnabled = enabled;
                }
            }
        }

        private Button PlayButton()
        {
            foreach (var child in ((StackPanel)((DockPanel)Content).Children[0]).Children)
                if (child is Button btn && btn.Content.ToString() == "Play")
                    return btn;
            return null;
        }
        private Button StopButton()
        {
            foreach (var child in ((StackPanel)((DockPanel)Content).Children[0]).Children)
                if (child is Button btn && btn.Content.ToString() == "Stop")
                    return btn;
            return null;
        }
    }
} 