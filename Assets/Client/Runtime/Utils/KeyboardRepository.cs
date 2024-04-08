using System;
using System.Collections.Generic;

using Client.Config;

using VContainer;
using VContainer.Unity;

namespace Client.Runtime.Utils
{
    public class KeyboardRepository : IInitializable
    {
        [Inject] private readonly GameplayConfig _gameplayConfig;
        
        private Func<KeyboardLetterModel> _createFunc;

        public KeyboardRepository(Func<KeyboardLetterModel> createFunc)
        {
            _createFunc = createFunc;
        }
        
        public List<KeyboardLetterModel> ActiveElements { get; private set; } = new();

        
        void IInitializable.Initialize()
        {
            for (int i = 0; i < _gameplayConfig.LettersPool.Length; i++)
            {
                var letter = _gameplayConfig.LettersPool[i];
                var keyboardLetter = _createFunc();
                keyboardLetter.Value = letter;
                ActiveElements.Add(keyboardLetter);
            }
        }
    }
}