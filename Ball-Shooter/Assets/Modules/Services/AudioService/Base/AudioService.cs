using System;
using Modules.Common;
using UnityEngine;

namespace Modules.Services.AudioService
{
    public class AudioService : IAudioService
    {
        private readonly MusicController _musicController;
        private readonly SoundController _soundController;

        public AudioService(MusicController musicController, SoundController soundController)
        {
            _musicController = musicController;
            _soundController = soundController;
        }

        public void PlayMusic()
        {
            _musicController.PlayMusic();
        }

        public void PlayOneShotSound(AudioClip clip, float volume, Action callback = null)
        {
            _soundController.PlayOneShotAndRelease(clip, volume, callback);
        }
    }
}