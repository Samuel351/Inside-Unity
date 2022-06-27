using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SlotsMenu : MonoBehaviour
{
    public GameObject Button;
    public GameObject TelaCarregamento;

    [SerializeField]
    public Text _title;

    [HideInInspector]
    public SaveController saveManager;

    public AudioSource SemSave;
    public AudioSource SaveDeletado;
    public AudioSource Carregando;

    [SerializeField]
    public AudioSource NovoJogo;

    public AudioSource JogarOndeParou;

    [SerializeField]
    public AudioSource jogo;
    void Awake()
    {
        saveManager = GameObject.Find("Slots").GetComponent<SaveController>();
    }

    void Start()
    {
        if(MiniTutorial.final == false)
        {
            _title.text = PlayerPrefs.GetString("save1");
        }
        else
        {
            final(MiniTutorial.final);
        }
        if(_title.text != "Novo jogo")
        {
            jogo.clip = JogarOndeParou.clip;
        }
        else
        {
            jogo.clip = NovoJogo.clip;
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("save1", _title.text);
    }

    public void salvar()
    {
        jogo.clip = JogarOndeParou.clip;
        TelaCarregamento.SetActive(true);
        _title.text = "Save 1: dia " + DateTime.Now;
        StartCoroutine(espera());
    }
    IEnumerator espera()
    {
        Carregando.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
    public void deletar()
    {
        if(_title.text != "Novo jogo")
        {
            jogo.clip = NovoJogo.clip;
            SaveDeletado.Play();
            _title.text = "Novo jogo";
            PlayerPrefs.DeleteKey(_title.text);
        }
        else
        {
            SemSave.Play();
        }
        
    }

    public void final(bool final)
    {
        if(final == true)
        {
            jogo.clip = NovoJogo.clip;
            _title.text = "Novo jogo";
            MiniTutorial.final = false;
        }
    }

}
