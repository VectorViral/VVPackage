using VectorViral.Core;
using VectorViral.Sound;
using UnityEngine;
public class MySandMManger : MonoBehaviour
{
    public static MySandMManger instance;

    public AudioClip MenuBg_Sound,GamePlay_Sound;
    public AudioSource musicSource,hoverboardSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    // Start is called before the first frame update
    void Start()
    {


        musicSource.volume = MRAppDataManager.Instance.GetAppInstance().musicVolume;
        hoverboardSource.volume = MRAppDataManager.Instance.GetAppInstance().soundVolume;
    }


    // set Values
    public void SoundSlider_Func(float sValue)
    {
        MRAppDataManager.Instance.GetAppInstance().soundVolume = sValue;
        MRAppDataManager.Instance.SaveAppData();
        hoverboardSource.volume = sValue;
    }
    public void MusicSlider_Func(float mValue)
    {
        MRAppDataManager.Instance.GetAppInstance().musicVolume = mValue;
        MRAppDataManager.Instance.SaveAppData();

        musicSource.volume = mValue;
        hoverboardSource.volume = mValue;
    }

    // Music Func
    public void PlayBGMusic_Func(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Sounds Funcs

    public void ButtonClickSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.ButtonClick);
    }
    public void DriftSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.DriftSound);
    }
    public void GameOverSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.GameOver_Sound);
    }
    public void PopUpOpenSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.PopUp_Sound);
    }
    public void PopUpCloseSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.PopUpClose_Sound);
    }
    public void VinylPickSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.Vinyl_Sound);
    }
    public void boostersClickSound_Func()
    {
        MRSoundManager.Instance.Play(vvSounds.BoostersClick);
    }
}
