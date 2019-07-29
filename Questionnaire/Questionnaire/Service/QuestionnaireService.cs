using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Questionnaire.Model;

namespace Questionnaire.Service
{
    public class QuestionnaireService
    {
        public IEnumerable<Item> GetRandomItems(int complexity)
        {
            IEnumerable<Item> items = GetItemsWithComplexity(complexity);
            return Randomize(items);
        }
        
        private IEnumerable<Item> GetItemsWithComplexity(int complexity)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-overview
            var filename = "questions.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var questionsFilepath = Path.Combine(currentDirectory, filename);

            XElement questionnaire = XElement.Load($"{questionsFilepath}");

            return questionnaire.Descendants("item")
                .Select(ToItemModel)
                .Where(item => item.Complexity == complexity)
                .ToList();
        }

        private Item ToItemModel(XElement item)
        {
            int complexity = (int) item.Attribute("complexity");
            string question = (string) item.Element("question");
            List<Option> options = item.Element("options")?.Elements().Select(ToOptionModel).ToList();

            return new Item(complexity, question, options);
        }

        private Option ToOptionModel(XElement option)
        {
            bool correct =  (option.Attribute("correct") != null);
            string value = (string) option;

            return new Option(correct, value);
        }

        // http://www.ookii.org/Blog/randomizing_a_list_with_linq
        private IEnumerable<T> Randomize<T>(IEnumerable<T> source)
        {
            Random random = new Random();
            return source.OrderBy((item) => random.Next());
        }
    }
}