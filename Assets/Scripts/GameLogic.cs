using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class GameLogic : MonoBehaviour
{

    public AudioMixerGroup mixer;
    public Sound[] historia;
    public Sound[] escolha;
    private int input = 1;
    private SaveController saveController = new SaveController();
    [HideInInspector]
    public Sound som;

    [HideInInspector]
    public int estoria, direita, esquerda;

    public static GameLogic instance;

    void Awake()
    {
        saveController.Save(estoria, direita, esquerda);
        saveController.Load();
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

        foreach (Sound som2 in escolha)
        {
            som2.source = gameObject.AddComponent<AudioSource>();
            som2.source.clip = som2.clip;
            som2.source.volume = Sound.volume;
            som2.source.outputAudioMixerGroup = mixer;
        }

        if (estoria == 0)
        {
            Play(1, "NarracaoInicial", historia);
            estoria++;
            Play(0, "instancia", escolha);
            Update();
        }
        else
        {
            Play(estoria, "Escolha" + estoria, historia);
        }
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
        if(Input.GetKey(KeyCode.Space))
        {
            saveController.Delete();
        }
    }

    public void pHistoria()
    {
        if (estoria == 2)
        {
            Play(2, "Escolha2", historia);
        }
        else if (estoria == 3)
        {
            Play(3, "Escolha3", historia);
        }
        else if (estoria == 4)
        {
            Play(4, "Escolha4", historia);
        }
        else if (estoria == 5)
        {
            Play(5, "Escolha5", historia);
        }
        else if (estoria == 6)
        {
            Play(6, "Escolha6", historia);
        }
        estoria++;
        saveController.Save(estoria-1, direita-1, esquerda-1);
    }
    public void eDireita()
    {
        if (direita == 0)
        {
            Play(2, "não", escolha);
        }
        else if (direita == 1)
        {
            Play(4, "direita2", escolha);
        }
        direita++;
        esquerda++;
        saveController.Save(estoria-1, direita-1, esquerda-1);
    }
    public void eEsquerda()
    {
        if (esquerda == 0)
        {
            Play(1, "sim", escolha);
        }
        else if (esquerda == 1)
        {
            Play(3, "esquerda2", escolha);
        }
        esquerda++;
        direita++;
        saveController.Save(estoria-1, direita-1, esquerda-1);
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

