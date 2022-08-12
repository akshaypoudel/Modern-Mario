using System;
using TMPro;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;
    public SoundAudioClip[] soundAudioClipArray;

    private void Awake()
    {
        i = this;
    }


    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}
