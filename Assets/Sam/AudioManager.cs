using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ------- Audio Sources -------
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;
    
    // ----- Audio Clips --------
    public AudioClip background;
    public AudioClip dead;
    public AudioClip win;
    public AudioClip coinget;
    public AudioClip jump;
    public AudioClip walking;
    public AudioClip flying;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        SFXSource.ignoreListenerPause = true;
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
