using Client.Views;

namespace Client
{
    public class LetterModel
    {
        private readonly LetterView _view;
        private bool _active;
        private bool _valueState;
        private char _value;
        private int _position;

        public LetterModel(LetterView view)
        {
            _view = view;
        }

        public bool Active
        {
            get => _active;
            set { _active = value; _view.SetActive(value); }
        }

        public bool ValueState
        {
            get => _valueState;
            set { _valueState = value; _view.SetValueState(value); }
        }

        public char Value
        {
            get => _value;
            set { _value = value; _view.SetText(_value.ToString()); }
        }

        public int Position
        {
            get => _position;
            set { _position = value; _view.SetPosition(value); }
        }
    }
}