using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotsMenu : MonoBehaviour
{
  
    SaveController saveManager;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _title2;

    void Start()
    {
        _title.text = PlayerPrefs.GetString("save1");
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("save1", _title.text);
    }

    public void save()
    {
        _title.text = "Save 1: dia " + DateTime.Now;
        SceneManager.LoadScene(2);
        saveManager.Load();
    }

    public void delete()
    {
        _title.text = "Novo jogo";
        PlayerPrefs.SetString("save1", _title.text);
        saveManager.Delete();
    }
}
