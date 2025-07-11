using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Threading;
using System.Text.Json;
using Microsoft.Win32;
using System.Windows.Media;

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
        private HashSet<(int,int)> animatingOff = new HashSet<(int,int)>();

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
                        ToolTip = $"State: {(pixel.IsOn ? "ON" : "OFF")}, Delay: {pixel.Delay:0.00}s" + (rgbMode && pixel.Color.HasValue ? $", Color: {pixel.Color.Value}" : ""),
                        Background = pixel.IsOn ? (rgbMode && pixel.Color.HasValue ? new SolidColorBrush(pixel.Color.Value) : Brushes.LimeGreen) : Brushes.Black,
                        BorderBrush = animatingOff.Contains((x, y)) ? Brushes.Red : Brushes.Gray,
                        BorderThickness = new Thickness(animatingOff.Contains((x, y)) ? 2 : 0.5),
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
                if (rgbMode)
                {
                    var dlg = new System.Windows.Forms.ColorDialog();
                    if (pixel.Color.HasValue)
                        dlg.Color = System.Drawing.Color.FromArgb(pixel.Color.Value.A, pixel.Color.Value.R, pixel.Color.Value.G, pixel.Color.Value.B);
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        pixel.Color = Color.FromArgb(dlg.Color.A, dlg.Color.R, dlg.Color.G, dlg.Color.B);
                        pixel.IsOn = true;
                        UpdateUI();
                    }
                }
                else
                {
                    var dlg = new PixelDelayDialog(pixel.Delay);
                    if (dlg.ShowDialog() == true)
                    {
                        pixel.Delay = dlg.Delay;
                        UpdateUI();
                    }
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
                    var frame = Frames[f];
                    animatingOff.Clear();
                    // Schedule each ON pixel to turn off after its delay
                    List<Task> offTasks = new List<Task>();
                    for (int x = 0; x < gridSize; x++)
                        for (int y = 0; y < gridSize; y++)
                            if (frame.Pixels[x, y].IsOn)
                            {
                                int px = x, py = y;
                                double delay = frame.Pixels[x, y].Delay;
                                animatingOff.Add((px, py));
                                offTasks.Add(Task.Run(async () => {
                                    try {
                                        await Task.Delay(TimeSpan.FromSeconds(delay), playbackCts.Token);
                                        Application.Current.Dispatcher.Invoke(() => {
                                            animatingOff.Remove((px, py));
                                            frame.Pixels[px, py].IsOn = false;
                                            UpdateUI();
                                        });
                                    } catch { }
                                }));
                            }
                    // Wait for the longest delay in this frame
                    double maxDelay = 0.1;
                    for (int x = 0; x < gridSize; x++)
                        for (int y = 0; y < gridSize; y++)
                            if (frame.Pixels[x, y].IsOn)
                                maxDelay = Math.Max(maxDelay, frame.Pixels[x, y].Delay);
                    await Task.WhenAll(offTasks);
                    await Task.Delay(100, playbackCts.Token); // small pause before next frame
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

        // Export animation to JSON
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "JSON Files|*.json" };
            if (dlg.ShowDialog() == true)
            {
                var export = new List<FrameExport>();
                foreach (var frame in Frames)
                {
                    var pixels = new List<PixelExport>();
                    for (int x = 0; x < frame.Width; x++)
                        for (int y = 0; y < frame.Height; y++)
                        {
                            var p = frame.Pixels[x, y];
                            pixels.Add(new PixelExport
                            {
                                X = x, Y = y, IsOn = p.IsOn, Delay = p.Delay,
                                Color = p.Color.HasValue ? p.Color.Value.ToString() : null
                            });
                        }
                    export.Add(new FrameExport { Width = frame.Width, Height = frame.Height, Pixels = pixels });
                }
                var json = JsonSerializer.Serialize(export, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(dlg.FileName, json);
            }
        }

        // Import animation from JSON
        private void Import_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "JSON Files|*.json" };
            if (dlg.ShowDialog() == true)
            {
                var json = System.IO.File.ReadAllText(dlg.FileName);
                var import = JsonSerializer.Deserialize<List<FrameExport>>(json);
                if (import != null)
                {
                    Frames.Clear();
                    foreach (var f in import)
                    {
                        var frame = new FrameData(f.Width, f.Height);
                        foreach (var p in f.Pixels)
                        {
                            frame.Pixels[p.X, p.Y].IsOn = p.IsOn;
                            frame.Pixels[p.X, p.Y].Delay = p.Delay;
                            if (!string.IsNullOrEmpty(p.Color))
                                frame.Pixels[p.X, p.Y].Color = (Color)ColorConverter.ConvertFromString(p.Color);
                        }
                        Frames.Add(frame);
                    }
                    currentFrame = 0;
                    gridSize = Frames[0].Width;
                    GridSizeSlider.Value = gridSize;
                    UpdateUI();
                }
            }
        }

        // Export/import helper classes
        private class FrameExport
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public List<PixelExport> Pixels { get; set; }
        }
        private class PixelExport
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsOn { get; set; }
            public double Delay { get; set; }
            public string Color { get; set; }
        }
    }
} 