using System.Windows;

namespace Questionnaire.View
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result()
        {
            InitializeComponent();
        }

        public Result(int correctAnswers, int numberOfQuestions)
        {
            InitializeComponent();

            FinalResult.Text = "You answered correctly to " + correctAnswers +
                               " question(s) out of " + numberOfQuestions;
        }

        private void NewTest_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();

            Close();
        }
    }
}
