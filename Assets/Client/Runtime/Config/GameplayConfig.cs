using UnityEngine;

namespace Client.Config
{
    [CreateAssetMenu(fileName = nameof(GameplayConfig), menuName = "Client/" + nameof(GameplayConfig), order = 0)]
    public class GameplayConfig : ScriptableObject
    {
        [field: SerializeField] public string[] WordsPool { get; private set; }
        [field: SerializeField] public string LettersPool { get; private set; }
        [field: SerializeField] public int PossibleNumberOfErrors { get; private set; }
        
        [field: Header("EndGame")]
        [field: SerializeField] public string WinText { get; private set; }
        [field: SerializeField] public string DefeatText { get; private set; }
    }
}