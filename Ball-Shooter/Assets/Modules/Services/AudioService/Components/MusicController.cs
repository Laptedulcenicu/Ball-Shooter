using System.Collections.Generic;
using UnityEngine;

namespace Modules.Services.AudioService
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private List<MusicPlaylist> musicPlaylists;

        private IMusicPlaylist _currentPlaylist;

        private bool IsPlaylistAvailable => _currentPlaylist is { HasTracks: true };

        private void Awake()
        {
            DontDestroyOnLoad(this);
            audioSource.playOnAwake = false;
        }

        private void Update()
        {
            if (!audioSource.isPlaying)
            {
                PlayNextTrack();
            }
        }

        private void PlayNextTrack()
        {
            if (!IsPlaylistAvailable)
            {
                return;
            }

            audioSource.clip = _currentPlaylist.GetNextTrack();
            audioSource.Play();
        }

        private void Play()
        {
            _currentPlaylist = musicPlaylists[Random.Range(0, musicPlaylists.Count)];
            if (!IsPlaylistAvailable)
            {
                return;
            }

            audioSource.clip = _currentPlaylist.GetNextTrack();
            audioSource.Play();
        }

        private void Stop()
        {
            audioSource.Stop();
            _currentPlaylist = null;
        }

        public void PlayMusic()
        {
            Stop();
            Play();
        }

        public void Pause()
        {
            audioSource.Pause();
        }

        public void UnPause()
        {
            audioSource.UnPause();
        }
    }
}