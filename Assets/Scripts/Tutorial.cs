using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    private AudioSource source;
    private bool final = false, liberado = false;


    private void Update()
    {
        if (!source.isPlaying)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
            if (liberado == true)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    liberado = false;
                    final = true;
                }
            }
        }
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(tutorial());
    }
    
    IEnumerator tutorial()
    {
        source.clip = audio1;
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3);

        source.clip = audio2;
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }

        liberado = true;
        yield return new WaitUntil(() => final == true);
        source.clip = audio3;
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }
        new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
        
}


