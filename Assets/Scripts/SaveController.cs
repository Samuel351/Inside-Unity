using UnityEngine;

public class SaveController : MonoBehaviour
{
    Historia id;
    SlotsMenu menu;

    public const string historia_key = "historia";
    public const string direita_key = "direita";
    public const string esquerda_key = "esquerda";

    void Awake()
    {
        id = GetComponent<Historia>();
        menu = GetComponent<SlotsMenu>();
    }
    public void Save(int historia, int direita, int esquerda)
    {
        PlayerPrefs.SetInt(historia_key, historia);
        PlayerPrefs.SetInt(direita_key, direita);
        PlayerPrefs.SetInt(esquerda_key, esquerda);
        PlayerPrefs.Save();
        Debug.Log("Jogo salvo!");
    }
    public void Load()
    {
        id.estoria = PlayerPrefs.GetInt(historia_key);
        id.direita = PlayerPrefs.GetInt(direita_key);
        id.esquerda = PlayerPrefs.GetInt(esquerda_key);
        Debug.Log("Jogo carregado!");
    }
    public void Delete()
    {
        PlayerPrefs.DeleteKey(historia_key);
        PlayerPrefs.DeleteKey(direita_key);
        PlayerPrefs.DeleteKey(esquerda_key);
        Debug.Log("Jogo deletado!");
    }
}