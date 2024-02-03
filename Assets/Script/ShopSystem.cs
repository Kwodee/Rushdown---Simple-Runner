using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    public GameObject iapPanel;
    public Transform iapTarget;
    public static int Money;

    public Text MoneyAmount;

    public Animator faded;

   // public GameObject selectButton;
    //public GameObject cogan;
    //public GameObject futurcaharc;
    //public GameObject ninja;
    public GameObject coganprof;
    public GameObject futurprof;
    public GameObject ninjaprof;

    // dobel jump component;
    public GameObject enableDobel;
    public GameObject disableDobel;
    public GameObject centangDobel;
    public GameObject gembokDobel;
    private int dobelInt;
    public GameObject dobelPanel;
    public GameObject buydobelbut;

    // player select geser kiri kanan;
    public Transform playerSelector;
    public Transform targetKiri;
    public Transform targetKanan;
    public Transform targKananLagi;
    public Transform targetMorekanan;
    private int selectVal;
    public Button kiribut;
    public Button kananbut;

    // highjump component
    public GameObject enhigh;
    public GameObject dishigh;
    public GameObject cenhih;
    public GameObject gembokHigh;
    public GameObject highPanel;
    public GameObject buyhighbut;

    // xtra nyawa component
    public GameObject enheart;
    public GameObject disheart;
    public GameObject centangheart;
    public GameObject gembokNyawa;
    public GameObject lifepanel;
    public GameObject buylifebut;

    // hyperpack component
    public GameObject enHyper;
    public GameObject disHyper;
    public GameObject centanghyper;
    public GameObject gembokHyper;
    public GameObject Hyperpanel;
    public GameObject buyHyperbut;

    // komponen2 buat ganti rgb trail charac
    public GameObject trailCusPan;
    public GameObject enTrailbut;
    public GameObject disTrailBut;
    public GameObject centangTrail;
    public GameObject gembokTrail;
    public GameObject buyTrailbut;
    public GameObject buyTrailPan;
    public Slider sliderR;
    public Slider sliderG;
    public Slider sliderB;
    private float SliderValR = 0.0F;
    private float SliderValG = 0.0F;
    private float SliderValB = 0.0F;
    public Text redtext;
    public Text greentext;
    public Text bluetext;
    public RawImage preview0;
    public RawImage preview1;
    public RawImage preview2;

    //komponen animasi + beli trail selected kotak
    public Transform centangselected;
    public Transform targetT0;
    public Transform targetT1;
    public Transform targetT2;
    public GameObject buyt1but;
    public GameObject buyt2but;

    // komponen beli character ( panelBeli, tombol beli )
    private int buyint = 0;
    public GameObject[] demPanels;
    public GameObject[] demBuyButs;
    public GameObject[] demBioText;
    private float LerpFloat;

    public void BuyDobel1()
    {
        dobelPanel.SetActive(true);
    }
    public void BuyDobel2()
    {
        if (Money >= 599)
        {
            dobelPanel.SetActive(false);
            enDobel();
            buydobelbut.SetActive(false);
            gembokDobel.SetActive(false);
            PlayerPrefs.SetInt("boughtdobel", 1);
            Money -= 599;
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void cancelDobel()
    {
        dobelPanel.SetActive(false);
    }
    public void enDobel()
    {
        PlayerPrefs.SetInt("dobelint", 1);
        enableDobel.SetActive(false);
        disableDobel.SetActive(true);
        centangDobel.SetActive(true);
    }
    public void disDobel()
    {
        PlayerPrefs.SetInt("dobelint", 0);
        enableDobel.SetActive(true);
        disableDobel.SetActive(false);
        centangDobel.SetActive(false);
    }
    public void buyhigh1()
    {
        highPanel.SetActive(true);    
    }
    public void buyhigh2()
    {
        if (Money >= 599)
        {
            buyhighbut.SetActive(false);
            gembokHigh.SetActive(false);
            enHigh();
            PlayerPrefs.SetInt("boughthigh", 1);
            highPanel.SetActive(false);
            Money -= 599;
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void cancelhigh()
    {
        highPanel.SetActive(false);
    }
    public void enHigh()
    {
        PlayerPrefs.SetInt("highint", 1);
        enhigh.SetActive(false);
        dishigh.SetActive(true);
        cenhih.SetActive(true);
    }
    public void disHigh()
    {
        PlayerPrefs.SetInt("highint", 0);
        enhigh.SetActive(true);
        dishigh.SetActive(false);
        cenhih.SetActive(false);
    }
    public void buylife1()
    {
        lifepanel.SetActive(true);
    }
    public void buylife2()
    {
        if (Money >= 499)
        {
            lifepanel.SetActive(false);
            Money -= 499;
            PlayerPrefs.SetInt("boughtlife", 1);
            buylifebut.SetActive(false);
            gembokNyawa.SetActive(false);
            enLive();
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void cancellife()
    {
        lifepanel.SetActive(false);
    }
    public void enLive()
    {
        PlayerPrefs.SetInt("liveplus", 1);
        enheart.SetActive(false);
        disheart.SetActive(true);
        centangheart.SetActive(true);
    }
    public void disLive()
    {
        PlayerPrefs.SetInt("liveplus", 0);
        enheart.SetActive(true);
        disheart.SetActive(false);
        centangheart.SetActive(false);
    }
    public void buyHyper1()
    {
        Hyperpanel.SetActive(true);
    }
    public void buyHyper2()
    {
        if (Money >= 1945)
        {
            Hyperpanel.SetActive(false);
            Money -= 1945;
            PlayerPrefs.SetInt("boughthyper", 1);
            buyHyperbut.SetActive(false);
            gembokHyper.SetActive(false);
            enhyper();
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void cancelhyper()
    {
        Hyperpanel.SetActive(false);
    }
    public void enhyper()
    {
        PlayerPrefs.SetInt("hyperpack", 1);
        enHyper.SetActive(false);
        disHyper.SetActive(true);
        centanghyper.SetActive(true);
    }
    public void dishyper()
    {
        PlayerPrefs.SetInt("hyperpack", 0);
        enHyper.SetActive(true);
        disHyper.SetActive(false);
        centanghyper.SetActive(false);
    }
    public void closeTrail()
    {
        trailCusPan.SetActive(false);
    }
    public void openTrail()
    {
        trailCusPan.SetActive(true);
    }
    public void buyTrail0()
    {
        buyTrailPan.SetActive(true);
    }
    public void buyTrail()
    {
        if (Money >= 999)
        {
            PlayerPrefs.SetInt("trailbought", 1);
            Money -= 999;
            buyTrailPan.SetActive(false);
            buyTrailbut.SetActive(false);
            gembokTrail.SetActive(false);
            enTrail();
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void cancelbuytrail()
    {
        buyTrailPan.SetActive(false);
    }
    public void enTrail()
    {
        PlayerPrefs.SetInt("trail", 1);
        enTrailbut.SetActive(false);
        disTrailBut.SetActive(true);
        centangTrail.SetActive(true);
    }
    public void disTrail()
    {
        PlayerPrefs.SetInt("trail", 0);
        enTrailbut.SetActive(true);
        disTrailBut.SetActive(false);
        centangTrail.SetActive(false);
    }


    // CHARACTER SELECT ALGORITHM
    // CHARACTER SELECT ALGORITHM
    public void pilihcogan()
    {
        PlayerPrefs.SetInt("Charactercode", 0);
        coganprof.SetActive(true);
        futurprof.SetActive(false);
        ninjaprof.SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(true);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void pilihfutu()
    {
        PlayerPrefs.SetInt("Charactercode", 1);
        coganprof.SetActive(false);
        futurprof.SetActive(true);
        ninjaprof.SetActive(false);
        if (PlayerPrefs.GetInt("futurbought") == 0)
        {
            demBuyButs[9].SetActive(true);
        }
        if (PlayerPrefs.GetInt("futurbought") == 1)
        {
            demBuyButs[9].SetActive(false);
        }           

        demBuyButs[0].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(true);
        demBioText[11].SetActive(false);
    }
    public void pilihninja()
    {
        PlayerPrefs.SetInt("Charactercode", 2);
        coganprof.SetActive(false);
        futurprof.SetActive(false);
        ninjaprof.SetActive(true);
        if (PlayerPrefs.GetInt("ninjabought") == 0)
        {
            demBuyButs[2].SetActive(true);
        }
        else
            demBuyButs[2].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(true);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void wilysel()
    {
        PlayerPrefs.SetInt("Charactercode", 3);
        if (PlayerPrefs.GetInt("willybought") == 0)
        {
            demBuyButs[8].SetActive(true);
        }
        else
            demBuyButs[8].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(true);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void supremesel()
    {
        PlayerPrefs.SetInt("Charactercode", 4);
        if (PlayerPrefs.GetInt("supremebought") == 0)
        {
            demBuyButs[10].SetActive(true);
        }
        else
            demBuyButs[10].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[7].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(true);
    }
    public void bigbosel()
    {
        PlayerPrefs.SetInt("Charactercode", 5);
        if (PlayerPrefs.GetInt("bigbossbought") == 0)
        {
            demBuyButs[6].SetActive(true);
        }
        else
            demBuyButs[6].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(true);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void samuraisel()
    {
        PlayerPrefs.SetInt("Charactercode", 6);
        if (PlayerPrefs.GetInt("samuraibought") == 0)
        {
            demBuyButs[4].SetActive(true);
        }
        else
            demBuyButs[4].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(true);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void winettasel()
    {
        PlayerPrefs.SetInt("Charactercode", 7);
        if (PlayerPrefs.GetInt("winettabought") == 0)
        {
            demBuyButs[7].SetActive(true);
        }
        else
            demBuyButs[7].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(true);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void mikysel()
    {
        PlayerPrefs.SetInt("Charactercode", 8);
        if(PlayerPrefs.GetInt("mikybought") == 0)
        {
            demBuyButs[0].SetActive(true);
        }
        else
            demBuyButs[0].SetActive(false);

        demBuyButs[1].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(true);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void cowboysel()
    {
        PlayerPrefs.SetInt("Charactercode", 9);
        if (PlayerPrefs.GetInt("coboybought") == 0)
        {
            demBuyButs[1].SetActive(true);
        }
        else
            demBuyButs[1].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(true);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void piratesel()
    {
        PlayerPrefs.SetInt("Charactercode", 10);
        if (PlayerPrefs.GetInt("piratebought") == 0)
        {
            demBuyButs[3].SetActive(true);
        }
        else
            demBuyButs[3].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[5].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(true);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(false);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }
    public void futuzosel()
    {
        PlayerPrefs.SetInt("Charactercode", 11);
        if (PlayerPrefs.GetInt("futuzobought") == 0)
        {
            demBuyButs[5].SetActive(true);
        }
        else
            demBuyButs[5].SetActive(false);

        demBuyButs[0].SetActive(false);
        demBuyButs[2].SetActive(false);
        demBuyButs[3].SetActive(false);
        demBuyButs[1].SetActive(false);
        demBuyButs[6].SetActive(false);
        demBuyButs[7].SetActive(false);
        demBuyButs[4].SetActive(false);
        demBuyButs[8].SetActive(false);
        demBuyButs[9].SetActive(false);
        demBuyButs[10].SetActive(false);

        demBioText[0].SetActive(false);
        demBioText[1].SetActive(false);
        demBioText[2].SetActive(false);
        demBioText[3].SetActive(false);
        demBioText[4].SetActive(false);
        demBioText[5].SetActive(false);
        demBioText[6].SetActive(true);
        demBioText[7].SetActive(false);
        demBioText[8].SetActive(false);
        demBioText[9].SetActive(false);
        demBioText[10].SetActive(false);
        demBioText[11].SetActive(false);
    }


    // BUY ALGORITHM
    // BUY ALGORITHM
    public void tambahDuit()
    {
        //PlayerPrefs.SetInt("money", Money);
        Money += 99999;
    }
    
    
    public void beliMiky()
    {
        if (buyint == 1)
        {
            if (Money < 100)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 100)
            {
                PlayerPrefs.SetInt("mikybought", 1);
                Money -= 100;
                demPanels[0].SetActive(false);
                demBuyButs[0].SetActive(false);
                buyint += 1;
            }            
        }
        if (buyint == 0)
        {
            demPanels[0].SetActive(true);
            buyint += 1;
        }  
        if(buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliCoboy()
    {
        if (buyint == 1)
        {
            if (Money < 550)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 550)
            {
                PlayerPrefs.SetInt("coboybought", 1);
                Money -= 550;
                demPanels[1].SetActive(false);
                demBuyButs[1].SetActive(false);
                buyint += 1;
            }       
        }
        if (buyint == 0)
        {
            demPanels[1].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void buyNinja()
    {
        if (buyint == 1)
        {
            if (Money < 750)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 750)
            {
                PlayerPrefs.SetInt("ninjabought", 1);
                Money -= 750;
                demPanels[2].SetActive(false);
                demBuyButs[2].SetActive(false);
                buyint += 1;
            }      
        }
        if (buyint == 0)
        {
            demPanels[2].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliPirate()
    {
        if (buyint == 1)
        {
            if (Money < 888)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 888)
            {
                PlayerPrefs.SetInt("piratebought", 1);
                Money -= 888;
                demPanels[3].SetActive(false);
                demBuyButs[3].SetActive(false);
                buyint += 1;
            }          
        }
        if (buyint == 0)
        {
            demPanels[3].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliSamurai()
    {
        if (buyint == 1)
        {
            if (Money < 1500)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 1500)
            {
                PlayerPrefs.SetInt("samuraibought", 1);
                Money -= 1500;
                demPanels[4].SetActive(false);
                demBuyButs[4].SetActive(false);
                buyint += 1;
            }            
        }
        if (buyint == 0)
        {
            demPanels[4].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliFutuzo()
    {
        if (buyint == 1)
        {
            if (Money < 2500)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 2500)
            {
                PlayerPrefs.SetInt("futuzobought", 1);
                Money -= 2500;
                demPanels[5].SetActive(false);
                demBuyButs[5].SetActive(false);
                buyint += 1;
            }            
        }
        if (buyint == 0)
        {
            demPanels[5].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliBigboss()
    {
        if (buyint == 1)
        {
            if (Money < 3750)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 3750)
            {
                PlayerPrefs.SetInt("bigbossbought", 1);
                Money -= 3750;
                demPanels[6].SetActive(false);
                demBuyButs[6].SetActive(false);
                buyint += 1;
            }           
        }
        if (buyint == 0)
        {
            demPanels[6].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliWinetta()
    {
        if (buyint == 1)
        {
            if (Money < 5500)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 5500)
            {
                PlayerPrefs.SetInt("winettabought", 1);
                Money -= 5500;
                demPanels[7].SetActive(false);
                demBuyButs[7].SetActive(false);
                buyint += 1;
            }           
        }
        if (buyint == 0)
        {
            demPanels[7].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliWilly()
    {
        if (buyint == 1)
        {
            if (Money < 5500)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 5500)
            {
                PlayerPrefs.SetInt("willybought", 1);
                Money -= 5500;
                demPanels[8].SetActive(false);
                demBuyButs[8].SetActive(false);
                buyint += 1;
            }            
        }
        if (buyint == 0)
        {
            demPanels[8].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void belifutur()
    {
        if (buyint == 1)
        {
            if (Money < 9500)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 9500)
            {
                PlayerPrefs.SetInt("futurbought", 1);
                Money -= 9500;
                demPanels[9].SetActive(false);
                demBuyButs[9].SetActive(false);
                buyint += 1;
            }         
        }
        if (buyint == 0)
        {
            demPanels[9].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }
    public void beliSupreme()
    {
        if (buyint == 1)
        {
            if (Money < 69420)
            {
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            }
            if (Money > 69420)
            {
                PlayerPrefs.SetInt("supremebought", 1);
                Money -= 69420;
                demPanels[10].SetActive(false);
                demBuyButs[10].SetActive(false);
                buyint += 1;
            }
            
        }
        if (buyint == 0)
        {
            demPanels[10].SetActive(true);
            buyint += 1;
        }
        if (buyint == 2)
        {
            disAllPanLol();
        }
    }

    public void disAllPanLol()
    {
        buyint = 0;
        for (int i = 0; i < demPanels.Length; i++)
        {
            demPanels[i].SetActive(false);
        }      
    }
    public void resetall()
    {
        PlayerPrefs.SetInt("futurbought", 0);
        PlayerPrefs.SetInt("ninjabought", 0);
        PlayerPrefs.SetInt("boughthigh", 0);
        PlayerPrefs.SetInt("boughtlife", 0);
        PlayerPrefs.SetInt("boughtdobel", 0);
        Money = 0;
        PlayerPrefs.SetInt("dobelint", 0);
        PlayerPrefs.SetInt("highint", 0);
        PlayerPrefs.SetInt("liveplus", 0);
        PlayerPrefs.SetInt("pulau2bought", 0);
        PlayerPrefs.SetInt("pulau3bought", 0);
        PlayerPrefs.SetInt("pulau4bought", 0);
        PlayerPrefs.SetInt("pulau5bought", 0);
        PlayerPrefs.SetInt("pulau6bought", 0);
        PlayerPrefs.SetInt("trailbought", 0);
        PlayerPrefs.SetInt("boughthyper", 0);
        PlayerPrefs.SetInt("trail", 0);
        PlayerPrefs.SetInt("t1bought", 0);
        PlayerPrefs.SetInt("t2bought", 0);
        PlayerPrefs.SetInt("trailke", 0);
        PlayerPrefs.SetInt("mikybought", 0);
        PlayerPrefs.SetInt("coboybought", 0);
        PlayerPrefs.SetInt("piratebought", 0);
        PlayerPrefs.SetInt("samuraibought", 0);
        PlayerPrefs.SetInt("futuzobought", 0);
        PlayerPrefs.SetInt("bigbossbought", 0);
        PlayerPrefs.SetInt("winettabought", 0);
        PlayerPrefs.SetInt("willybought", 0);
        PlayerPrefs.SetInt("supremebought", 0);
        PlayerPrefs.SetInt("HIGHSCORE", 0);
    }
    IEnumerator loadmenu()
    {
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }
    public void goTomenu()
    {
        PlayerPrefs.SetInt("money", Money);
        StartCoroutine(loadmenu());
        if (PlayerPrefs.GetInt("Charactercode") == 1)
        {
            if (PlayerPrefs.GetInt("futurbought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 2)
        {
            if (PlayerPrefs.GetInt("ninjabought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 3)
        {
            if (PlayerPrefs.GetInt("willybought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 4)
        {
            if (PlayerPrefs.GetInt("supremebought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 5)
        {
            if (PlayerPrefs.GetInt("bigbossbought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 6)
        {
            if (PlayerPrefs.GetInt("samuraibought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 7)
        {
            if (PlayerPrefs.GetInt("winettabought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 8)
        {
            if (PlayerPrefs.GetInt("mikybought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 9)
        {
            if (PlayerPrefs.GetInt("coboybought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 10)
        {
            if (PlayerPrefs.GetInt("piratebought") == 0)
            {
                pilihcogan();
            }
        }
        if (PlayerPrefs.GetInt("Charactercode") == 11)
        {
            if (PlayerPrefs.GetInt("futuzobought") == 0)
            {
                pilihcogan();
            }
        }
    }
    public void gsrKiri()
    {
        if(selectVal > 0)
        {
            selectVal -= 1;
        }
    }
    public void gsrKanan()
    {
        selectVal += 1;        
    }

    void Start()
    {
        Money = PlayerPrefs.GetInt("money");
        int charactercode = PlayerPrefs.GetInt("Charactercode");
        dobelInt = PlayerPrefs.GetInt("dobelint");
        selectVal = 1;
        int highint = PlayerPrefs.GetInt("highint");
        int nyawaint = PlayerPrefs.GetInt("liveplus");

        if (PlayerPrefs.GetInt("batSave") == 1)
        {
            LerpFloat = 0.2f;
        }
        if (PlayerPrefs.GetInt("batSave") == 0)
        {
            LerpFloat = 0.125f;
        }

        if (charactercode == 0)
        {
            pilihcogan();
        }
        if (charactercode == 1)
        {
            pilihfutu();
        }
        if (charactercode == 2)
        {
            pilihninja();
        }
        if (charactercode == 3)
        {
            wilysel();
        }
        if (charactercode == 4)
        {
            supremesel();
        }
        if (charactercode == 5)
        {
            bigbosel();
        }
        if (charactercode == 6)
        {
            samuraisel();
        }
        if (charactercode == 7)
        {
            winettasel();
        }
        if (charactercode == 8)
        {
            mikysel();
        }
        if (charactercode == 9)
        {
            cowboysel();
        }
        if (charactercode == 10)
        {
            piratesel();
        }
        if (charactercode == 11)
        {
            futuzosel();
        }

        if (PlayerPrefs.GetInt("boughtdobel") == 0)
        {
            buydobelbut.SetActive(true);
            gembokDobel.SetActive(true);
        }
        if(PlayerPrefs.GetInt("boughthigh") == 0)
        {
            buyhighbut.SetActive(true);
            gembokHigh.SetActive(true);
        }
        if(PlayerPrefs.GetInt("boughtlife") == 0)
        {
            buylifebut.SetActive(true);
            gembokNyawa.SetActive(true);
        }
        if (PlayerPrefs.GetInt("boughthyper") == 0)
        {
            buyHyperbut.SetActive(true);
            gembokHyper.SetActive(true);
        }
        if (PlayerPrefs.GetInt("trailbought") == 0)
        {
            buyTrailbut.SetActive(true);
            gembokTrail.SetActive(true);
        }
        if (dobelInt == 1)
        {
            enDobel();
        }
        if (dobelInt == 0)
        {
            disDobel();
        }
        if (highint == 1)
        {
            enHigh();
        }
        if(highint == 0)
        {
            disHigh();
        }
        if (nyawaint == 1)
        {
            enLive();
        }
        if (nyawaint == 0)
        {
            disLive();
        }
        if(PlayerPrefs.GetInt("hyperpack") == 0)
        {
            dishyper();
        }
        if(PlayerPrefs.GetInt("hyperpack") == 1)
        {
            enhyper();
        }
        if (PlayerPrefs.GetInt("trail") == 0)
        {
            disTrail();
        }
        if (PlayerPrefs.GetInt("trail") == 1)
        {
            enTrail();
        }

        if(PlayerPrefs.GetInt("trailke") == 0)
        {
            entrail0();
        }
        if (PlayerPrefs.GetInt("trailke") == 1)
        {
            entrail1();
        }
        if (PlayerPrefs.GetInt("trailke") == 2)
        {
            entrail2();
        }
        if(PlayerPrefs.GetInt("t1bought") == 1)
        {
            buyt1but.SetActive(false);
        }
        if (PlayerPrefs.GetInt("t2bought") == 1)
        {
            buyt2but.SetActive(false);
        }
        float ValR = PlayerPrefs.GetFloat("red cala")/0.003921f;
        redtext.text = ValR.ToString("F0");
        sliderR.value = PlayerPrefs.GetFloat("red cala");
        float ValG = PlayerPrefs.GetFloat("green cala") / 0.003921f;
        greentext.text = ValG.ToString("F0");
        sliderG.value = PlayerPrefs.GetFloat("green cala");
        float ValB = PlayerPrefs.GetFloat("blue cala") / 0.003921f;
        bluetext.text = ValB.ToString("F0");
        sliderB.value = PlayerPrefs.GetFloat("blue cala");
    }

    void Update()
    {
        preview0.color = new Color(PlayerPrefs.GetFloat("red cala"), PlayerPrefs.GetFloat("green cala"), PlayerPrefs.GetFloat("blue cala"), 1);
        preview1.color = new Color(PlayerPrefs.GetFloat("red cala"), PlayerPrefs.GetFloat("green cala"), PlayerPrefs.GetFloat("blue cala"), 1);
        preview2.color = new Color(PlayerPrefs.GetFloat("red cala"), PlayerPrefs.GetFloat("green cala"), PlayerPrefs.GetFloat("blue cala"), 1);
        PlayerPrefs.SetInt("money", Money);
        MoneyAmount.text = Money.ToString();
        


        if (selectVal == 1)
        {
            playerSelector.position = Vector3.Lerp(playerSelector.position, targetKiri.position, LerpFloat);
            kiribut.interactable = false;
            kananbut.interactable = true;
        }
        if (selectVal == 2)
        {
            playerSelector.position = Vector3.Lerp(playerSelector.position, targetKanan.position, LerpFloat);
            kiribut.interactable = true;
            kananbut.interactable = true;
        }
        if (selectVal == 3)
        {
            playerSelector.position = Vector3.Lerp(playerSelector.position, targKananLagi.position, LerpFloat);
            kiribut.interactable = true;
            kananbut.interactable = true;
        }
        if (selectVal == 4)
        {
            playerSelector.position = Vector3.Lerp(playerSelector.position, targetMorekanan.position, LerpFloat);
            kananbut.interactable = false;
        }


        if (PlayerPrefs.GetInt("trailke") == 0)
        {
            centangselected.position = Vector3.Lerp(centangselected.position, targetT0.position, 0.3f);
        }
        if (PlayerPrefs.GetInt("trailke") == 1)
        {
            centangselected.position = Vector3.Lerp(centangselected.position, targetT1.position, 0.3f);
        }
        if (PlayerPrefs.GetInt("trailke") == 2)
        {
            centangselected.position = Vector3.Lerp(centangselected.position, targetT2.position, 0.3f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            goTomenu();
        }
    }
    public void changeRed(float value)
    {
        SliderValR = value;
        float redvel = value / 0.003921f;
        redtext.text = redvel.ToString("F0");
        PlayerPrefs.SetFloat("red cala", value);
    }
    public void changeGreen(float value)
    {
        SliderValG = value;
        float grinvel = value / 0.003921f;
        greentext.text = grinvel.ToString("F0");
        PlayerPrefs.SetFloat("green cala", value);
    }
    public void changeBlue(float value)
    {
        SliderValB = value;
        float bluevel = value / 0.003921f;
        bluetext.text = bluevel.ToString("F0");
        PlayerPrefs.SetFloat("blue cala", value);
    }
    public void entrail0()
    {
        PlayerPrefs.SetInt("trailke", 0);
        preview0.gameObject.SetActive(true);
        preview1.gameObject.SetActive(false);
        preview2.gameObject.SetActive(false);       
    }
    public void entrail1()
    {
        PlayerPrefs.SetInt("trailke", 1);
        preview0.gameObject.SetActive(false);
        preview1.gameObject.SetActive(true);
        preview2.gameObject.SetActive(false);
    }
    public void buyT1()
    {
        if(Money >= 298)
        {
            PlayerPrefs.SetInt("t1bought", 1);
            buyt1but.SetActive(false);
            Money -= 298;
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void entrail2()
    {
        PlayerPrefs.SetInt("trailke", 2);
        preview0.gameObject.SetActive(false);
        preview1.gameObject.SetActive(false);
        preview2.gameObject.SetActive(true);
    }
    public void buyT2()
    {
        if (Money >= 298)
        {
            PlayerPrefs.SetInt("t2bought", 1);
            buyt2but.SetActive(false);
            Money -= 298;
        }
        else
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void plusCoin()
    {
        Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
}
