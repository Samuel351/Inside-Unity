using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    GameLogic instancia;
    public AudioMixerGroup mixer;
    public Sound[] historia;
    public Sound[] escolha;
    private int input = 1;
    [HideInInspector]
    public Sound som;

    private int estoria = 0, direita = 0, esquerda = 0;
    public static GameLogic instance;

    void Awake()
    {
        instancia = GameObject.Find("AudioController").GetComponent<GameLogic>();
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

        foreach (Sound som2 in escolha)
        {
            som2.source = gameObject.AddComponent<AudioSource>();
            som2.source.clip = som2.clip;
            som2.source.volume = Sound.volume;
            som2.source.outputAudioMixerGroup = mixer;
        }
        Play(1, "historia", historia);
        Play(0, "instancia", escolha);
        Update();
    }
    void Update()
    {
        StartCoroutine(Escolhas());
    }

    IEnumerator Escolhas()
    {
        if (!som.source.isPlaying)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                eEsquerda();
                yield return new WaitUntil(() => som.source.isPlaying == false);
                pHistoria();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                eDireita();
                yield return new WaitUntil(() => som.source.isPlaying == false);
                pHistoria();
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            som.source = GetComponent<AudioSource>();
            som.source.Pause();
        }
    }

    public void pHistoria()
    {
        if (estoria == 0)
        {
            Play(1, "historia", historia);
        }
        else if (estoria == 1)
        {
            Play(2, "historia2", historia);
        }
        else if (estoria == 2)
        {
            Play(2, "historia2", historia);
        }
        estoria++;
    }
    public void eDireita()
    {
        if (direita == 0)
        {
            Play(2, "direita", escolha);
        }
        else if (direita == 1)
        {
            Play(4, "direita2", escolha);
        }
        direita++;
        esquerda++;
    }
    public void eEsquerda()
    {
        if (esquerda == 0)
        {
            Play(1, "esquerda", escolha);
        }
        else if (esquerda == 1)
        {
            Play(3, "esquerda2", escolha);
        }
        esquerda++;
        direita++;
    }

    // Funções que buscam os aúdios no vetores por nome
    public void Play(int id, string name, Sound[] vetor)
    {
        som = Array.Find(vetor, som => som.name == name && som.id == id);
        if (som == null)
        {
            Debug.LogWarning("O som: " + name + " não foi encontrado!");
            return;
        }
        som.source.Play();
    }
}

