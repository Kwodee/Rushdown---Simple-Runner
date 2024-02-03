using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using UnityEngine.Advertisements;


using UnityEngine.SceneManagement;





public class AdsManager : MonoBehaviour //IUnityAdsListener
{
    private string gameId = "4205371";
    private bool testMode = false;
    public static bool IadsShow;
    public static bool RadsShow;
    private string sceneName;
    public GameObject adsNotRedy;
    public GameObject coinAdded;
    private bool adsShownEdi;
    //private Transform transforM;
    private GameObject panelCoinAds;
    private GameObject panelAdsNope;

    void Start() {

        // INI ASLINYA KAGA DI COMMENT YAK
        //Advertisement.AddListener(this);
        //Advertisement.Initialize(gameId, testMode);

        IadsShow = false;
        RadsShow = false;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        adsShownEdi = false;
        //transforM = gameObject.transform;//GameObject.FindWithTag("Player").transform;

        // SET THE GAMEOBJECT, THEN DISABLE IT
        panelAdsNope = GameObject.FindWithTag("adsNope");
        panelAdsNope.SetActive(false);
        panelCoinAds = GameObject.FindWithTag("adsCoinDone");
        panelCoinAds.SetActive(false);
    }
    //void Update()
    //{
    //    if(IadsShow == true)
    //    {
    //        ShowInterstitialAd();
    //        IadsShow = false;
    //    }
    //    if (RadsShow == true)
    //    {
    //        ShowRewardedAd();
    //        RadsShow = false;
    //    }
    //}

    //public void ShowInterstitialAd()
    //{
    //    if (Advertisement.IsReady("Interstitial_Android"))
    //    {
    //        Advertisement.Show("Interstitial_Android");            
    //    }
    //}

    //public void ShowRewardedAd()
    //{
    //    if (Advertisement.IsReady("Rewarded_Android"))
    //    {
    //        Advertisement.Show("Rewarded_Android");
    //        adsShownEdi = true;
    //    }
    //    else
    //        panelAdsNope.SetActive(true);//Instantiate(adsNotRedy, transforM.position, Quaternion.identity);
    //}
    //public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    //{
    //    if (surfacingId == "Rewarded_Android")
    //    {
    //        // Define conditional logic for each ad completion status:
    //        if (showResult == ShowResult.Finished)
    //        {               
    //            if (sceneName == "Menu" && adsShownEdi == true)
    //            {
    //                int money = PlayerPrefs.GetInt("money");
    //                money += 500;
    //                PlayerPrefs.SetInt("money", money);
    //                adsShownEdi = false;
    //                panelCoinAds.SetActive(true);
    //                //Instantiate(coinAdded, transforM.position, Quaternion.identity);//Debug.Log("moneyy ++500"); 
    //            }
    //            else
    //                GameControl.adsFinished = true;
    //        }
    //        else if (showResult == ShowResult.Skipped)
    //        {
    //            // Do not reward the user for skipping the ad.
    //        }
    //        else if (showResult == ShowResult.Failed)
    //        {
    //            Debug.LogWarning("The ad did not finish due to an error.");
    //        }
    //    }
    //}
    //public void OnUnityAdsReady(string surfacingId)
    //{
    //    if (surfacingId == "Interstitial_Android")
    //    {
    //        //Debug.Log("popup ads ready sir");
    //    }
    //    if(surfacingId == "Rewarded_Android")
    //    {
    //        //Debug.Log("reward ads ready sir");
    //    }
    //}
    //public void OnUnityAdsDidError(string message)
    //{
    //    // Log the error.
    //}
    //public void OnUnityAdsDidStart(string surfacingId)
    //{
    //    // Optional actions to take when the end-users triggers an ad.
    //}
}