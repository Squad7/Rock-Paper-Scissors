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

namespace Rock_Paper_Scissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creates a global variable to give names to CPU and USERs choices
        public string CPUChoice = "";
        public string USERChoice = "";
        //Creates a global variable to keep track of both CPU and USER scores
        public int CPUScore = 0;
        public int USERScore = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


        //Generates a random number
        private int Randomizer(int range)
        {

            Random ranObject = new Random();

            int ranNum = ranObject.Next(range);

            return ranNum;
        }

        //Switch case Chooses a random CPU result and displays symbol and names CPUChoice
        private void CPU(int Rand)
        {
            switch(Rand)
            {
                case 0:
                    cpuIMG.Source = new BitmapImage(new Uri("Resources/Rock.png", UriKind.Relative));
                    CPUChoice = "R";
                    break;

                case 1:
                    cpuIMG.Source = new BitmapImage(new Uri("Resources/Paper.png", UriKind.Relative));
                    CPUChoice = "P";
                    break;

                case 2:
                    cpuIMG.Source = new BitmapImage(new Uri("Resources/Scissors.png", UriKind.Relative));
                    CPUChoice = "S";
                    break;       
            }
        }

        //If Rock option is clicked -  displays symbol, runs CPU switch case with range of 3 in Randomizor to get CPU result,
        //names USERChoice "R" and runs GetAnswer function to determine the result
        public void Rock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserIMG.Source = new BitmapImage(new Uri("Resources/Rock.png", UriKind.Relative));
            CPU(Randomizer(3));
            USERChoice = "R";
            GetAnswer();
        }
        
        //If Paper option is clicked -  displays symbol, runs CPU switch case with range of 3 in Randomizor to get CPU result,
        //names USERChoice "P" and runs GetAnswer function to determine the result
        public void Paper_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserIMG.Source = new BitmapImage(new Uri("Resources/Paper.png", UriKind.Relative));
            CPU(Randomizer(3));
            USERChoice = "P";
            GetAnswer();
        }

        //If Scissors option is clicked -  displays symbol, runs CPU switch case with range of 3 in Randomizor to get CPU result,
        //names USERChoice "S" and runs GetAnswer function to determine the result
        private void Scissors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UserIMG.Source = new BitmapImage(new Uri("Resources/Scissors.png", UriKind.Relative));
            CPU(Randomizer(3));
            USERChoice = "S";
            GetAnswer();
        }


        //Runs IF statements to find result of game from USERChoice and CPUChoice.
        //Increases CPUScore or USERScore depending on result
        //Displays score 
        //Runs YouLose, YouWin or Draw routine depending on result
        private void GetAnswer()
        {
             if (USERChoice == "R")
            {
                if (CPUChoice == "R")
                {

                    Draw();
                }
                else if (CPUChoice == "P")
                {
                    CPUScore++;
                    CPUScoreBox.Text = CPUScore.ToString();
                    YouLose();
                }
                else if (CPUChoice == "S")
                {
                    USERScore++;
                    USERScoreBox.Text = USERScore.ToString();
                    YouWin();
                }
            }
             else if (USERChoice == "P")
            {
                if (CPUChoice == "R")
                {
                    USERScore++;
                    USERScoreBox.Text = USERScore.ToString();
                    YouWin();
                }
                else if (CPUChoice == "P")
                {
                    Draw();
                }
                else if (CPUChoice == "S")
                {
                    CPUScore++;
                    CPUScoreBox.Text = CPUScore.ToString();
                    YouLose();
                }
            }
             else if (USERChoice == "S")
            {
                if (CPUChoice == "R")
                {
                    CPUScore++;
                    CPUScoreBox.Text = CPUScore.ToString();
                    YouLose();
                }
                else if (CPUChoice == "P")
                {
                    USERScore++;
                    USERScoreBox.Text = USERScore.ToString();
                    YouWin();
                }
                else if (CPUChoice == "S")
                {
                    Draw();
                }
            }
                 
            
        }


        //If User wins, label appears displaying "You Win!"
        public void YouWin()
        {
            YouWinLabel.Visibility = Visibility.Visible;
            DrawLabel.Visibility = Visibility.Hidden;
            YouLoseLabel.Visibility = Visibility.Hidden;
        }

        //If User loses, label appears displaying "You Lose"
        public void YouLose()
        {
            YouWinLabel.Visibility = Visibility.Hidden;
            DrawLabel.Visibility = Visibility.Hidden;
            YouLoseLabel.Visibility = Visibility.Visible;
        }

        //If game is draw, label appears displaying "Draw"
        public void Draw()
        {
            YouWinLabel.Visibility = Visibility.Hidden;
            DrawLabel.Visibility = Visibility.Visible;
            YouLoseLabel.Visibility = Visibility.Hidden;
        }
    }
}
