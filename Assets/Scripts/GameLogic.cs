using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class GameLogic : MonoBehaviour
{

    public AudioMixerGroup mixer;
    public Sound[] historia;
    public Sound[] esquerda;
    public Sound[] direita;
    private Sound somSource;
    private int input = 1;
    private SaveController saveController = new SaveController();
    [HideInInspector]
    public Sound som;

    private int id_historia = 1;
    private int id_direita = 1;
    private int id_esquerda = 1;

    public static GameLogic instance;

    void Awake()
    {
        Debug.Log(id_historia);
        GameLogic instancia = GameObject.Find("AudioController").GetComponent<GameLogic>();
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound som in historia)
        {
            som.source = gameObject.AddComponent<AudioSource>();
            som.source.clip = som.clip;
            som.source.volume = Sound.volume;
            som.source.outputAudioMixerGroup = mixer;
        }

        foreach (Sound som2 in esquerda)
        {
            som2.source = gameObject.AddComponent<AudioSource>();
            som2.source.clip = som2.clip;
            som2.source.volume = Sound.volume;
            som2.source.outputAudioMixerGroup = mixer;
        }

        foreach (Sound som3 in direita)
        {
            som3.source = gameObject.AddComponent<AudioSource>();
            som3.source.clip = som3.clip;
            som3.source.volume = Sound.volume;
            som3.source.outputAudioMixerGroup = mixer;
        }
        Play(0, "instancia", esquerda);
        Play(0, "instancia", direita);
        Play(0, "instancia", historia);
        StartCoroutine(Historia());
    }

    void Update()
    {
        if (!somSource.source.isPlaying)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine(eEsquerda());
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine(eDireita());
            }
        }
    }

    IEnumerator Historia()
    {
       yield return null;
        if (id_historia == 1)
        {
           Play(1, "NarracaoInicial", historia);
        }
        else if (id_historia == 2)
        {
           Play(2, "Escolha2", historia);
        }
        else if (id_historia == 3)
        {
            Play(3, "Escolha3", historia);
        }
        else if (id_historia == 4)
        {
            Play(4, "Escolha4", historia);
        }
        else if (id_historia == 5)
        {
            Play(5, "Escolha5", historia);
        }
        else if (id_historia == 6)
        {
            Play(6, "Escolha6", historia);
        }
        Debug.Log("Historia: " + id_historia);
        id_historia++;
        while (somSource.source.isPlaying)
        {
            yield return null;
        }
        Update();
    }

    IEnumerator eEsquerda()
    {
        if(id_esquerda == 1)
        {
            Play(1, "sim", esquerda);
        }
        else if (id_esquerda == 2)
        {
            Play(2, "LadoEsquerdo", esquerda);
        }
        else if (id_esquerda == 3)
        {
            Play(3, "Fugir", esquerda);
        }
        else if (id_esquerda == 4)
        {
            Play(4, "sim_arma", esquerda);
        }
        else if (id_esquerda == 5)
        {
            Play(5, "Ajudar", esquerda);
        }
        else if (id_esquerda == 6)
        {
            Play(6, "Confortar", esquerda);
        }
        Debug.Log("Esquerda: " + id_esquerda);
        id_esquerda++;
        id_direita++;
        while (somSource.source.isPlaying)
        {
            yield return null;
        }
        StartCoroutine(Historia());
        StopCoroutine(eDireita());
    }

    IEnumerator eDireita()
    {
        if (id_direita == 1)
        {
            Play(1, "não", direita);
        }
        else if (id_direita == 2)
        {
            Play(2, "LadoDireito", direita);
        }
        else if (id_esquerda == 3)
        {
            Play(3, "Lutar", direita);
        }
        else if (id_esquerda == 4)
        {
            Play(4, "não_arma", direita);
        }
        else if (id_esquerda == 5)
        {
            Play(5, "Bater com arma", direita);
        }
        else if (id_esquerda == 6)
        {
            Play(6, "Fugir", direita);
        }
        Debug.Log("Direita: " + id_direita);
        id_direita++;
        id_esquerda++;
        while (somSource.source.isPlaying)
        {
            yield return null;
        }
        StartCoroutine(Historia());
        StopCoroutine(eDireita());
    }

    // Funções que buscam os aúdios no vetores por nome
    public void Play(int id, string name, Sound[] vetor)
    {
        somSource = Array.Find(vetor, som => som.name == name && som.id == id);
        if (som == null)
        {
            Debug.LogWarning("O som: " + name + " não foi encontrado!");
        }
        somSource.source.Play();
    }

}
