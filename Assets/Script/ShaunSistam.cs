using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShaunSistam : MonoBehaviour
{
    public static ShaunSistam instance;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        besarkanVolum();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SceneCheck();
    }
    private void SceneCheck()
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Menu") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Char Selection") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Theme Selector"))
        {
            Destroy(gameObject);
        }
    }
    public void kecilkanVolum()
    {
        StartCoroutine(smooth());
    }
    IEnumerator smooth()
    {
        for(int i = 0; i < 5; i++)
        {
            audio.volume -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void besarkanVolum()
    {
        StartCoroutine(smoothie());
    }
    IEnumerator smoothie()
    {
        for (int i = 0; i < 5; i++)
        {
            audio.volume += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
