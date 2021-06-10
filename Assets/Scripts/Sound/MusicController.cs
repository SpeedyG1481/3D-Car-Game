using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (GameController.CurrentPlayingLevel - 1 < audioClips.Length)
        {
            _audioSource.volume = GameController.GetMusicVolume;
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = audioClips[GameController.CurrentPlayingLevel - 1];
                _audioSource.Play();
            }
        }
    }
}