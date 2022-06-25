using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SlotsMenu : MonoBehaviour
{
    public GameObject Button;
    public GameObject TelaCarregamento;

    [HideInInspector]
    public SaveController saveManager;

    void Awake()
    {
        saveManager = GameObject.Find("Slots").GetComponent<SaveController>();
    }

    [SerializeField]
    private Text _title;

    void Start()
    {
        _title.text = PlayerPrefs.GetString("save1");
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("save1", _title.text);
    }

    public void salvar()
    {
        TelaCarregamento.SetActive(true);
        _title.text = "Save 1: dia " + DateTime.Now;
        StartCoroutine(espera());
    }
    IEnumerator espera()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
    public void deletar()
    {
        _title.text = "Novo jogo";
        PlayerPrefs.DeleteKey(_title.text);
    }

}
