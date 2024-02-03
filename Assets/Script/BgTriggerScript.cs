using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTriggerScript : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlaya;

    void OnTriggerEnter(Collider other)
    {
        thePlaya.transform.position = teleportTarget.transform.position;
    }

}
