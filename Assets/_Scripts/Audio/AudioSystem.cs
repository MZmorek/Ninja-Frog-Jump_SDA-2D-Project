using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    #region Global
    private static AudioSystem Instance;

    public static void PlaySFX_Global(AudioClip audioClip)
    {
        if (Instance == null)
        {
            return;
        }

        Instance.PlaySFX_Local(audioClip);
    }

    public static void PlayButtonSFX_Global()
    {
        if (Instance == null)
        {
            return;
        }

        Instance.PlaySFX_Local(Instance.buttonSFX);
    }
    public static void SwitchMusic_Global(bool play)
    {
        if (Instance == null)
        {
            return;
        }
        if (!play)
        {
            Instance.musicSource.Pause();
        }
        else if (!Instance.musicSource.isPlaying)
        {
            Instance.musicSource.Play();
        }
    }

    public static void PlayPauseSFX_Global(bool pause)
    {
        if (Instance == null)
            return;

        if (pause)
        {
            Instance.sfxSource.PlayOneShot(Instance.pauseSFX);
        }
        else
        {
            Instance.sfxSource.PlayOneShot(Instance.unpauseSFX);
        }

    }

    #endregion

    #region Local

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip buttonSFX;
    [SerializeField] private AudioClip pauseSFX;
    [SerializeField] private AudioClip unpauseSFX;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void PlaySFX_Local(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip);
    }
    #endregion
}
