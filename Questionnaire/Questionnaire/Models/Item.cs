using System.Collections.Generic;

namespace Questionnaire.Models
{
    public class Item
    {
        public int Complexity { get; set; }
        public string Question { get; set; }
        public List<Option> Options { get; set; }

        public Item(int complexity, string question, List<Option> options)
        {
            this.Complexity = complexity;
            Question = question;
            this.Options = options;
        }
    }
}
