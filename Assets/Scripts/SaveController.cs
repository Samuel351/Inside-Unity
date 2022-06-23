using UnityEngine;

public class SaveController
{
    public const string historia_key = "historia";
    public const string direita_key = "direita";
    public const string esquerda_key = "esquerda";


    public void Save(int historia, int direita, int esquerda)
    {
        PlayerPrefs.SetInt(historia_key, historia);
        PlayerPrefs.SetInt(direita_key, direita);
        PlayerPrefs.SetInt(esquerda_key, esquerda);
        PlayerPrefs.Save();
        Debug.Log("Jogo salvo!");
        Debug.Log("Valores salvos: | historia: " + historia + " | direita: " + direita + " | esquerda: " + esquerda);
    }
    public void Load()
    {
        GameLogic id = new GameLogic();
        id.id_historia = PlayerPrefs.GetInt(historia_key);
        id.id_direita = PlayerPrefs.GetInt(direita_key);
        id.id_esquerda = PlayerPrefs.GetInt(esquerda_key);
        Debug.Log("Jogo carregado!");
        Debug.Log("Valores carregados: | historia: " + id.historia + " | direita: " + id.direita + " | esquerda: " + id.esquerda);
    }
    public void Delete()
    {                                
        PlayerPrefs.DeleteKey(historia_key);
        PlayerPrefs.DeleteKey(direita_key);
        PlayerPrefs.DeleteKey(esquerda_key);
        Debug.Log("Jogo deletado!");
    }
}