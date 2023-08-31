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

        ImageBrush robotChoice = new ImageBrush();

        Random random = new Random();

        string robotResult, playerResult;

        int playerPoint = 0, robotPoint = 0, drawPoint = 0;
        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Start();
            gameTimer.Tick += StartGame;
            gameTimer.Interval = TimeSpan.FromSeconds(3);

            /*robotIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/robot.png"));
            robot.Fill = robotIcon;

            rockIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/rock.png"));
            rock.Fill = rockIcon;

            paperIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/paper.png"));
            paper.Fill = paperIcon;

            scissorIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/scissor.png"));
            scissor.Fill = scissorIcon;

            GenerateRobotChoice();*/
            // StartGame();
            /*gameTimer.Start();
            gameTimer.Tick += StartGame;
            gameTimer.Interval = TimeSpan.FromSeconds(1);*/
        }

        private void StartGame(object sender, EventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FAF1E4");
            BaseCanvas.Background = new SolidColorBrush(color);
            BaseCanvas.Visibility = Visibility.Visible;
            ChoseCanvas.Visibility = Visibility.Hidden;

            robotIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/robot.png"));
            robot.Fill = robotIcon;

            rockIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/rock.png"));
            rock.Fill = rockIcon;

            paperIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/paper.png"));
            paper.Fill = paperIcon;

            scissorIcon.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/scissor.png"));
            scissor.Fill = scissorIcon;
            
            GenerateRobotChoice();

        }

        private void GenerateRobotChoice()
        {
            int r;
            string path = "";

            r = random.Next(0, 3);

            switch (r) 
            {
                case 0:
                    path = "pack://application:,,,/images/rock.png";
                    robotResult = "rock";
                    break;
                case 1:
                    path = "pack://application:,,,/images/paper.png";
                    robotResult = "paper";
                    break;
                case 2:
                    path = "pack://application:,,,/images/scissor.png";
                    robotResult = "scissor";
                    break;
            }

            robotChoice.ImageSource = new BitmapImage(new Uri(path));
            robotChose.Fill = robotChoice;
        }

        private void GenerateResult()
        {
            //rock > scissor
            //scissor > paper
            //paper > rock            
            Dictionary<string, int> resultPairs = new Dictionary<string, int>();

            resultPairs["rock-rock"] = 0;
            resultPairs["paper-paper"] = 0;
            resultPairs["scissor-scissor"] = 0;
            resultPairs["rock-scissor"] = 1;
            resultPairs["paper-rock"] = 1;
            resultPairs["scissor-paper"] = 1;
            resultPairs["rock-paper"] = 2;
            resultPairs["paper-scissor"] = 2;
            resultPairs["scissor-rock"] = 2;

            Color color = (Color)ColorConverter.ConvertFromString("#435334"); 

            string key = robotResult + '-' + playerResult;
            int val = resultPairs[key];

            if(val == 1)
            {
                result.Content = "Lose!";
                color = (Color)ColorConverter.ConvertFromString("#435334");
                robotScore.Content = "robot:  " + ++robotPoint;
            }
            else if (val == 2)
            {
                result.Content = "Win!";
                color = (Color)ColorConverter.ConvertFromString("#CEDEBD");
                yourScore.Content = "you:  " + ++playerPoint;
            }
            else
            {
                result.Content = "Draw!";
                color = (Color)ColorConverter.ConvertFromString("#9EB384");
                drawScore.Content = "draw:  " + ++drawPoint;
            }

            ChoseCanvas.Background = new SolidColorBrush(color);
            BaseCanvas.Background = new SolidColorBrush(color);
        }

        private void rock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playerChose.Fill = rockIcon;
            playerResult = "rock";
            ChoseCanvas.Visibility = Visibility.Visible;
            GenerateResult();
        }

        private void paper_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playerChose.Fill = paperIcon;
            playerResult = "paper";
            ChoseCanvas.Visibility = Visibility.Visible;
            GenerateResult();
        }

        private void scissor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            playerChose.Fill = scissorIcon;
            playerResult = "scissor";
            ChoseCanvas.Visibility = Visibility.Visible;
            GenerateResult();
        }
    }
}
