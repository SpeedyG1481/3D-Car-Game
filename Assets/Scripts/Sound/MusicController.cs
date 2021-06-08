using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_audioSource != null && GameController.CurrentPlayingLevel - 1 < audioClips.Length)
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