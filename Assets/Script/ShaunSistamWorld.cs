using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaunSistamWorld : MonoBehaviour
{
    public static ShaunSistamWorld instance;
    public AudioSource audio;
    public AudioSource audio2;
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        HasFinishedCheck();
        stopCheck();
    }
    private void HasFinishedCheck()
    {
        if (audio.isPlaying == false)
            TukarMenukar();
    }
    private void stopCheck()
    {
        if(GameControl.gameStopped == true)
        {
            A3.SetActive(true);
            audio.volume -= 1;
            audio2.volume -= 1;
        }
        else
        {
            A3.SetActive(false);
            audio.volume += 1;
            audio2.volume += 1;
        }
    }
    private void TukarMenukar()
    {
        A1.SetActive(false);
        A2.SetActive(true);
    }

    public void kecilkanVolum()
    {
        StartCoroutine(smooth());
    }
    IEnumerator smooth()
    {
        for (int i = 0; i < 5; i++)
        {
            audio.volume -= 0.2f;
            audio2.volume -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
