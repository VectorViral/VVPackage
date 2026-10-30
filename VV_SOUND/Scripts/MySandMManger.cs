using VectorViral.Core;
using VectorViral.Sound;
using UnityEngine;

public class MySandMManger : MonoBehaviour
{
    public static MySandMManger instance;

    public AudioClip MenuBg_Sound, GamePlay_Sound;
    public AudioSource musicSource, hoverboardSource;

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

    void Start()
    {
        musicSource.volume = VVAppDataManager.Instance.GetAppInstance().musicVolume;
        hoverboardSource.volume = VVAppDataManager.Instance.GetAppInstance().soundVolume;
    }

    // Set Values
    public void SoundSlider_Func(float sValue)
    {
        VVAppDataManager.Instance.GetAppInstance().soundVolume = sValue;
        VVAppDataManager.Instance.SaveAppData();
        hoverboardSource.volume = sValue;
    }

    public void MusicSlider_Func(float mValue)
    {
        VVAppDataManager.Instance.GetAppInstance().musicVolume = mValue;
        VVAppDataManager.Instance.SaveAppData();

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
        VVSoundManager.Instance.Play(vvSounds.ButtonClick);
    }

    public void DriftSound_Func()
    {
        VVSoundManager.Instance.Play(vvSounds.DriftSound);
    }

    public void GameOverSound_Func()
    {
        VVSoundManager.Instance.Play(vvSounds.GameOver_Sound);
    }

    public void PopUpOpenSound_Func()
    {
        VVSoundManager.Instance.Play(vvSounds.PopUp_Sound);
    }

    public void PopUpCloseSound_Func()
    {
        VVSoundManager.Instance.Play(vvSounds.PopUpClose_Sound);
    }

    public void VinylPickSound_Func()
    {
        VVSoundManager.Instance.Play(vvSounds.Vinyl_Sound);
    }

    public void boostersClickSound_Func()
    {
        VVSoundManager.Instance.Play(vvSounds.BoostersClick);
    }
}
