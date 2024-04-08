using UnityEngine;
using UnityEngine.UI;

namespace Client.Views
{
    public class KeyboardLetterView : LetterView
    {
        [field: SerializeField] public Button Button { get; private set; }
    }
}