using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public AudioSource audiosource;
    public Animator koin;
    public int value;
    private int valueSave;
    public int nyawa;
    private int nyawaSave;
    public bool shield;
    public bool magnet;

    public float moveSpeed = -5f;
    private float stopCode;
    private bool holdon = false;

    //object pooling stuff
    private bool isRestart = true;
    private Vector3 oriPos;

    //  NOTE    NOTE    NOTE
    //  BANYAK FITUR YANG TERPAKSA GW POTONG DEMI OBJECT POOLING, KEK MISAL VECTOR3.LERP ITU GW CUT, SEKEDAR INFO KALO BINGUNG WTF KOK WILMER DULU GBLK BANYAK BET DI IJO IJO YA KARENA ITU ALASANNYA.

    void Awake()
    {
        oriPos = transform.localPosition;
        nyawaSave = nyawa;
        valueSave = value;
    }
    void Update()
    {
        if (isRestart)
            onStart();

        if (value > 0 && GameControl.magnetYes == true && transform.position.x < -20)
        {
            transform.position = Vector3.Lerp(transform.position, GameObject.FindWithTag("Finish").transform.position, 0.1f);
            if (transform.position.x < -25)
            {
                transform.position = Vector3.Lerp(transform.position, GameObject.FindWithTag("Finish").transform.position, 0.25f);
            }
        }
        if (shield == true)
        {
            checkifDobel();
        }
        if (magnet == true && GameControl.magnetYes == true)
        {
            Invoke("destroyy", 1); // 0.75f
        }
        if (transform.position.x < -32.8f)
        {
            destroyy();
        }
        if (stopCode == 0)
        {
            mundur();
        }
        if (GameControl.nyawaValue == 2 && nyawa == 1)
        {
            Invoke("destroyy", 1); // 0.75f
        }
        stopCode = GameControl.stopcode;
        if (holdon == true)
        {
            //transform.position = Vector3.Lerp(transform.position, GameObject.FindWithTag("Finish").transform.position, 0.075f);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {                                  
            if(value > 0)
            {
                GameControl.jumlahduit += value;
                GameControl.jumlahNambahnya = value;
                GameControl.pickincoin = true;
                value = 0;
                StartCoroutine(stay());
            }
            if(nyawa > 0)
            {
                GameControl.pickinHeart = true;
                GameControl.nyawaValue += nyawa;
            }
            if(shield == true)
            {
                GameControl.shieldpicked = 1;
                value = 0;
                nyawa = 0;
            }
            if (magnet == true)
            {
                GameControl.magnetYes = true;
                GameControl.magnetInt = 1;
                value = 0;
                nyawa = 0;
            }
            audiosource.Play();
            StartCoroutine(cekling());
        }
    }
    IEnumerator cekling()
    {
        koin.SetBool("collected", true);
        yield return new WaitForSeconds(0.75f);
        GameControl.pickincoin = false;
    }
    private void onStart()
    {
        isRestart = false;
        value = valueSave;
        nyawa = nyawaSave;
        koin.SetBool("collected", false);
    }
    private void mundur()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -32.8f)
            destroyy();
    }

    private void checkifDobel()
    {
        if (GameControl.shieldpicked == 2)
        {
            Invoke("destroyy", 1); // 0.75f
        }
        if(GameControl.shieldIsRunnin == true)
        {
            Invoke("destroyy", 1); // 0.75f
        }
    }
    private void destroyy()
    {
        gameObject.SetActive(false);
        isRestart = true;
    }
    IEnumerator stay()
    {
        holdon = true;
        yield return new WaitForSeconds(1);
        holdon = false;
    }
}
