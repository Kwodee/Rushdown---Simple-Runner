using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulauManager : MonoBehaviour
{
    public Transform pulau1;
    public Transform pulau2;
    public Transform pulau3;
    public Transform pulau4;
    public Transform pulau5;
    public Transform pulau6;

    public Transform kiriKeep;
    public Transform kirimentok;
    public Transform targetkiri;
    public Transform MainTarget;
    public Transform targetkanan;
    public Transform kananmentok;
    public Transform kananKeep;

    private float time;
    private int pulVar;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("batSave") == 1)
        {
            time = 0.175f;
        }
        if (PlayerPrefs.GetInt("batSave") == 0)
        {
            time = 0.1f;
        }
        if(PlayerPrefs.GetInt("pulauvar") == 0)
        {
            pulVar = 1;
        }
        if (pulVar == 6) // glass
        {
            pulau6.position = MainTarget.position;
            pulau5.position = targetkiri.position;
            pulau4.position = kirimentok.position;
            pulau3.position = kiriKeep.position;
            pulau2.position = kiriKeep.position;
            pulau1.position = kiriKeep.position;
        }
        if (pulVar == 5) // 2121
        {
            pulau6.position = targetkanan.position;
            pulau5.position = MainTarget.position;
            pulau4.position = targetkiri.position;
            pulau3.position = kirimentok.position;
            pulau2.position = kiriKeep.position;
            pulau1.position = kiriKeep.position;
        }
        if (pulVar == 4) // seas
        {
            pulau6.position = kananmentok.position;
            pulau5.position = targetkanan.position;
            pulau4.position = MainTarget.position;
            pulau3.position = targetkiri.position;
            pulau2.position = kirimentok.position;
            pulau1.position = kiriKeep.position;
        }
        if (pulVar == 3) // nippon
        {
            pulau6.position = kananKeep.position;
            pulau5.position = kananmentok.position;
            pulau4.position = targetkanan.position;
            pulau3.position = MainTarget.position;
            pulau2.position = targetkiri.position;
            pulau1.position = kirimentok.position;
        }
        if (pulVar == 2) // snow
        {
            pulau6.position = kananKeep.position;
            pulau5.position = kananKeep.position;
            pulau4.position = kananmentok.position;
            pulau3.position = targetkanan.position;
            pulau2.position = MainTarget.position;
            pulau1.position = targetkiri.position;
        }
        if (pulVar == 1) // nature
        {
            pulau6.position = kananKeep.position;
            pulau5.position = kananKeep.position;
            pulau4.position = kananKeep.position;
            pulau3.position = kananmentok.position;
            pulau2.position = targetkanan.position;
            pulau1.position = MainTarget.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        pulVar = PlayerPrefs.GetInt("pulauvar");
        if (pulVar == 6) // glass
        {
            pulau6.position = Vector3.Lerp(pulau6.position, MainTarget.position, time);
            pulau5.position = Vector3.Lerp(pulau5.position, targetkiri.position, time);
            pulau4.position = Vector3.Lerp(pulau4.position, kirimentok.position, time);
            pulau3.position = Vector3.Lerp(pulau3.position, kiriKeep.position, time);
            pulau2.position = Vector3.Lerp(pulau2.position, kiriKeep.position, time);
            pulau1.position = Vector3.Lerp(pulau1.position, kiriKeep.position, time);
        }
        if (pulVar == 5) // 2121
        {
            pulau6.position = Vector3.Lerp(pulau6.position, targetkanan.position, time);
            pulau5.position = Vector3.Lerp(pulau5.position, MainTarget.position, time);
            pulau4.position = Vector3.Lerp(pulau4.position, targetkiri.position, time);
            pulau3.position = Vector3.Lerp(pulau3.position, kirimentok.position, time);
            pulau2.position = Vector3.Lerp(pulau2.position, kiriKeep.position, time);
            pulau1.position = Vector3.Lerp(pulau1.position, kiriKeep.position, time);
        }
        if (pulVar == 4) // seas
        {
            pulau6.position = Vector3.Lerp(pulau6.position, kananmentok.position, time);
            pulau5.position = Vector3.Lerp(pulau5.position, targetkanan.position, time);
            pulau4.position = Vector3.Lerp(pulau4.position, MainTarget.position, time);
            pulau3.position = Vector3.Lerp(pulau3.position, targetkiri.position, time);
            pulau2.position = Vector3.Lerp(pulau2.position, kirimentok.position, time);
            pulau1.position = Vector3.Lerp(pulau1.position, kiriKeep.position, time);
        }
        if (pulVar == 3) // nippon
        {
            pulau6.position = Vector3.Lerp(pulau6.position, kananKeep.position, time);
            pulau5.position = Vector3.Lerp(pulau5.position, kananmentok.position, time);
            pulau4.position = Vector3.Lerp(pulau4.position, targetkanan.position, time);
            pulau3.position = Vector3.Lerp(pulau3.position, MainTarget.position, time);
            pulau2.position = Vector3.Lerp(pulau2.position, targetkiri.position, time);
            pulau1.position = Vector3.Lerp(pulau1.position, kirimentok.position, time);
        }
        if (pulVar == 2) // snow
        {
            pulau6.position = Vector3.Lerp(pulau6.position, kananKeep.position, time);
            pulau5.position = Vector3.Lerp(pulau5.position, kananKeep.position, time);
            pulau4.position = Vector3.Lerp(pulau4.position, kananmentok.position, time);
            pulau3.position = Vector3.Lerp(pulau3.position, targetkanan.position, time);
            pulau2.position = Vector3.Lerp(pulau2.position, MainTarget.position, time);
            pulau1.position = Vector3.Lerp(pulau1.position, targetkiri.position, time);
        }
        if(pulVar == 1) // nature
        {
            pulau6.position = Vector3.Lerp(pulau6.position, kananKeep.position, time);
            pulau5.position = Vector3.Lerp(pulau5.position, kananKeep.position, time);
            pulau4.position = Vector3.Lerp(pulau4.position, kananKeep.position, time);
            pulau3.position = Vector3.Lerp(pulau3.position, kananmentok.position, time);
            pulau2.position = Vector3.Lerp(pulau2.position, targetkanan.position, time);
            pulau1.position = Vector3.Lerp(pulau1.position, MainTarget.position, time);
        }

    }
}
