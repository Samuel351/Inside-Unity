using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlotsMenu : MonoBehaviour
{
    [HideInInspector]
    public SaveController saveManager;

    void Awake()
    {
        saveManager = new SaveController();
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

    public void save()
    {
        _title.text = "Save 1: dia " + DateTime.Now;
        SceneManager.LoadScene(2);
    }

}
