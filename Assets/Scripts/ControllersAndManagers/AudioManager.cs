using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _source;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        _source = GetComponent<AudioSource>();
    }

    public void Shoot(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
