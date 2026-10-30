namespace VectorViral.Sound
{
    using System.Collections.Generic;
    using UnityEngine;
    using VectorViral.Core;

    public class VVSoundManager : MonoBehaviour
    {
        [SerializeField] bool dontDestroyOnLoad = false;

        AudioSource audioSource;
        [SerializeField] List<vvSound> mrSounds;
        public static VVSoundManager Instance = null;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            if (this.dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);

            this.audioSource = this.GetComponent<AudioSource>();
            this.audioSource.volume = 0;
        }

   

        private void Start()
        {
 
            Initialize();
        }

        void Initialize()
        {
            SetAudioLister();
        }

        void SetAudioLister()
        {
            if (MRAppDataManager.Instance)
                this.audioSource.volume = MRAppDataManager.Instance.GetAppInstance().soundVolume;
            else
                this.audioSource.volume = 1;
        }

        public bool IsSoundEnabled()
        {
            if (MRAppDataManager.Instance.GetAppInstance().soundVolume > 0)
                return true;
            return false;
        }

        public void SetSoundEnabled(bool enabled)
        {
            if (enabled)
                MRAppDataManager.Instance.GetAppInstance().soundVolume = 1;
            else
                MRAppDataManager.Instance.GetAppInstance().soundVolume = 0;
            this.SetAudioLister();

            MRAppDataManager.Instance.SaveAppData();
        }

        public void Play(string uniqueName, bool oneShot = true)
        {
            vvSound sound = this.mrSounds.Find(p => p.uniqueName == uniqueName);
            PlaySound(sound, oneShot);
        }

        public void StopAll()
        {
            this.audioSource.Stop();
        }

        void PlaySound(vvSound sound, bool oneShot)
        {
            if (sound != null)
            {
                this.audioSource.pitch = sound.pitch;
                if (oneShot)
                    this.audioSource.PlayOneShot(sound.clips[Random.Range(0, sound.clips.Count)], sound.volume);
                else
                {
                    this.audioSource.clip = sound.clips[Random.Range(0, sound.clips.Count)];
                    this.audioSource.Play();
                }
            }
        }
    }

    // Backward-compatibility alias for existing scripts and prefabs
    public class MRSoundManager : VVSoundManager { }
}

