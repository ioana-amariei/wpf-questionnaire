using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Questionnaire.Model;
using Questionnaire.Services;

namespace Questionnaire.View
{
    /// <summary>
    /// Interaction logic for Questions.xaml
    /// </summary>
    public partial class Questions : Window
    {
        private readonly QuestionnaireService _service = new QuestionnaireService();
        private readonly List<Item> _items = new List<Item>();
        private const int NumberOfItems = 5;
        private readonly int _numberOfQuestions = 0;
        private int _numberOfCorrectAnswers = 0;

        public Questions()
        {
            InitializeComponent();
        }

        public Questions(int complexity)
        {
            InitializeComponent();

            _items = _service.GetRandomItems(NumberOfItems, complexity).ToList();
            _numberOfQuestions = _items.Count;

            SetNextFields();
        }

        private void SetNextFields()
        {
            Item item = CurrentItem();

            Question.Text = item.Question;
            List<Option> options = item.Options;
            OptionOne.Content = options[0].Value;
            OptionTwo.Content = options[1].Value;
            OptionThree.Content = options[2].Value;
        }

        private Item CurrentItem()
        {
            return _items.FirstOrDefault();
        }

        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            if (_items.Count > 1)
            {
                _items.Remove(CurrentItem());
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
            Item item = CurrentItem();
            Option option = item.Options[0];

            if (option.Correct)
            {
                _numberOfCorrectAnswers++;
            }
        }

        private void OptionTwo_OnChecked(object sender, RoutedEventArgs e)
        {
            Item item = CurrentItem();
            Option option = item.Options[1];

            if (option.Correct)
            {
                _numberOfCorrectAnswers++;
            }
        }

        private void OptionThree_OnChecked(object sender, RoutedEventArgs e)
        {
            Item item = CurrentItem();
            Option option = item.Options[2];

            if (option.Correct)
            {
                _numberOfCorrectAnswers++;
            }
        }
    }
}