using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Questionnaire.Annotations;

namespace Questionnaire.Model
{
    public class Item : INotifyPropertyChanged
    {
        private int _complexity;
        private string _question;
        private List<Option> _options;

        public Item(int complexity, string question, List<Option> options)
        {
            Complexity = complexity;
            Question = question;
            Options = options;
        }

        public int Complexity
        {
            get => _complexity;
            set
            {
                if (value == _complexity) return;
                _complexity = value;

                var handler = PropertyChanged;
                handler?.Invoke(this,
                    new PropertyChangedEventArgs("Complexity"));
            }
        }

        public string Question
        {
            get => _question;
            set
            {
                if (value == _question) return;
                _question = value;

                var handler = PropertyChanged;
                handler?.Invoke(this,
                    new PropertyChangedEventArgs("Question"));
            }
        }

        public List<Option> Options
        {
            get => _options;
            set
            {
                if (value == _options) return;
                _options = value;

                var handler = PropertyChanged;
                handler?.Invoke(this,
                    new PropertyChangedEventArgs("Options"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
