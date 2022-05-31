using UnityEngine;

public class SaveController : MonoBehaviour
{
    Historia id;
    MainMenu pause;

    public const string historia_key = "historia";
    public const string direita_key = "direita";
    public const string esquerda_key = "esquerda";

    void Awake()
    {
        id = GetComponent<Historia>();
        pause = GetComponent<MainMenu>();
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
        int historia = PlayerPrefs.GetInt(historia_key);
        int direita = PlayerPrefs.GetInt(direita_key);
        int esquerda = PlayerPrefs.GetInt(esquerda_key);
        id.estoria = historia;
        id.direita = direita;
        id.esquerda = esquerda;
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