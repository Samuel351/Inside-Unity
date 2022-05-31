using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LoadingBar : MonoBehaviour
{
    [SerializeField]
    public GameObject progress;
    public GameObject Painel;
    private Slider progressbar;
    public float Speed = 0.01f;
    private float tempo = 0.2f;
    private float progressoatual = 0;

    private void Awake()
    {
        progressbar = gameObject.GetComponent<Slider>();
        StartCoroutine(Carrega());
    }

    IEnumerator Carrega()
    {
        if(progressbar.value != 2.0f) { 
            while (progressbar.value != 2.0f)
            {
                if (progressbar.value < 0.5f)
                {
                   
                    tempo = 0.1f;
                    
                }else if(progressbar.value > 0.5f && progressbar.value < 0.6f)
                {
                    Debug.Log("IF 1");
                    tempo = 0.5f;
                    
                }else if (progressbar.value > 0.6f && progressbar.value < 1.5f)
                {
                    Debug.Log("IF 2");
                    tempo = 0.1f;

                }else if (progressbar.value > 1.5f && progressbar.value < 2.0f)
                {
                    Debug.Log("IF 3");
                    tempo = 0.2f;

                }

                progressbar.value += 0.02f;
                yield return new WaitForSeconds(tempo);

            }
        }
        if(progressbar.value == 2)
        {
            progress.SetActive(false);
            Painel.SetActive(false);
            SceneManager.LoadScene(1);
        }

        
    }


    private void Update()
    {
       
    }

    //adicionando barra de progresso na barra 
    public void addprogress(float newprogress)
    {
       
        progressoatual = progressbar.value += newprogress;
       
    }

    
}
