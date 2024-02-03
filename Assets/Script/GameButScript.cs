using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButScript : MonoBehaviour
{
    public GameObject kiribatan;
    public GameObject kananbatan;
    public GameObject jumpbutbe4;
    public GameObject slidebutbe4;
    public GameObject jumpbutAfter;
    public GameObject slidebutAfter;
    public GameObject jumpAfimg;
    public GameObject slideAfimg;
    public GameObject slidebe4;
    public GameObject rollbe4;
    public GameObject slideaft;
    public GameObject rollaft;

    private int varbar;
    private int swapvar;
    private int airvar;

    void Start()
    {
        varbar = PlayerPrefs.GetInt("hidvar");
        swapvar = PlayerPrefs.GetInt("swapvar");
        if (varbar == 0)
        {
            kiribatan.SetActive(true);
            kananbatan.SetActive(true);
            jumpAfimg.SetActive(true);
            slideAfimg.SetActive(true);
        }
        if (varbar == 1)
        {
            kiribatan.SetActive(false);
            kananbatan.SetActive(false);
            jumpAfimg.SetActive(false);
            slideAfimg.SetActive(false);
        }
        if (swapvar == 0)
        {
            jumpbutbe4.SetActive(true);
            slidebutbe4.SetActive(true);
            jumpbutAfter.SetActive(false);
            slidebutAfter.SetActive(false);
        }
        if (swapvar == 1)
        {
            jumpbutbe4.SetActive(false);
            slidebutbe4.SetActive(false);
            jumpbutAfter.SetActive(true);
            slidebutAfter.SetActive(true);
        }
    }
    void Update()
    {
        airvar = DinoControl.airTime;

        if (airvar == 0)
        {
            slidebe4.SetActive(true);
            slideaft.SetActive(true);
            rollbe4.SetActive(false);
            rollaft.SetActive(false);
        }
        if (airvar == 1)
        {
            slidebe4.SetActive(false);
            slideaft.SetActive(false);
            rollbe4.SetActive(true);
            rollaft.SetActive(true);
        }
    }
}
