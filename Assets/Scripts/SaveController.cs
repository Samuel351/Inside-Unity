using UnityEngine;

public class SaveController : MonoBehaviour {

    public const string historia_key = "historia";
    public const string direita_key = "direita";
    public const string esquerda_key = "esquerda";

    public int saveHistoria = 1;
    public int saveDireita = 1;
    public int saveEsquerda = 1;

    public void Save(int historia, int direita, int esquerda)
    {
        saveHistoria = historia;
        saveDireita = direita;
        saveEsquerda = esquerda;
        PlayerPrefs.SetInt(historia_key, saveHistoria);
        PlayerPrefs.SetInt(direita_key, saveDireita);
        PlayerPrefs.SetInt(esquerda_key, saveEsquerda);
        PlayerPrefs.Save();
        Debug.Log("Jogo salvo!");
        Debug.Log("Valores salvos: | historia: " + historia + " | direita: " + direita + " | esquerda: " + esquerda);
    }
    public void Load()
    {
        GameLogic jogo = GameObject.Find("LogicaJogo").GetComponent<GameLogic>();
        saveHistoria = PlayerPrefs.GetInt(historia_key);
        saveDireita = PlayerPrefs.GetInt(direita_key);
        saveEsquerda = PlayerPrefs.GetInt(esquerda_key);

        jogo.id_historia = saveHistoria;
        jogo.id_direita = saveDireita;
        jogo.id_esquerda = saveEsquerda;
        Debug.Log("Jogo carregado!");
        Debug.Log("Valores carregados: | historia: " + jogo.id_historia + " | direita: " + jogo.id_direita + " | esquerda: " + jogo.id_esquerda);
    }

    public void Delete()
    {                                
        PlayerPrefs.DeleteKey(historia_key);
        PlayerPrefs.DeleteKey(direita_key);
        PlayerPrefs.DeleteKey(esquerda_key);
        Save(1, 1, 1);
        Debug.Log("Jogo deletado!");
    }
}