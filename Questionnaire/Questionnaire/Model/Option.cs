using System.ComponentModel;
using System.Runtime.CompilerServices;
using Questionnaire.Annotations;

namespace Questionnaire.Model
{
    public class Option: INotifyPropertyChanged
    {
        private bool _correct;
        private string _value;

        public Option(bool correct, string value)
        {
            Correct = correct;
            Value = value;
        }

        public bool Correct
        {
            get => _correct;
            set
            {
                if (value == _correct) return;
                _correct = value;

                var handler = PropertyChanged;
                handler?.Invoke(this,
                    new PropertyChangedEventArgs("Correct"));
            }
        }

        public string Value
        {
            get => _value;
            set
            {
                if (value == _value) return;
                _value = value;

                var handler = PropertyChanged;
                handler?.Invoke(this,
                    new PropertyChangedEventArgs("Value"));
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
