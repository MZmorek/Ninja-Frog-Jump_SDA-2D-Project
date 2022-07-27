using UnityEngine.UI;
using UnityEngine;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider generalSlider;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource generalSource;

    public void ChangeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
    }

    public void ChangeGeneralVolume()
    {
        generalSource.volume = generalSlider.value;
    }
}
