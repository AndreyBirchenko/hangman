using Client.Views;

using UnityEngine;

namespace Client.Config
{
    [CreateAssetMenu(fileName = nameof(VisualConfig), menuName = "Client/" + nameof(VisualConfig), order = 0)]
    public class VisualConfig : ScriptableObject
    {
        [field: SerializeField] public StartGameView StartViewPrefab { get; private set; }
        [field: SerializeField] public GameplayView GameplayViewPrefab { get; private set; }
        [field: SerializeField] public LetterView LetterViewPrefab { get; private set; }
        [field: SerializeField] public KeyboardLetterView KeyboardLetterViewPrefab { get; private set; }
        
    }
}