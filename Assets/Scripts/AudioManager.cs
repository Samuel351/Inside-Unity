using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;

    public const string MUSICA_CHAVE = "musicaVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        carregaVolume();
    }

    void carregaVolume()
    {
        Sound.volume = PlayerPrefs.GetFloat(MUSICA_CHAVE, 1f);
        mixer.SetFloat(OptionsMenu.MIXER_MUSICA, Mathf.Log10(Sound.volume) * 10);
    }
}