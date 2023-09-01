using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;


namespace Rock_Paper_Scissor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        ImageBrush robotIcon = new ImageBrush();
        ImageBrush rockIcon = new ImageBrush();
        ImageBrush paperIcon = new ImageBrush();
        ImageBrush scissorIcon = new ImageBrush();

        Random random = new Random();

        string robotResult, playerResult; 

        int playerPoint = 0, robotPoint = 0, drawPoint = 0; 

        Color color = (Color)ColorConverter.ConvertFromString("#FAF1E4");

        public MainWindow()
        {
            InitializeComponent();

            InitializeUIElementsWithImages();

            gameTimer.Start();
            gameTimer.Tick += StartGame;
            gameTimer.Interval = TimeSpan.FromSeconds(2);
        }

        //тут встановлюються картинки
        private void InitializeUIElementsWithImages()
        {
            SetElementBackgroundImage(ref robotIcon, robot, "pack://application:,,,/images/robot.png");
            SetElementBackgroundImage(ref rockIcon, rock, "pack://application:,,,/images/rock.png");
            SetElementBackgroundImage(ref paperIcon, paper, "pack://application:,,,/images/paper.png");
            SetElementBackgroundImage(ref scissorIcon, scissor, "pack://application:,,,/images/scissor.png");
        }
        private void SetElementBackgroundImage(ref ImageBrush icon, UIElement element, string imagePath)
        {
            icon.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            (element as Shape).Fill = icon;
        }
        
        //тут починається гра
        private void StartGame(object sender, EventArgs e)
        {
            color = (Color)ColorConverter.ConvertFromString("#FAF1E4");
            BaseCanvas.Background = new SolidColorBrush(color);

            BaseCanvas.Visibility = Visibility.Visible;
            ChoseCanvas.Visibility = Visibility.Hidden;

            GenerateRobotChoice();
        }
        
        //тут генерується вибір робота
        private void GenerateRobotChoice()
        {
            int r;
            r = random.Next(0, 3);

            switch (r) 
            {
                case 0:
                    robotChose.Fill = rockIcon;
                    robotResult = "rock";
                    break;
                case 1:
                    robotChose.Fill = paperIcon;
                    robotResult = "paper";
                    break;
                case 2:
                    robotChose.Fill = scissorIcon;
                    robotResult = "scissor";
                    break;
            }
        }

        //тут оюробник подій і відповідно вибір користувача встановлюється
        //у мене є подія MouseLeftButtonDown і коли вона виконується викликається метод\обробник подій і я можу визнатичити , що саме має відбуватися, коли виникає ця подія, в середині методу Choice_MouseLeftButtonDown. 
        private void Choice_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle choice = (Rectangle)sender;

            if (choice == rock)
            {
                playerChose.Fill = rockIcon;
                playerResult = "rock";
            }
            else if (choice == paper)
            {
                playerChose.Fill = paperIcon;
                playerResult = "paper";
            }
            else if (choice == scissor)
            {
                playerChose.Fill = scissorIcon;
                playerResult = "scissor";
            }

            ChoseCanvas.Visibility = Visibility.Visible;
            CalculateResult();
        }

        //тут обраховується результат
        private void CalculateResult()
        {
            if (playerResult == robotResult)
            {
                result.Content = "Draw!";
                color = (Color)ColorConverter.ConvertFromString("#9EB384");
                drawScore.Content = "draw:  " + ++drawPoint;
            }
            else if (
                (playerResult == "rock" && robotResult == "scissor") ||
                (playerResult == "paper" && robotResult == "rock") ||
                (playerResult == "scissor" && robotResult == "paper")
            )
            {
                result.Content = "Win!";
                color = (Color)ColorConverter.ConvertFromString("#CEDEBD");
                yourScore.Content = "you:  " + ++playerPoint;
            }
            else
            {
                result.Content = "Lose!";
                color = (Color)ColorConverter.ConvertFromString("#435334");
                robotScore.Content = "robot:  " + ++robotPoint;
            }

            ChoseCanvas.Background = new SolidColorBrush(color);
            BaseCanvas.Background = new SolidColorBrush(color);
        }
    }
}
