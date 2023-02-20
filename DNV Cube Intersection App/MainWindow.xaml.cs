using Application.ApplicationsServices.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DNV_Cube_Intersection_App.DependencyInjection;

namespace DNV_Cube_Intersection_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(ContainerConfigurationModule.Resolve<IIntersectionApplicationService>());
        }

        private void OnTextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.SelectionLength == 0)
                    textBox.SelectAll();
            }
        }

        private void OnTextBoxLostMouseCapture(object sender, MouseEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.SelectionLength == 0)
                    textBox.SelectAll();

                textBox.LostMouseCapture -= OnTextBoxLostMouseCapture;
            }
        }

        private void OnTextBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.LostMouseCapture += OnTextBoxLostMouseCapture;
            }
        }
    }
}
