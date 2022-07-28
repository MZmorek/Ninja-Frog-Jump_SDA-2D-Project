using UnityEngine;
using UnityEngine.UI;

namespace FrogNinja.UI
{
    public class SettingsWindow : BaseWindow
    {
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider generalSlider;
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource generalSource;

        public void Button_EnterMenu()
        {
            EventManager.EnterMenuButton();
        }

        public void ChangeMusicVolume()
        {
            musicSource.volume = musicSlider.value;
        }

        public void ChangeGeneralVolume()
        {
            generalSource.volume = generalSlider.value;
        }

    }
}