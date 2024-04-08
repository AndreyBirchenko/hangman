using TMPro;

using UnityEngine;

namespace Client.Views
{
    public class LetterView : BaseView
    {
        [SerializeField] private TMP_Text _textComponent;

        public void SetText(string text)
        {
            _textComponent.text = text.ToUpper();
        }

        public void SetValueState(bool state)
        {
            _textComponent.gameObject.SetActive(state);
        }

        public void SetPosition(int value)
        {
            transform.SetSiblingIndex(value);
        }
    }
}