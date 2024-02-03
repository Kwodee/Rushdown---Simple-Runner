using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    public GameObject[] test;
    public ObstacleControl oc;
    private bool restat;
    private int randomtest;


    void OnEnable()
    {
        Invoke("onStart", 0.5f);
    }
    private void onStart()
    {
        for (int i = 0; i < test.Length; i++)
        {
            test[i].SetActive(false);
        }

        randomtest = Random.Range(0, test.Length);
        test[randomtest].SetActive(true);
    }
}
