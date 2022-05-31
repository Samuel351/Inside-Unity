using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public int ID;

    [HideInInspector]
    public AudioMixerGroup mixer;

    public AudioClip clip;

    [Range(0f, 1f)]
    public static float volume;

    [HideInInspector]
    public AudioSource source;
}