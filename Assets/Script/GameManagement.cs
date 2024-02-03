using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManagement : MonoBehaviour
{
    public GameObject iapPanel;
    public Transform iapTarget;
    public GameObject pulau1;
    public GameObject pulau2;
    public GameObject pulau3;
    public GameObject pulau4;
    public GameObject pulau5;
    public GameObject pulau6;
    public GameObject MainMenu;
    public GameObject GamePlay;
    public GameObject GameInfo;
    public GameObject FailUi;
    public GameObject PauseUI;
    public GameObject exitUI;
    public GameObject SettingUi;
    public AudioMixer audioMixer;
    public AudioMixer audioMusic;
    private bool isMutedSFX;
    private bool isMutedMusik;
    //public Animator animator;
    public Text maimonei;
    public Text haiksekor;
    //public Text Qlepel;
    int mYmonei;
    int myhaik;
    private int Qualitylepel;
    private bool hidden;
    private bool nothidden;
    private int hidvar;
    private int swapvar;
    private int pulauVar;
    //setting stuffs
    public GameObject centangkentang;
    public GameObject centangRTX;
    public GameObject centangUltra;
    public GameObject showbutton;
    public GameObject hidebutton;
    public GameObject centanghide;
    public GameObject swapbut;
    public GameObject noswapbut;
    public GameObject centangswap;
    public GameObject centangVol;
    public GameObject centangMusik;
    public GameObject enbatBut;
    public GameObject disbatBut;
    public GameObject centangBat;

    public Animator faded;
    public Animator settingopenAnim;
    public Animator infoAnime;
    public GameObject blackscreen;

    Resolution[] resolutions;

    // swipe atas open shop stuffs
    public Transform content;
    public Transform conTarget;
    public GameObject sonSistam;

    void Start()
    {
        spawnMusik();

        int newbieValue = PlayerPrefs.GetInt("newbie");
        if (newbieValue == 0)
        {
            Application.targetFrameRate = 60;
            SceneManager.LoadScene("Tutorial");
        }
        if (PlayerPrefs.GetInt("batSave") == 0)
        {
            disBat();
        }
        else
            enBat();

        //menjilat pemain, agar dikira tidak maruk iklan ^_^
        if (PlayerPrefs.GetInt("orangbarunih") == 0)
        {
            kita_Baek_Baekin_Dulu();
        }

        int adsVar = PlayerPrefs.GetInt("adsvar");
        if (adsVar < 6)
        {
            adsVar += 1;
            PlayerPrefs.SetInt("adsvar", adsVar);
        }
        if (adsVar == 6)
        {
            Invoke("showIads", 0.3f);
            adsVar = 0;
            PlayerPrefs.SetInt("adsvar", adsVar);
        }

        hidvar = PlayerPrefs.GetInt("hidvar");
        swapvar = PlayerPrefs.GetInt("swapvar");
        pulauVar = PlayerPrefs.GetInt("pulauvar");

        audioCheckSFX();
        audioCheckMusik();

        //isMutedSFX = PlayerPrefs.GetInt("vol") == 1;
        //AudioListener.pause = isMutedSFX;
        //centangVol.SetActive(!isMutedSFX);
        Qualitylepel = QualitySettings.GetQualityLevel();

        if (hidvar == 0)
        {
            showbutton.SetActive(false);
            hidebutton.SetActive(true);
            centanghide.SetActive(false);
        }
        if (hidvar == 1)
        {
            showbutton.SetActive(true);
            hidebutton.SetActive(false);
            centanghide.SetActive(true);
        }
        if (swapvar == 0)
        {
            swapbut.SetActive(true);
            noswapbut.SetActive(false);
            centangswap.SetActive(false);
        }
        if (swapvar == 1)
        {
            swapbut.SetActive(false);
            noswapbut.SetActive(true);
            centangswap.SetActive(true);
        }
        if (Qualitylepel == 0)
        {
            centangkentang.SetActive(true);
            centangRTX.SetActive(false);
            centangUltra.SetActive(false);
        }
        if (Qualitylepel == 1)
        {
            centangkentang.SetActive(false);
            centangRTX.SetActive(true);
            centangUltra.SetActive(false);
        }
        if (Qualitylepel == 2)
        {
            centangkentang.SetActive(false);
            centangRTX.SetActive(false);
            centangUltra.SetActive(true);
        }
        if (pulauVar == 0)
        {
            pulau1.SetActive(true);
        }
        if (pulauVar == 1)
        {
            pulau1.SetActive(true);
        }
        if (pulauVar == 2)
        {
            pulau2.SetActive(true);
        }
        if (pulauVar == 3)
        {
            pulau3.SetActive(true);
        }
        if (pulauVar == 4)
        {
            pulau4.SetActive(true);
        }
        if (pulauVar == 5)
        {
            pulau5.SetActive(true);
        }
        if (pulauVar == 6)
        {
            pulau6.SetActive(true);
        }

        myhaik = PlayerPrefs.GetInt("HIGHSCORE");
        haiksekor.text = "HIGHEST SCORE : " + myhaik.ToString();

        //if(Camera.main.aspect >= 1.7 & Camera.main.aspect <= 1.8)
        //{
        //Debug.Log("16:9");
        //Screen.SetResolution(1280, 720, true);
        //}
        //if (Camera.main.aspect >= 2.0 & Camera.main.aspect <= 2.2)
        //{
        //Debug.Log("117:54");
        //Screen.SetResolution(1690, 810, true);
        //}                 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitshow();
        }
        if (content.transform.position.y > conTarget.transform.position.y)
        {
            StartCoroutine(loadshop());
        }

        mYmonei = PlayerPrefs.GetInt("money");
        maimonei.text = mYmonei.ToString();
    }




    // voids
    private void audioCheckSFX()
    {
        if (PlayerPrefs.GetInt("vol") == 0)
        {
            isMutedSFX = true;
            audioMixer.SetFloat("Volume", 20);
            centangVol.SetActive(true);
        }
        else
        {
            isMutedSFX = false;
            audioMixer.SetFloat("Volume", -80);
            centangVol.SetActive(false);
        }
    }
    private void audioCheckMusik()
    {
        if (PlayerPrefs.GetInt("volM") == 0)
        {
            isMutedMusik = true;
            audioMusic.SetFloat("Volume", 0);
            centangMusik.SetActive(true);
        }
        else
        {
            isMutedMusik = false;
            audioMusic.SetFloat("Volume", -80);
            centangMusik.SetActive(false);
        }
    }
    private void spawnMusik()
    {
        if (GameObject.Find("Shaun System(Clone)") == null)
        {
            Instantiate(sonSistam, transform.position, transform.rotation);
        }
    }
    private void showIads()
    {
        if (PlayerPrefs.GetInt("adsremoved") == 0)
        {
            AdsManager.IadsShow = true;
        }
    }
    public void ishidden()
    {
        hidden = true;
        nothidden = false;
        PlayerPrefs.SetInt("hidvar", 1);
        centanghide.SetActive(true);
        showbutton.SetActive(true);
        hidebutton.SetActive(false);
    }
    public void mehhidden()
    {
        hidden = false;
        nothidden = true;
        PlayerPrefs.SetInt("hidvar", 0);
        centanghide.SetActive(false);
        showbutton.SetActive(false);
        hidebutton.SetActive(true);
    }
    public void swapButt()
    {
        PlayerPrefs.SetInt("swapvar", 1);
        centangswap.SetActive(true);
        swapbut.SetActive(false);
        noswapbut.SetActive(true);
    }
    public void noswapButt()
    {
        PlayerPrefs.SetInt("swapvar", 0);
        centangswap.SetActive(false);
        swapbut.SetActive(true);
        noswapbut.SetActive(false);
    }
    public void Menulol()
    {
        MainMenu.SetActive(true);
        GamePlay.SetActive(false);
    }
    public void Pausedlel()
    {
        PauseUI.SetActive(true);
        GamePlay.SetActive(false);
    }
    IEnumerator loadplay()
    {
        ShaunSistamWorld.instance.kecilkanVolum();
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        FailUi.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator loadSPEED()
    {
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        FailUi.SetActive(false);
        SceneManager.LoadScene("Maximum speed");
    }
    IEnumerator load1stPerson()
    {
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("1st person");
    }
    IEnumerator loadTheme()
    {
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        FailUi.SetActive(false);
        SceneManager.LoadScene("Theme Selector");
    }
    IEnumerator exit()
    {
        ShaunSistam.instance.kecilkanVolum();
        faded.SetTrigger("exit");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
    IEnumerator retry()
    {
        ShaunSistamWorld.instance.kecilkanVolum();
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }
    public void menu()
    {
        StartCoroutine(retry());
        Time.timeScale = 1f;
    }
    public void gotheme()
    {
        StartCoroutine(loadTheme());
    }
    public void GemInfo()
    {
        StartCoroutine(gemI());
    }
    IEnumerator gemI()
    {
        GameInfo.SetActive(true);
        infoAnime.SetBool("setIsClicked", true);
        yield return new WaitForSeconds(0.2f);
        blackscreen.SetActive(true);
    }
    public void InfoMeh()
    {
        StartCoroutine(noI());
    }
    IEnumerator noI()
    {
        infoAnime.SetBool("backIsClicked", true);
        infoAnime.SetBool("setIsClicked", false);
        yield return new WaitForSeconds(0.6f);
        infoAnime.SetBool("backIsClicked", false);
        blackscreen.SetActive(false);
        GameInfo.SetActive(false);
    }
    public void Restrt()
    {
        StartCoroutine(loadplay());
        Time.timeScale = 1f;
        //FailUi.SetActive(false);
    }
    public void rstrsped()
    {
        StartCoroutine(loadSPEED());
        Time.timeScale = 1f;
    }
    public void firstperson()
    {
        StartCoroutine(load1stPerson());
    }
    public void Playlol()
    {

        //MainMenu.SetActive(false);
        StartCoroutine(loadplay());
    }
    public void PlayNatal()
    {
        SceneManager.LoadScene("GamePlay Natal");
    }
    public void gemToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void exitshow()
    {
        blackscreen.SetActive(true);
        exitUI.SetActive(true);
        //MainMenu.SetActive(false);
    }
    public void noexit()
    {
        blackscreen.SetActive(false);
        exitUI.SetActive(false);
        //MainMenu.SetActive(true);
    }
    public void QuitGem()
    {
        StartCoroutine(exit());
    }
    IEnumerator loadshop()
    {
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Char Selection");
    }
    public void PilihCharac()
    {
        StartCoroutine(loadshop());
    }
    IEnumerator loadTuto()
    {
        faded.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Tutorial");
    }
    public void tutorial()
    {
        StartCoroutine(loadTuto());
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void LowSetting()
    {
        QualitySettings.SetQualityLevel(0);
        centangkentang.SetActive(true);
        centangRTX.SetActive(false);
        centangUltra.SetActive(false);
    }
    public void HighSetting()
    {
        QualitySettings.SetQualityLevel(1);
        centangkentang.SetActive(false);
        centangRTX.SetActive(true);
        centangUltra.SetActive(false);
    }
    public void UltraSet()
    {
        //QualitySettings.SetQualityLevel(2);
        centangkentang.SetActive(false);
        centangRTX.SetActive(false);
        centangUltra.SetActive(true);
        Screen.SetResolution(1600, 720, true);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void settinggblk()
    {
        StartCoroutine(naek());
    }
    IEnumerator naek()
    {
        SettingUi.SetActive(true);
        settingopenAnim.SetBool("setIsClicked", true);
        settingopenAnim.SetBool("backIsClicked", false);
        yield return new WaitForSeconds(0.2f);
        blackscreen.SetActive(true);
    }
    public void ReturntoHome()
    {
        StartCoroutine(countdown());
    }
    IEnumerator countdown()
    {
        settingopenAnim.SetBool("setIsClicked", false);
        settingopenAnim.SetBool("backIsClicked", true);
        yield return new WaitForSeconds(0.6f);
        settingopenAnim.SetBool("backIsClicked", false);
        blackscreen.SetActive(false);
        SettingUi.SetActive(false);
    }
    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("Volume", Volume);
    }
    public void volIsClicked()
    {
        isMutedSFX = !isMutedSFX;
        AudioListener.pause = isMutedSFX;
        PlayerPrefs.SetInt("vol", isMutedSFX ? 0 : 1);
        centangVol.SetActive(!isMutedSFX);
    }
    public void VolumeSFX()
    {
        isMutedSFX = !isMutedSFX;
        centangVol.SetActive(isMutedSFX);
        if (isMutedSFX == true)
        {
            audioMixer.SetFloat("Volume", 20);
            PlayerPrefs.SetInt("vol", 0);
        }
        else
        {
            audioMixer.SetFloat("Volume", -80);
            PlayerPrefs.SetInt("vol", 1);
        }

    }
    public void VolumeMusic()
    { 
        isMutedMusik = !isMutedMusik;
        PlayerPrefs.SetInt("volM", isMutedMusik ? 1 : 0);
        centangMusik.SetActive(isMutedMusik);
        if (isMutedMusik == true)
        {
            audioMusic.SetFloat("Volume", 0);
            PlayerPrefs.SetInt("volM", 0);
        }
        else
        {
            audioMusic.SetFloat("Volume", -80);
            PlayerPrefs.SetInt("volM", 1);
        }
    }
    public void enBat()
    {
        Application.targetFrameRate = 30;
        enbatBut.SetActive(false);
        disbatBut.SetActive(true);
        centangBat.SetActive(true);
        PlayerPrefs.SetInt("batSave", 1);
    }
    public void disBat()
    {
        Application.targetFrameRate = 60;
        enbatBut.SetActive(true);
        disbatBut.SetActive(false);
        centangBat.SetActive(false);
        PlayerPrefs.SetInt("batSave", 0);
    }
    public void button1()
    {
        Screen.SetResolution(2290, 1080, true);
    }
    public void button2()
    {
        Screen.SetResolution(1700, 810, true);
    }
    public void button3()
    {
        Screen.SetResolution(1715, 810, true);
    }
    public void button4()
    {
        Screen.SetResolution(1690, 810, true);
    }
    public void plusCoin()
    {
        Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    private void kita_Baek_Baekin_Dulu()
    {
        if(PlayerPrefs.GetInt("money") < 200)
        {
            PlayerPrefs.SetInt("adsremoved", 1);
        }
        else
        {
            PlayerPrefs.SetInt("adsremoved", 0);
            PlayerPrefs.SetInt("orangbarunih", 1);
        }
    }
}
