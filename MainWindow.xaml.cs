using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rock_Paper_Scissor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageBrush robotIcon = new ImageBrush();
        ImageBrush rockIcon = new ImageBrush();
        ImageBrush paperIcon = new ImageBrush();
        ImageBrush scissorIcon = new ImageBrush();
        public MainWindow()
        {
            InitializeComponent();

            robotIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/robot.png"));
            robot.Fill = robotIcon;

            rockIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/rock.png"));
            rock.Fill = rockIcon;

            paperIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/paper.png"));
            paper.Fill = paperIcon;

            scissorIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/scissor.png"));
            scissor.Fill = scissorIcon;
        }
    }
}
