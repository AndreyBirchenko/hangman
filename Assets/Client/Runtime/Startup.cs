using Client.Config;
using Client.Runtime.Utils;

using UnityEngine;

using VContainer;
using VContainer.Unity;

namespace Client
{
    public class Startup : LifetimeScope
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private GameplayConfig _gameplayConfig;
        [SerializeField] private VisualConfig _visualConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            var startGameView = Instantiate(_visualConfig.StartViewPrefab, _mainCanvas.transform);
            var gameplayView = Instantiate(_visualConfig.GameplayViewPrefab, _mainCanvas.transform);
            builder.RegisterInstance(startGameView);
            builder.RegisterInstance(gameplayView);
            builder.RegisterInstance(_gameplayConfig);
            builder.RegisterInstance(_visualConfig);

            builder.RegisterInstance(new LettersRepository(() =>
                    new LetterModel(Instantiate(_visualConfig.LetterViewPrefab, gameplayView.LettersRoot))))
                .AsImplementedInterfaces().AsSelf();

            builder.Register<KeyboardRepository>(resolver =>
            {
                var repository = new KeyboardRepository(() => new KeyboardLetterModel(Instantiate(
                    _visualConfig.KeyboardLetterViewPrefab,
                    gameplayView.KeyboardRoot)));
                resolver.Inject(repository);
                return repository;
            }, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<GameplayModel>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.RegisterEntryPoint<GameplayController>();
        }
    }
}