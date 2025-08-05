using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bdo_Toolkit;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private DispatcherTimer _timer;
    private TimeSpan _elapsed;

    public MainWindow()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _elapsed = TimeSpan.Zero;
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.DragMove();
        }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        _elapsed = _elapsed.Add(TimeSpan.FromSeconds(1));
        TimerTextBlock.Text = $"Timer: {_elapsed:hh\\:mm\\:ss}";
    }

    private void Start_Click(object sender, RoutedEventArgs e)
    {
        _timer.Start();
    }

    private void Pause_Click(object sender, RoutedEventArgs e)
    {
        _timer.Stop();
    }

    private void End_Click(object sender, RoutedEventArgs e)
    {
        _timer.Stop();
        _elapsed = TimeSpan.Zero;
        TimerTextBlock.Text = "Timer: 00:00:00";
    }
}