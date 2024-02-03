using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelector : MonoBehaviour
{
    private int charactercode;
    public GameObject cogan;
    public GameObject futurcaharc;
    public GameObject ninja;
    public GameObject wily;
    public GameObject supreme;
    public GameObject bigboss;
    public GameObject samurai;
    public GameObject winetta;
    public GameObject miky;
    public GameObject cowboy;
    public GameObject pirate;
    public GameObject futuzo;

    void Start()
    {
        charactercode = PlayerPrefs.GetInt("Charactercode");

        if (charactercode == 0)
        {
            cogan.SetActive(true);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 1)
        {
            if (PlayerPrefs.GetInt("futurbought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(true);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);

        }
        if (charactercode == 2)
        {
            if (PlayerPrefs.GetInt("ninjabought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(true);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 3)
        {
            if (PlayerPrefs.GetInt("willybought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(true);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 4)
        {
            if (PlayerPrefs.GetInt("supremebought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(true);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 5)
        {
            if (PlayerPrefs.GetInt("bigbossbought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(true);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 6)
        {
            if (PlayerPrefs.GetInt("samuraibought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(true);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 7)
        {
            if (PlayerPrefs.GetInt("winettabought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(true);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 8)
        {
            if (PlayerPrefs.GetInt("mikybought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(true);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 9)
        {
            if (PlayerPrefs.GetInt("coboybought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(true);
                pirate.SetActive(false);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 10)
        {
            if (PlayerPrefs.GetInt("piratebought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(true);
                futuzo.SetActive(false);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
        if (charactercode == 11)
        {
            if (PlayerPrefs.GetInt("futuzobought") == 1)
            {
                cogan.SetActive(false);
                futurcaharc.SetActive(false);
                ninja.SetActive(false);
                wily.SetActive(false);
                supreme.SetActive(false);
                bigboss.SetActive(false);
                samurai.SetActive(false);
                winetta.SetActive(false);
                miky.SetActive(false);
                cowboy.SetActive(false);
                pirate.SetActive(false);
                futuzo.SetActive(true);
            }
            else
                PlayerPrefs.SetInt("Charactercode", 0);
        }
    }

    void Update()
    {
        charactercode = PlayerPrefs.GetInt("Charactercode");

        if (charactercode == 0)
        {
            cogan.SetActive(true);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 1)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(true);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 2)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(true);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 3)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(true);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 4)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(true);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 5)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(true);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 6)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(true);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 7)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(true);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 8)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(true);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 9)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(true);
            pirate.SetActive(false);
            futuzo.SetActive(false);
        }
        if (charactercode == 10)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(true);
            futuzo.SetActive(false);
        }
        if (charactercode == 11)
        {
            cogan.SetActive(false);
            futurcaharc.SetActive(false);
            ninja.SetActive(false);
            wily.SetActive(false);
            supreme.SetActive(false);
            bigboss.SetActive(false);
            samurai.SetActive(false);
            winetta.SetActive(false);
            miky.SetActive(false);
            cowboy.SetActive(false);
            pirate.SetActive(false);
            futuzo.SetActive(true);
        }
    }
}
