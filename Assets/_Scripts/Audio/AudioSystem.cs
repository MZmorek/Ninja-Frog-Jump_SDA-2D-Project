using UnityEngine;

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
    #endregion

    #region Local

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip buttonSFX;
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
