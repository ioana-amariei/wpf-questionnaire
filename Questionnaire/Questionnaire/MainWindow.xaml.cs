using System;
using System.Windows;
using Questionnaire.Model;
using Questionnaire.View;

namespace Questionnaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartQuestionnaire_OnClick(object sender, RoutedEventArgs e)
        {
            int chosenComplexity = Convert.ToInt32(Complexity.Text);

            Questions questions = new Questions(chosenComplexity);
            questions.Show();

            Close();
        }
    }
}