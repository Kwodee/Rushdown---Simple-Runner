using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gegaraKomenUtub : MonoBehaviour
{
    public Transform[] posisiKoin;
    private Vector3[] simpenPermanen;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < posisiKoin.Length; i++)
        {
            simpenPermanen[i] = posisiKoin[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
