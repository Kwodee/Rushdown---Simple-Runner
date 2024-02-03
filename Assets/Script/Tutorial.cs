using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    //main component
    public Button jumpButton;
    public Button slidButton;
    public GameObject slideImg;
    public GameObject rollImg;
    public GameObject shield3D;
    public GameObject rock;
    public GameObject deLog;
    public GameObject logSleding;
    public GameObject trapp;
    public GameObject gameplayUI;
    public GameObject pauseMenu;
    //panel0 component
    public GameObject panel0;
    public GameObject next0;
    public Text countdown0;
    public GameObject countpanel0;
    //panel 1 component
    public GameObject panel1;
    public GameObject next1;
    public Text countdown1;
    public GameObject countpanel1;
    //panel 2 com
    public GameObject panel2;
    public GameObject next2;
    public Text countdown2;
    public GameObject countpanel2;
    //panel 3 com
    public GameObject panel3;
    public GameObject next3;
    public GameObject panelPuji;
    public GameObject timerPuji;
    public GameObject nextPuji;
    public Text textPuji;
    //panel4
    public GameObject panel4;
    //panel5
    public GameObject panel5;
    //panel6
    public GameObject panel6;
    //panel 7 com
    public GameObject panel7;
    public GameObject next7;
    public Text countdown7;
    public GameObject countpanel7;
    //panel 8 (final) com
    public GameObject panelfinal;
    public GameObject nextfinal;
    public Text countfinal;
    public GameObject panelCfinal;
    // etc other component
    public Transform spawnPoint;
    public Rigidbody rb;
    public Animator mike;
    public GameObject xcoin;
    public GameObject shield;
    public GameObject heart;
    public GameObject magnet;
    public GameObject coinpanel;
    public GameObject GameControl;
   // other group component
    public GameObject sensor;
    public Transform target;
    private int stepNo;
    public Animator faded;
    public Text money;
    public GameObject plusOne;
    public GameObject plusShield;
    public GameObject plusHeart;
    public Text hati;
    public GameObject plusMagnet;
    public Transform targetOne;
    //demi smoofthft
    public AudioSource audio;

    void Start()
    {
        Invoke("demiMenipu", 1.75f);
        Time.timeScale = 1.1f;
        jumpButton.gameObject.SetActive(false);
        slidButton.gameObject.SetActive(false);
        gameplayUI.SetActive(true);
        pauseMenu.SetActive(false);
        zeroStep();
        stepNo = 1;
    }
    
    void Update()
    {
        PlayerPrefs.SetInt("stopcode", 0);
    }
    // ketika obstacle kena sensor buat buka panel
    void OnTriggerEnter(Collider other)
    {
        // sensor ngedetek batu
        if (stepNo == 2)
        {
            continue2();
        }
        // sensor ngedetek log
        if (stepNo == 4)
        {
            continue3();
            
        }
        if(stepNo == 5)
        {
            Time.timeScale = 0f;
            slidButton.interactable = true;
            slidButton.gameObject.SetActive(true);
            jumpButton.gameObject.SetActive(false);
            panel5.SetActive(true);
            slideImg.SetActive(true);
            rollImg.SetActive(false);
            stepNo = 6;
        }
        if(stepNo == 7)
        {
           
            jumpButton.onClick.Invoke();
            StartCoroutine(jumptime());
        }
    }
    IEnumerator jumptime()
    {
        stepNo = 8;
        yield return new WaitForSeconds(0.5f);
        slidButton.gameObject.SetActive(true);
        slideImg.SetActive(false);
        rollImg.SetActive(true);
        Time.timeScale = 0f;
        panel6.SetActive(true);
    }

    private void zeroStep()
    {
        panel0.SetActive(true);
        countpanel0.SetActive(true);
        panel1.SetActive(false);
        next0.SetActive(false);
        StartCoroutine(countZero());
    }
    IEnumerator countZero()
    {
        yield return new WaitForSeconds(4);
        countdown0.text = "3";
        yield return new WaitForSeconds(1);
        countdown0.text = "2";
        yield return new WaitForSeconds(2);
        countdown0.text = "1";
        yield return new WaitForSeconds(1.5f);
        next0.SetActive(true);
        countpanel0.SetActive(false);
    }
    private void FirstStep()
    {
        panel1.SetActive(true);
        countpanel1.SetActive(true);
        panel2.SetActive(false);
        next1.SetActive(false);
        StartCoroutine(countDown());
    }
    IEnumerator countDown()
    {
        yield return new WaitForSeconds(1);
        countdown1.text = "3";
        yield return new WaitForSeconds(1);
        countdown1.text = "2";
        yield return new WaitForSeconds(1.5f);
        countdown1.text = "1";
        yield return new WaitForSeconds(1.5f);
        next1.SetActive(true);
        countpanel1.SetActive(false);
    }
    public void continue0()
    {
        panel0.SetActive(false);
        FirstStep();
    }

    public void continue1()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        next2.SetActive(false);
        StartCoroutine(kedapkedip());
        StartCoroutine(countDown2());
        jumpButton.interactable = false;
        slidButton.interactable = false;
        stepNo = 2;
    }
    IEnumerator countDown2()
    {
        yield return new WaitForSeconds(1);
        countdown2.text = "3";
        yield return new WaitForSeconds(1);
        countdown2.text = "2";
        yield return new WaitForSeconds(1.5f);
        countdown2.text = "1";
        yield return new WaitForSeconds(1);
        next2.SetActive(true);
        countpanel2.SetActive(false);
    }
    public void continue2()
    {       
        //munculin panel yg ngasih tau klo ad batu harus loncat
        panel3.SetActive(true);
        Time.timeScale = 0f;
        jumpButton.interactable = true;
        jumpButton.gameObject.SetActive(true);
        slidButton.gameObject.SetActive(false);
        stepNo = 3;
    }
    public void continue3()
    {
        jumpButton.gameObject.SetActive(true);
        panel4.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void pause()
    {
        gameplayUI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        gameplayUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.1f;
    }

    IEnumerator kedapkedip()
    {
        jumpButton.gameObject.SetActive(true);
        slidButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(false);
        slidButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(true);
        slidButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(false);
        slidButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(true);
        slidButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(false);
        slidButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(true);
        slidButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(false);
        slidButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        jumpButton.gameObject.SetActive(true);
        slidButton.gameObject.SetActive(true);
    }
    // tombol panel dua button di pencet
    public void DisablePanel2()
    {
        panel2.SetActive(false);
        jumpButton.gameObject.SetActive(false);
        slidButton.gameObject.SetActive(false);
        Instantiate(rock, spawnPoint.position, Quaternion.identity);
    }
    //ketika tombol next di panel "nice" dipencet
    public void DisablePanel3()
    {
        // setelh  batu muncul log
        if (stepNo == 3)
        {
            panelPuji.SetActive(false);
            Instantiate(deLog, spawnPoint.position, Quaternion.identity);
            stepNo = 4;
            
        }
        // setelah hindarin log dan tombol panel nice di klik then muncul log sleding
        if(stepNo == 5)
        {
            panelPuji.SetActive(false);
            Instantiate(logSleding, spawnPoint.position, Quaternion.identity);
 
        }
        if (stepNo == 6)
        {
            panelPuji.SetActive(false);
            Instantiate(trapp, spawnPoint.position, Quaternion.identity);
            stepNo = 7;
            sensor.transform.position = target.transform.position;
        }
        if(stepNo == 8)
        {
            panelPuji.SetActive(false);
            panel7.SetActive(true);
            coinpanel.SetActive(true);
            GameControl.SetActive(true);
            next7.SetActive(false);
            StartCoroutine(countdow7());
            StartCoroutine(spawn7());
            StartCoroutine(spawnUI());
        }
    }

    public void jumpLOL()
    {
        rb.AddForce(0, 2400, 0);
    }

    public void jumpIsClicked()
    {
        // setelah karakter lompat hindarin batu
        if(stepNo == 3)
        {
            Time.timeScale = 1.1f;
            panel3.SetActive(false);
            panelPuji.SetActive(true);
            StartCoroutine(countPuji());
            jumpButton.gameObject.SetActive(false);
        }
        // karakter hindarin log
        if (stepNo == 4)
        {
            Time.timeScale = 1.1f;
            panel4.SetActive(false);
            panelPuji.SetActive(true);
            StartCoroutine(countPuji());
            stepNo = 5;
            jumpButton.gameObject.SetActive(false);
        }
    }
    public void slidePressed()
    {
        if (stepNo == 6)
        {
            Time.timeScale = 1.1f;
            StartCoroutine(sledwait());
            panel5.SetActive(false);
        }
        if(stepNo == 8)
        {
            Time.timeScale = 1.1f;
            panel6.SetActive(false);
            slidButton.gameObject.SetActive(false);
            panelPuji.SetActive(true);
            StartCoroutine(countPuji());
        }
    }
    IEnumerator sledwait()
    {
        mike.SetBool("sleded", true);
        yield return new WaitForSeconds(0.75f);
        mike.SetBool("sleded", false);
        slidButton.gameObject.SetActive(false);
        panelPuji.SetActive(true);
        StartCoroutine(countPuji());
    }
    public void lastInstruction()
    {
        panel7.SetActive(false);
        panelfinal.SetActive(true);
        StartCoroutine(countdfinal());       
    }
    public void toMenu()
    {
        PlayerPrefs.SetInt("newbie", 1);
        StartCoroutine(btomenu());
    }
    IEnumerator countdow7()
    {
        next7.SetActive(false);
        countdown7.text = "3";
        yield return new WaitForSeconds(1);
        countdown7.text = "2";
        yield return new WaitForSeconds(1.5f);
        money.text = "1";
        Instantiate(plusOne, targetOne.position, Quaternion.identity);
        countdown7.text = "1";
        yield return new WaitForSeconds(1.5f);
        next7.SetActive(true);
        countpanel7.SetActive(false);
    }
    IEnumerator spawn7()
    {
        Instantiate(xcoin, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(shield, spawnPoint.position, Quaternion.identity);     
        yield return new WaitForSeconds(1);
        Instantiate(heart, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(magnet, spawnPoint.position, Quaternion.identity);
    }
    IEnumerator spawnUI()
    {
        yield return new WaitForSeconds(3.5f);
        Instantiate(plusShield, targetOne.position, Quaternion.identity);
        shield3D.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        hati.text = "1";
        Instantiate(plusHeart, targetOne.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(plusMagnet, targetOne.position, Quaternion.identity);
    }
    IEnumerator countPuji()
    {
        timerPuji.SetActive(true);
        nextPuji.SetActive(false);
        textPuji.text = "3";
        yield return new WaitForSeconds(1);
        textPuji.text = "2";
        yield return new WaitForSeconds(1);
        textPuji.text = "1";
        yield return new WaitForSeconds(1);
        timerPuji.SetActive(false);
        nextPuji.SetActive(true);
    }
    IEnumerator countdfinal()
    {
        nextfinal.SetActive(false);
        countfinal.text = "3";
        yield return new WaitForSeconds(1.5f);
        countfinal.text = "2";
        yield return new WaitForSeconds(2);
        countfinal.text = "1";
        yield return new WaitForSeconds(1.5f);
        panelCfinal.SetActive(false);
        nextfinal.SetActive(true);
    }
    IEnumerator btomenu()
    {
        StartCoroutine(smooth());
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator smooth()
    {
        for (int i = 0; i < 5; i++)
        {
            audio.volume -= 0.03f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void demiMenipu()
    {
        audio.volume -= 0.05f;
    }
}
