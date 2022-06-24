using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    
    [SerializeField] AudioMixer mixer;
    [SerializeField] public Slider Geral;

    public const string MIXER_MUSICA = "Musica";

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            EventSystem.current.SetSelectedGameObject(Geral.gameObject);
            mixer.SetFloat(MIXER_MUSICA, Mathf.Log10(Geral.value) * 20);
            if(Geral.maxValue == Geral.value)
            {
                Geral.value = Geral.minValue;
            }
        }
    }
    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(Geral.gameObject);
        Geral.onValueChanged.AddListener(SetVolume);
        Geral.value = PlayerPrefs.GetFloat("sliderMusica");
    }

    void Start()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSICA_CHAVE, Geral.value);
        PlayerPrefs.SetFloat("sliderMusica", Geral.value);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSICA_CHAVE, Geral.value);
        PlayerPrefs.SetFloat("sliderMusica", Geral.value);
        PlayerPrefs.Save();
    }

    void SetVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSICA, Mathf.Log10(value) * 20);
    }
}