using System.Collections.Generic;
using System.Windows;
using Questionnaire.Model;
using Questionnaire.ViewModel;

namespace Questionnaire.View
{
    /// <summary>
    /// Interaction logic for Questions.xaml
    /// </summary>
    public partial class Questions : Window
    {
        private readonly QuestionnaireController _controller;
        private readonly int _numberOfQuestions;
        private int _numberOfCorrectAnswers;

        public Questions()
        {
            InitializeComponent();
        }

        public Questions(int complexity)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            _controller = new QuestionnaireController(complexity);
            _numberOfQuestions = _controller.GetNumberOfItems();

            SetNextFields();
        }

        private void SetNextFields()
        {
            Item item = _controller.GetCurrentItem();

            Question.Text = item.Question;
            List<Option> options = item.Options;
            OptionOne.Content = options[0].Value;
            OptionTwo.Content = options[1].Value;
            OptionThree.Content = options[2].Value;
        }

        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            if (_controller.GetNumberOfItems() > 1)
            {
                Item currentItem = _controller.GetCurrentItem();
                _controller.Remove(currentItem);
                SetNextFields();
            }
            else
            {
                Result result = new Result(_numberOfCorrectAnswers, _numberOfQuestions);
                result.Show();

                Close();
            }
        }

        private void OptionOne_OnChecked(object sender, RoutedEventArgs e)
        {
            UpdateNumberOfCorrectAnswers(0);
        }

        private void OptionTwo_OnChecked(object sender, RoutedEventArgs e)
        {
            UpdateNumberOfCorrectAnswers(1);
        }

        private void OptionThree_OnChecked(object sender, RoutedEventArgs e)
        {
            UpdateNumberOfCorrectAnswers(2);
        }

        private void UpdateNumberOfCorrectAnswers(int optionIndex)
        {
            Item item = _controller.GetCurrentItem();
            Option option = item.Options[optionIndex];

            if (option.Correct)
            {
                _numberOfCorrectAnswers++;
            }
        }
    }
}