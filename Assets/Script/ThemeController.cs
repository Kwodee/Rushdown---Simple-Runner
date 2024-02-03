using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThemeController : MonoBehaviour
{
    public GameObject iapPanel;
    public Transform iapTarget;
    private int pulauVar;
    public static int cash;
    public Text money;
    public Text hargaText;
    public GameObject infoNat;
    public GameObject infoXma;
    public GameObject info21;
    public GameObject infoOseas;
    public GameObject infoNippon;
    public GameObject infoGlass;
    public GameObject modNat;
    public GameObject modXma;
    public GameObject mod21;
    public GameObject modOseas;
    public GameObject modNippon;
    public GameObject modGlass;

    public GameObject lockUI;
    public GameObject buyPanel2;
    public GameObject buyPanel3;
    public GameObject buyPanel4;
    public GameObject buyPanel5;
    public GameObject buyPanel6;
    public Animator themAnim;
    public Animator fadeAnim;
    public Text chillHS;
    public Text normalHS;
    public Text xtremeHS;

    public GameObject gembokMode1;
    public GameObject gembokMode2;
    public GameObject panelTantangan1;
    public GameObject panelTantangan2;

    void Start()
    {
        pulauVar = PlayerPrefs.GetInt("pulauvar");
        cash = PlayerPrefs.GetInt("money");

        if (PlayerPrefs.GetInt("pulauvar") == 0)
            pulauVar = 1;

        updateScore();
    }
    void Update()
    {
        PlayerPrefs.SetInt("pulauvar", pulauVar);
        PlayerPrefs.SetInt("money", cash);
        money.text = cash.ToString();

        if(pulauVar == 1)
        {
            lockUI.SetActive(false);
        }
        if(pulauVar == 2)
        {
            if (PlayerPrefs.GetInt("pulau2bought") == 0)
            {
                lockUI.SetActive(true);
                hargaText.text = "100";
            }
            else
                lockUI.SetActive(false);
        }
        if (pulauVar == 3)
        {
            if (PlayerPrefs.GetInt("pulau3bought") == 0)
            {
                lockUI.SetActive(true);
                hargaText.text = "2500";
            }
            else
                lockUI.SetActive(false);
        }
        if (pulauVar == 4)
        {
            if (PlayerPrefs.GetInt("pulau4bought") == 0)
            {
                lockUI.SetActive(true);
                hargaText.text = "5500";
            }
            else
                lockUI.SetActive(false);
        }
        if (pulauVar == 5)
        {
            if (PlayerPrefs.GetInt("pulau5bought") == 0)
            {
                lockUI.SetActive(true);
                hargaText.text = "8350";
            }
            else
                lockUI.SetActive(false);
        }
        if (pulauVar == 6)
        {
            if (PlayerPrefs.GetInt("pulau6bought") == 0)
            {
                lockUI.SetActive(true);
                hargaText.text = "50000";
            }
            else
                lockUI.SetActive(false);
        }
    }
    public void buy1Pulau2()
    {
        if(pulauVar == 2)
        {
            buyPanel2.SetActive(true);
        }
        if (pulauVar == 3)
        {
            buyPanel3.SetActive(true);
        }
        if (pulauVar == 4)
        {
            buyPanel4.SetActive(true);
        }
        if (pulauVar == 5)
        {
            buyPanel5.SetActive(true);
        }
        if (pulauVar == 6)
        {
            buyPanel6.SetActive(true);
        }
    }
    public void buy2Pulau2()
    {
        if(pulauVar == 2)
        {
            if(cash >= 100)
            {
                buyPanel2.SetActive(false);
                PlayerPrefs.SetInt("pulau2bought", 1);
                cash -= 100;
            }
            else
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
        }
        if(pulauVar == 3)
        {
            if(cash >= 2500)
            {
                buyPanel3.SetActive(false);
                PlayerPrefs.SetInt("pulau3bought", 1);
                cash -= 2500;
            }          
            else
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
        }
        if (pulauVar == 4)
        {
            if (cash >= 5500)
            {
                buyPanel4.SetActive(false);
                PlayerPrefs.SetInt("pulau4bought", 1);
                cash -= 5500;
            }
            else
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
        }
        if (pulauVar == 5)
        {
            if (cash >= 8350)
            {
                buyPanel5.SetActive(false);
                PlayerPrefs.SetInt("pulau5bought", 1);
                cash -= 8350;
            }
            else
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
        }
        if (pulauVar == 6)
        {
            if (cash >= 50000)
            {
                buyPanel6.SetActive(false);
                PlayerPrefs.SetInt("pulau6bought", 1);
                cash -= 50000;
            }
            else
                Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
        }
    }
    public void cancelBuy()
    {
        if (pulauVar == 2)
        {
            buyPanel2.SetActive(false);
        }
        if (pulauVar == 3)
        {
            buyPanel3.SetActive(false);
        }
        if (pulauVar == 4)
        {
            buyPanel4.SetActive(false);
        }
        if (pulauVar == 5)
        {
            buyPanel5.SetActive(false);
        }
        if (pulauVar == 6)
        {
            buyPanel6.SetActive(false);
        }
    }
    public void nextP()
    {
        if (pulauVar < 6)
        {
            pulauVar += 1;
        }

        updateScore();
    }
    public void backP()
    {
        if (pulauVar > 1)
        {
            pulauVar -= 1;
        }

        updateScore();
    }
    public void select()
    {
        //play anime
        themAnim.SetInteger("ThemInt", 1);

        lockSystem();
    }
    public void goBeck()
    {
        StartCoroutine(goBek());
    }
    IEnumerator goBek()
    {
        themAnim.SetInteger("ThemInt", 2);
        yield return new WaitForSeconds(0.5f);
        themAnim.SetInteger("ThemInt", 0);
    }
    public void firstper()
    {
        StartCoroutine(fps());
    }
    IEnumerator fps()
    {
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("1st Person");
    }
    public void plusCoin()
    {
        Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
    public void backMenu()
    {
        StartCoroutine(menu());
    }
    IEnumerator menu()
    {
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }

    // THEME GAME MODE SELECT FUNCTION
    public void natureEz()
    {
        StartCoroutine(nat1());
    }
    IEnumerator nat1()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("NChill");
    }
    public void natureNor()
    {
        StartCoroutine(nat2());
    }
    IEnumerator nat2()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("NNormal");
    }
    public void natureEx()
    {
        StartCoroutine(nat3());
    }
    IEnumerator nat3()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Nxtreme");
    }
    public void xmasn()
    {
        StartCoroutine(exmasn());
    }
    IEnumerator exmasn()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Xmasnormal");
    }
    public void xmasc()
    {
        StartCoroutine(exmasc());
    }
    IEnumerator exmasc()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Xmaschill");
    }
    public void xmasx()
    {
        StartCoroutine(exmasx());
    }
    IEnumerator exmasx()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Xmasxtreme");
    }
    public void chill21()
    {
        StartCoroutine(c21());
    }
    IEnumerator c21()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("21chill");
    }
    public void normal21()
    {
        StartCoroutine(n21());
    }
    IEnumerator n21()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("21normal");
    }
    public void xtreme21()
    {
        StartCoroutine(x21());
    }
    IEnumerator x21()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("21xtreme");
    }
    public void chillOs()
    {
        StartCoroutine(cOs());
    }
    IEnumerator cOs()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("OsChill");
    }
    public void normalOs()
    {
        StartCoroutine(nOs());
    }
    IEnumerator nOs()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("OsNormal");
    }
    public void xtremeOs()
    {
        StartCoroutine(xOs());
    }
    IEnumerator xOs()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("OsXtreme");
    }
    public void chillNi()
    {
        StartCoroutine(cNi());
    }
    IEnumerator cNi()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("NiChill");
    }
    public void normalNi()
    {
        StartCoroutine(nNi());
    }
    IEnumerator nNi()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("NiNormal");
    }
    public void xtremeNi()
    {
        StartCoroutine(xNi());
    }
    IEnumerator xNi()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("NiXtreme");
    }
    public void chillG()
    {
        StartCoroutine(cG());
    }
    IEnumerator cG()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GChill");
    }
    public void normalG()
    {
        StartCoroutine(nG());
    }
    IEnumerator nG()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GNormal");
    }
    public void xtremeG()
    {
        StartCoroutine(xG());
    }
    IEnumerator xG()
    {
        ShaunSistam.instance.kecilkanVolum();
        fadeAnim.SetTrigger("faded");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Gxtreme");
    }

    private void lockSystem()
    {
        int chillHs = 0;
        int NormalHs = 0;

        switch (pulauVar)
        {
            case 1: // nature
                chillHs = PlayerPrefs.GetInt("NchillHS");
                NormalHs = PlayerPrefs.GetInt("NnormalHS");

                infoNat.SetActive(true);
                modNat.SetActive(true);
                infoXma.SetActive(false);
                modXma.SetActive(false);
                info21.SetActive(false);
                mod21.SetActive(false);
                infoOseas.SetActive(false);
                modOseas.SetActive(false);
                infoNippon.SetActive(false);
                modNippon.SetActive(false);
                infoGlass.SetActive(false);
                modGlass.SetActive(false);
                break;
            case 2: // snow
                chillHs = PlayerPrefs.GetInt("SWchillHS");
                NormalHs = PlayerPrefs.GetInt("SWnormalHS");

                infoNat.SetActive(false);
                modNat.SetActive(false);
                infoXma.SetActive(true);
                modXma.SetActive(true);
                info21.SetActive(false);
                mod21.SetActive(false);
                infoOseas.SetActive(false);
                modOseas.SetActive(false);
                infoNippon.SetActive(false);
                modNippon.SetActive(false);
                infoGlass.SetActive(false);
                modGlass.SetActive(false);
                break;
            case 3: // nippon
                chillHs = PlayerPrefs.GetInt("NichillHS");
                NormalHs = PlayerPrefs.GetInt("NinormalHS");

                infoNat.SetActive(false);
                modNat.SetActive(false);
                infoXma.SetActive(false);
                modXma.SetActive(false);
                info21.SetActive(false);
                mod21.SetActive(false);
                infoOseas.SetActive(false);
                modOseas.SetActive(false);
                infoNippon.SetActive(true);
                modNippon.SetActive(true);
                infoGlass.SetActive(false);
                modGlass.SetActive(false);
                break;
            case 4: // seas
                chillHs = PlayerPrefs.GetInt("OschillHS");
                NormalHs = PlayerPrefs.GetInt("OsnormalHS");

                infoNat.SetActive(false);
                modNat.SetActive(false);
                infoXma.SetActive(false);
                modXma.SetActive(false);
                info21.SetActive(false);
                mod21.SetActive(false);
                infoOseas.SetActive(true);
                modOseas.SetActive(true);
                infoNippon.SetActive(false);
                modNippon.SetActive(false);
                infoGlass.SetActive(false);
                modGlass.SetActive(false);
                break;
            case 5: // 2121
                chillHs = PlayerPrefs.GetInt("21chillHS");
                NormalHs = PlayerPrefs.GetInt("21normalHS");

                infoNat.SetActive(false);
                modNat.SetActive(false);
                infoXma.SetActive(false);
                modXma.SetActive(false);
                info21.SetActive(true);
                mod21.SetActive(true);
                infoOseas.SetActive(false);
                modOseas.SetActive(false);
                infoNippon.SetActive(false);
                modNippon.SetActive(false);
                infoGlass.SetActive(false);
                modGlass.SetActive(false);
                break;
            case 6: // glass
                chillHs = PlayerPrefs.GetInt("GchillHS");
                NormalHs = PlayerPrefs.GetInt("GnormalHS");

                infoNat.SetActive(false);
                modNat.SetActive(false);
                infoXma.SetActive(false);
                modXma.SetActive(false);
                info21.SetActive(false);
                mod21.SetActive(false);
                infoOseas.SetActive(false);
                modOseas.SetActive(false);
                infoNippon.SetActive(false);
                modNippon.SetActive(false);
                infoGlass.SetActive(true);
                modGlass.SetActive(true);
                break;
        }

        Debug.Log(chillHs.ToString() + " - " + NormalHs.ToString());

        if(chillHs < 5000)
        {
            gembokMode1.SetActive(true);
        }
        else
            gembokMode1.SetActive(false);

        if (NormalHs < 10000)
        {
            gembokMode2.SetActive(true);
        }
        else
            gembokMode2.SetActive(false);
    }

    private void updateScore()
    {
        switch (pulauVar)
        {
            case 1: // nature
                chillHS.text = PlayerPrefs.GetInt("NchillHS").ToString();
                normalHS.text = PlayerPrefs.GetInt("NnormalHS").ToString();
                xtremeHS.text = PlayerPrefs.GetInt("NxtremeHS").ToString();
                break;
            case 2: // snow
                chillHS.text = PlayerPrefs.GetInt("SWchillHS").ToString();
                normalHS.text = PlayerPrefs.GetInt("SWnormalHS").ToString();
                xtremeHS.text = PlayerPrefs.GetInt("SWxtremeHS").ToString();
                break;
            case 3: // nippon
                chillHS.text = PlayerPrefs.GetInt("NichillHS").ToString();
                normalHS.text = PlayerPrefs.GetInt("NinormalHS").ToString();
                xtremeHS.text = PlayerPrefs.GetInt("NixtremeHS").ToString();
                break;
            case 4: // seas
                chillHS.text = PlayerPrefs.GetInt("OschillHS").ToString();
                normalHS.text = PlayerPrefs.GetInt("OsnormalHS").ToString();
                xtremeHS.text = PlayerPrefs.GetInt("OsxtremeHS").ToString();
                break;
            case 5: // 2121
                chillHS.text = PlayerPrefs.GetInt("21chillHS").ToString();
                normalHS.text = PlayerPrefs.GetInt("21normalHS").ToString();
                xtremeHS.text = PlayerPrefs.GetInt("21xtremeHS").ToString();
                break;
            case 6: // glass
                chillHS.text = PlayerPrefs.GetInt("GchillHS").ToString();
                normalHS.text = PlayerPrefs.GetInt("GnormalHS").ToString();
                xtremeHS.text = PlayerPrefs.GetInt("GxtremeHS").ToString();
                break;
        }
    }

    public void dilarang1()
    {
        panelTantangan1.SetActive(true);
    }
    public void dilarang2()
    {
        panelTantangan2.SetActive(true);
    }
    public void setujuh()
    {
        panelTantangan1.SetActive(false);
        panelTantangan2.SetActive(false);
    }
}
