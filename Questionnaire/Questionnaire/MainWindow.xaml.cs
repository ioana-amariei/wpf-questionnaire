using System.Collections.Generic;
using System.Windows;
using Questionnaire.Models;
using Questionnaire.Services;

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
            QuestionnaireService service = new QuestionnaireService();
            IEnumerable<Item> items = service.GetRandomItems(3, 1);

            QuestionTextBlock.Visibility = Visibility.Visible;

            foreach (Item item in items)
            {
                QuestionTextBlock.Text += item.Question + "\n";
            }
        }
    }
}
