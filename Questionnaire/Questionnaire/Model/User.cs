namespace Questionnaire.Model
{
    public class User
    {
        public string Name { get; set; }
        public int ChosenComplexity { get; set; }

        public User(string name, int chosenComplexity)
        {
            Name = name;
            ChosenComplexity = chosenComplexity;
        }
    }
}