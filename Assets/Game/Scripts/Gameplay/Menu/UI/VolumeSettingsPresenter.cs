using System;
using Game.Menu.Core;
using R3;
using Zenject;

namespace Game.Menu.UI
{
    public class VolumeSettingsPresenter : IInitializable, IDisposable
    {
        private const int DefaultValueCount = 1;

        private readonly IVolumeSettings _volumeSettings;
        private readonly VolumeSettingsView _view;

        private IDisposable _disposables;

        public VolumeSettingsPresenter(IVolumeSettings volumeSettings, VolumeSettingsView view)
        {
            _volumeSettings = volumeSettings;
            _view = view;
        }

        public void Initialize()
        {
            _view.Initialize(_volumeSettings.MusicVolume, _volumeSettings.EffectsVolume);

            var disposableBuilder = Disposable.CreateBuilder();

            _view.MusicVolume.Skip(DefaultValueCount)
                .Subscribe(_volumeSettings.SetMusicVolume)
                .AddTo(ref disposableBuilder);

            _view.EffectVolume.Skip(DefaultValueCount)
                .Subscribe(_volumeSettings.SetEffectsVolume)
                .AddTo(ref disposableBuilder);


            _disposables = disposableBuilder.Build();
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}