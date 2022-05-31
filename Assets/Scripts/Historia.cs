using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class Historia : MonoBehaviour
{
    public AudioMixerGroup mixer;
    static SaveController saveGame;
    public Sound[] vetor1;
    private Sound som;
    public Sound[] vetor2;
    private Sound som2;

    [HideInInspector]
    public int estoria = 0;

    [HideInInspector]
    public int direita = 0;

    [HideInInspector]
    public int esquerda = 1;
    private bool verificacao = false, verificacao2 = false;

    public static Historia instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound som in vetor1)
        {
            som.source = gameObject.AddComponent<AudioSource>();
            som.source.clip = som.clip;
            som.source.volume = Sound.volume;
            som.source.outputAudioMixerGroup = mixer;
        }
        foreach (Sound som2 in vetor2)
        {
            som2.source = gameObject.AddComponent<AudioSource>();
            som2.source.clip = som2.clip;
            som2.source.volume = Sound.volume;
            som2.source.outputAudioMixerGroup = mixer;
        }
        saveGame = GetComponent<SaveController>();
        saveGame.Load();

        if (estoria == 0)
        {
            Narracao(estoria);
            Escolha(0);
            direita = 2;
            estoria++;
            verificacao2 = false;
        }
        else
        {
            Narracao(estoria);
            Escolha(0);
            verificacao2 = false;
        }
        Update();
    }

    void Update()
    {
        StartCoroutine(Escolhas());
    }

    IEnumerator Escolhas()
    {
        saveGame = GetComponent<SaveController>();
        if (!som.source.isPlaying && !som2.source.isPlaying)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Esquerda();
                yield return new WaitUntil(() => som2.source.isPlaying == false);
                verificacao = false;
                Story();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Direita();
                yield return new WaitUntil(() => som2.source.isPlaying == false);
                verificacao = false;
                Story();
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            saveGame.Delete();
        }
    }

    // Aúdios da história
    public void Story()
    {
        if (estoria == 1)
        {
            Narracao(estoria);
            estoria++;
            verificacao2 = false;
            verificacao = true;
        }
        else if (estoria == 2)
        {
            Narracao(estoria);
            verificacao2 = false;
            verificacao = true;
        }
        else if (estoria == 3)
        {
            Narracao(estoria);
            estoria++;
            verificacao2 = false;
            verificacao = true;
        }
        else if (estoria == 4)
        {
            Narracao(estoria);
            estoria++;
            verificacao2 = false;
            verificacao = true;
        }
        else if (estoria == 5)
        {
            Narracao(estoria);
            estoria++;
            verificacao2 = false;
            verificacao = true;
        }
        else if (estoria == 6)
        {
            Narracao(estoria);
            estoria++;
            verificacao2 = false;
            verificacao = true;
        }
        else if (estoria == 7)
        {
            Narracao(estoria);
            estoria++;
            verificacao2 = false;
            verificacao = true;
        }
    }

    // Escolhas da Direita
    public void Direita()
    {
        if (!som2.source.isPlaying)
        {
            Debug.LogWarning("Direita: ");
            if (direita == 2)
            {
                Escolha(direita);
                esquerda = 3;
                direita = 4;
                Debug.Log("Valor da direita: " + direita);
                verificacao = false;
            }
            else if (direita == 4)
            {
                Escolha(direita);
                esquerda = 5;
                direita = 6;
                Debug.Log("Valor da direita: " + direita);
                verificacao = false;
            }
            else if (direita == 6)
            {
                Escolha(direita);
                esquerda = 7;
                direita = 8;
                Debug.Log("Valor da direita: " + direita);
                verificacao = false;
            }
            else if (direita == 8)
            {
                Escolha(direita);
                esquerda = 9;
                direita = 10;
                Debug.Log("Valor da direita: " + direita);
                verificacao = false;
            }
            else if (direita == 10)
            {
                Escolha(direita);
                Debug.Log("Valor da direita: " + direita);
                verificacao = false;
            }
            saveGame.Save(estoria, direita, esquerda);
        }
    }

    // Escolhas da Esquerda
    public void Esquerda()
    {
        if (!som2.source.isPlaying)
        {
            Debug.LogWarning("Esquerda: ");
            if (esquerda == 1)
            {
                Escolha(esquerda);
                esquerda = 3;
                direita = 4;
                Debug.Log("Valor da esquerda: " + esquerda);
                verificacao = false;
            }
            else if (esquerda == 3)
            {
                Escolha(direita);
                esquerda = 5;
                direita = 6;
                Debug.Log("Valor da esquerda: " + esquerda);
                verificacao = false;
            }
            else if (esquerda == 5)
            {
                Escolha(direita);
                esquerda = 7;
                direita = 8;
                Debug.Log("Valor da esquerda: " + esquerda);
                verificacao = false;
            }
            else if (esquerda == 7)
            {
                Escolha(direita);
                esquerda = 9;
                direita = 10;
                Debug.Log("Valor da esquerda: " + esquerda);
                verificacao = false;
            }
            else if (esquerda == 9)
            {
                Escolha(direita);
                Debug.Log("Valor da esquerda: " + esquerda);
                verificacao = false;
            }
            saveGame.Save(estoria, direita, esquerda);
        }
    }

    // Funções que buscam os aúdios no vetores por ID
    public void Narracao(int id)
    {
        som = Array.Find(vetor1, sound => sound.ID == id);
        if (som == null)
        {
            Debug.LogWarning("O som: " + id + " não foi encontrado!");
            return;
        }
        if (!verificacao)
        {
            som.source.Play();
            verificacao = true;
        }
    }

    public void Escolha(int id)
    {
        som2 = Array.Find(vetor2, som => som.ID == id);
        if (som2 == null)
        {
            Debug.LogWarning("O som: " + id + " não foi encontrado!");
            return;
        }
        if (!verificacao2)
        {
            som2.source.Play();
            verificacao2 = true;
        }
    }
    // 
}