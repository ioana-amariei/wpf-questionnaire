using System.Collections.Generic;

namespace Questionnaire.Model
{
    public class Item
    {
        public int Complexity { get; set; }
        public string Question { get; set; }
        public List<Option> Options { get; set; }

        public Item(int complexity, string question, List<Option> options)
        {
            Complexity = complexity;
            Question = question;
            Options = options;
        }
    }
}
