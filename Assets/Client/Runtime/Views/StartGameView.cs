using UnityEngine;
using UnityEngine.UI;

namespace Client.Views
{
    public class StartGameView : BaseView
    {
        [field: SerializeField] public Button StartButton { get; private set; }
    }
}