namespace Questionnaire.Model
{
    public class Option
    {
        public bool Correct { get; set; }
        public string Value { get; set; }

        public Option(bool correct, string value)
        {
            Correct = correct;
            Value = value;
        }
    }
}
