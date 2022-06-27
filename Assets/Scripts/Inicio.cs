using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(tutorial());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator tutorial()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(3);
    }
}
