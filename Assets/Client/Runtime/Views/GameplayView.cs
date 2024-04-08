using TMPro;

using UnityEngine;

namespace Client.Views
{
    public class GameplayView : BaseView
    {
        [SerializeField] private GameObject[] _hangmanStates;
        [SerializeField] private TMP_Text _playerStats;

        [field: SerializeField] public EndGameView EndGameView { get; private set; }
        [field: SerializeField] public Transform KeyboardRoot { get; private set; }
        [field: SerializeField] public Transform LettersRoot { get; private set; }

        public void SetHangmanState(int stateIndex)
        {
            for (int i = 0; i < _hangmanStates.Length; i++)
            {
                _hangmanStates[i].SetActive(stateIndex - i > 0);
            }
        }

        public void SetStats(int winsNumber, int defeatsNumber)
        {
            _playerStats.text = $"Выиграно: {winsNumber}. Проиграно: {defeatsNumber}.";
        }

        public void SetActiveKeyboard(bool state)
        {
            KeyboardRoot.gameObject.SetActive(state);
        }
    }
}