using System.Collections.Generic;
using System.Linq;
using Questionnaire.Model;
using Questionnaire.Service;

namespace Questionnaire.ViewModel
{
    public class QuestionnaireController
    {
        private readonly List<Item> _items;

        public QuestionnaireController(int complexity)
        {
            var service = new QuestionnaireService();
            _items = service.GetRandomItems(complexity).ToList();
        }

        public string GetOption(int index)
        {
            return GetCurrentItem().Options[index].Value;
        }

        public Item GetCurrentItem()
        {
            return _items.FirstOrDefault();
        }

        public int GetNumberOfItems()
        {
            return _items.Count;
        }

        public void Remove(Item item)
        {
            _items.Remove(item);
        }
    }
}
