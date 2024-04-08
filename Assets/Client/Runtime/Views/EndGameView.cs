using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Client.Views
{
    public class EndGameView : BaseView
    {
        [SerializeField] private TMP_Text _text;
        [field: SerializeField] public Button Button { get; private set; }

        public void SetText(string value)
        {
            _text.text = value;
        }
    }
}