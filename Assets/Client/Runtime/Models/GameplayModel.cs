using System.Linq;

using Client.Config;
using Client.Runtime.Utils;
using Client.Views;

using VContainer;
using VContainer.Unity;

namespace Client
{
    public class GameplayModel : IInitializable
    {
        [Inject] private readonly GameplayConfig _gameplayConfig;
        [Inject] private readonly GameplayView _gameplayView;

        private string[] _wordsPool;
        private int _wordsIndex;
        private int _errorsCount;
        private int _winsNumber;
        private int _defeatsNumber;

        public string CurrentWord => _wordsPool.WrapAndGet(WinsNumber + DefeatsNumber);

        public int ErrorsCount
        {
            get => _errorsCount;
            set { _errorsCount = value; _gameplayView.SetHangmanState(value); }
        }

        public int WinsNumber
        {
            get => _winsNumber;
            set { _winsNumber = value; _gameplayView.SetStats(_winsNumber, _defeatsNumber); }
        }

        public int DefeatsNumber
        {
            get => _defeatsNumber;
            set { _defeatsNumber = value; _gameplayView.SetStats(_winsNumber, _defeatsNumber); }
        }

        void IInitializable.Initialize()
        {
            _wordsPool = _gameplayConfig.WordsPool.ToArray();
            _wordsPool.Shuffle();
            WinsNumber = 0;
        }
    }
}