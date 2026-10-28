using System.Collections.Generic;
using UnityEngine;
public class MRMusicManager : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioSource audioSourceStartMusic;
	public static MRMusicManager Instance = null;
	
	void Awake()
	{
		if (Instance == null)
			Instance = this;

        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        this.audioSource = this.GetComponent<AudioSource>();
		this.SetAudioLister();
	}

	public bool IsMusicEnabled()
	{
		if (this.MUSIC_VOLUME > 0)
			return true;
		return false;
	}

	public void SetMusic(bool enabled)
	{
		if (enabled)
			this.MUSIC_VOLUME = 0.5f;
		else
			this.MUSIC_VOLUME = 0;
		this.SetAudioLister();

	}
	
	void SetAudioLister() {
		this.audioSource.volume = this.MUSIC_VOLUME;
		audioSourceStartMusic.volume = this.MUSIC_VOLUME;
	}

	public float MUSIC_VOLUME {
		get {
			return PlayerPrefs.GetFloat("MUSIC_VOLUME", 0.5f);
		}
		set {
			
			if (value > 1)
				value = 1;
				
			if (value < 0)
				value = 0;
				
			PlayerPrefs.SetFloat("MUSIC_VOLUME", value);
			this.SetAudioLister();
		}
	}
}

