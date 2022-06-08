using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public int id;
    public string name;

    [HideInInspector]
    public AudioMixerGroup mixer;

    public AudioClip clip;

    [Range(0f, 1f)]
    public static float volume = 1f;

    [HideInInspector]
    public AudioSource source;
}