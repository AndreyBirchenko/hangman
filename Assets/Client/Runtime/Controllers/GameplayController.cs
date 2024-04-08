using System.Linq;

using Client.Config;
using Client.Runtime.Utils;
using Client.Views;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace Client
{
    public class GameplayController : IStartable
    {
        [Inject] private readonly VisualConfig _visualConfig;
        [Inject] private readonly GameplayConfig _gameplayConfig;
        [Inject] private readonly GameplayModel _gameplayModel;
        [Inject] private readonly GameplayView _gameplayView;
        [Inject] private readonly StartGameView _startGameView;
        [Inject] private readonly LettersRepository _lettersRepository;
        [Inject] private readonly KeyboardRepository _keyboardRepository;

        private EndGameView _endGameView;
        
        void IStartable.Start()
        {
            _gameplayView.SetActive(false);

            _startGameView.StartButton.onClick.AddListener(ShowMainGameplay);
            _startGameView.SetActive(true);

            _endGameView = _gameplayView.EndGameView;
            _endGameView.Button.onClick.AddListener(SetupGameplay);
            
            foreach (var keyboardLetter in _keyboardRepository.ActiveElements)
            {
                keyboardLetter.AddButtonHandler(() => HandleKeyboardButtonClicked(keyboardLetter.Value));
            }
            
            SetupGameplay();
        }

        private void ShowMainGameplay()
        {
            _gameplayView.SetActive(true);
            _startGameView.SetActive(false);
        }

        private void SetupGameplay()
        {
            _gameplayView.SetActiveKeyboard(true);
            _endGameView.SetActive(false);
            _lettersRepository.Clear();
            _gameplayModel.ErrorsCount = 0;
            
            var currentWord = _gameplayModel.CurrentWord;
            Debug.Log(currentWord);
            for (int i = 0; i < currentWord.Length; i++)
            {
                var letter = _lettersRepository.Get();
                letter.Position = i;
                letter.Value = currentWord[i];
                letter.ValueState = false;
            }
        }

        private void HandleKeyboardButtonClicked(char letter)
        {
            bool letterOpened = false;

            for (int i = 0; i < _lettersRepository.ActiveElements.Count; i++)
            {
                var currentLetter = _lettersRepository.ActiveElements[i];
                if (letter != currentLetter.Value)
                    continue;

                currentLetter.ValueState = true;
                letterOpened = true;
            }

            if (!letterOpened)
                _gameplayModel.ErrorsCount++;
            
            TryEndGame();
        }


        private void TryEndGame()
        {
            if (_gameplayModel.ErrorsCount == _gameplayConfig.PossibleNumberOfErrors)
            {
                _gameplayView.SetActiveKeyboard(false);
                _endGameView.SetActive(true);
                _endGameView.SetText(_gameplayConfig.DefeatText);
                _gameplayModel.DefeatsNumber++;
            }

            if (_lettersRepository.ActiveElements.All(x => x.ValueState))
            {
                _gameplayView.SetActiveKeyboard(false);
                _endGameView.SetActive(true);
                _endGameView.SetText(_gameplayConfig.WinText);
                _gameplayModel.WinsNumber++;
            }
        }
    }
}