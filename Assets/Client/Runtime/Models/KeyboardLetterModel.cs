using System;

using Client.Views;

namespace Client
{
    public class KeyboardLetterModel : LetterModel
    {
        private KeyboardLetterView _view;
        public KeyboardLetterModel(KeyboardLetterView view) : base(view)
        {
            _view = view;
        }

        public void AddButtonHandler(Action handler)
        {
            _view.Button.onClick.AddListener(handler.Invoke);
        }
    }
}