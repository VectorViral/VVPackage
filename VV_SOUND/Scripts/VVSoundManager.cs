// ==============================================================================
// VVPackage - Modular UI, Sound & Core Framework
// Copyright (c) 2024-2026 VECTOR VIRAL (SMC-PRIVATE) LIMITED
// Licensed under the MIT Open Source License.
// ==============================================================================

namespace VectorViral.Sound
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Serialization;
    using VectorViral.Core;

    public class VVSoundManager : MonoBehaviour
    {
        [SerializeField] bool dontDestroyOnLoad = false;

        AudioSource audioSource;
        [FormerlySerializedAs("mrSounds")]
        [SerializeField] List<vvSound> vvSounds;
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
            if (VVAppDataManager.Instance)
                this.audioSource.volume = VVAppDataManager.Instance.GetAppInstance().soundVolume;
            else
                this.audioSource.volume = 1;
        }

        public bool IsSoundEnabled()
        {
            if (VVAppDataManager.Instance.GetAppInstance().soundVolume > 0)
                return true;
            return false;
        }

        public void SetSoundEnabled(bool enabled)
        {
            if (enabled)
                VVAppDataManager.Instance.GetAppInstance().soundVolume = 1;
            else
                VVAppDataManager.Instance.GetAppInstance().soundVolume = 0;
            this.SetAudioLister();

            VVAppDataManager.Instance.SaveAppData();
        }

        public void Play(string uniqueName, bool oneShot = true)
        {
            vvSound sound = this.vvSounds.Find(p => p.uniqueName == uniqueName);
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
}
