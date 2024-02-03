using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldTimer : MonoBehaviour
{
    public Text timer;
    private int timemin = 31;
    private int timemag = 16;
    private float rate;
    public Animator shieldAnime;
    private int stopcode;
    public bool shield;
    public bool magnet;

    void Start()
    {
        if(shield == true)
        {
            if (GameControl.shieldIsRunnin == true)
            {
                DESTROYY();
            }
            if (GameControl.shieldpicked == 2)
            {
                DESTROYY();
            }
            GameControl.shieldpicked = 2;
        }
        
    }

    void Update()
    {
        if(shield == true)
        {
            GameControl.shieldIsRunnin = true;
            if (Time.time > rate && timemin != 0)
            {
                timemin -= 1;
                rate = Time.time + 1.1f;
                timer.text = timemin.ToString();
            }
            if (timemin == 0)
            {
                shieldAnime.SetBool("timerisdone", true);
                GameControl.shieldpicked = 0;
            }
            if (stopcode == 1)
            {
                shieldAnime.SetBool("timerisdone", true);
            }
            if (GameControl.shieldpicked == 0)
            {
                shieldAnime.SetBool("timerisdone", true);
            }
        }
        if(magnet == true)
        {
            if (Time.time > rate && timemag != 0)
            {
                timemag -= 1;
                rate = Time.time + 1.1f;
                timer.text = timemag.ToString();
            }
            if (timemag == 0)
            {
                shieldAnime.SetBool("timerisdone", true);
                GameControl.magnetYes = false;
            }
            if (stopcode == 1)
            {
                shieldAnime.SetBool("timerisdone", true);
                GameControl.magnetYes = false;
            }
        }
        
        stopcode = GameControl.stopcode;
    }
    public void DESTROYY()
    {
        Destroy(gameObject);
    }
    public void STOPPP()
    {
        //GameControl.shieldpicked = 2;
    }
}
