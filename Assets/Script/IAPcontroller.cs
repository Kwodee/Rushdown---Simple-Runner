using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPcontroller : MonoBehaviour
{
    public Animator canvasAnim;
    public static int money;
    public GameObject successPanel;
    public Text successText;
    public GameObject failedPanel;
    public Text failedText;

    void Start()
    {
        canvasAnim.SetBool("setIsClicked", true);
        money = PlayerPrefs.GetInt("money");
        if (GameObject.Find("GameControl") != null)
        {
            GameControl.holupp = true;
        }       
    }
    void Update()
    {
        if (GameObject.Find("Shop System") == null)
        {
            PlayerPrefs.SetInt("money", money);
        }
        if (GameObject.Find("ThemeController") == null)
        {
            PlayerPrefs.SetInt("money", money);
        }
    }
    public void bek()
    {
        StartCoroutine(bec());
    }
    IEnumerator bec()
    {
        canvasAnim.SetBool("backIsClicked", true);
        yield return new WaitForSeconds(0.65f);
        GameControl.holupp = false;
        Destroy(gameObject);
    }

    public void buy1()
    {        
        if(GameObject.Find("Shop System") != null) // buat scene charac selec dimaan ada shopsys
        {
            ShopSystem.Money += 2000;
        }
        if (GameObject.Find("ThemeController") != null) // buat scene pilih level dimana ada themecontr
        {
            ThemeController.cash += 2000;
        }        
        if (GameObject.Find("GameControl") != null) // buat gameplay dimana ada gamecontrol
        {
            money += 2000;
        }
        if(GameObject.Find("ThemeController") == null && GameObject.Find("Shop System") == null) // buat scene menu
        {
            if(GameObject.Find("GameControl") == null) // biar gak ngaruh ke scene gameplay jadi nambah dua kali malahan
                money += 2000;
        }
    }
    public void buy2()
    {
        if (GameObject.Find("Shop System") != null) // buat scene charac selec dimaan ada shopsys
        {
            ShopSystem.Money += 10000;
        }
        if (GameObject.Find("ThemeController") != null) // buat scene pilih level dimana ada themecontr
        {
            ThemeController.cash += 10000;
        }
        if (GameObject.Find("GameControl") != null) // buat gameplay dimana ada gamecontrol
        {
            money += 10000;
        }
        if (GameObject.Find("ThemeController") == null && GameObject.Find("Shop System") == null) // buat scene menu
        {
            if (GameObject.Find("GameControl") == null) // biar gak ngaruh ke scene gameplay jadi nambah dua kali malahan
                money += 10000;
        }
    }
    public void buy3()
    {
        if (GameObject.Find("Shop System") != null) // buat scene charac selec dimaan ada shopsys
        {
            ShopSystem.Money += 50000;
        }
        if (GameObject.Find("ThemeController") != null) // buat scene pilih level dimana ada themecontr
        {
            ThemeController.cash += 50000;
        }
        if (GameObject.Find("GameControl") != null) // buat gameplay dimana ada gamecontrol
        {
            money += 50000;
        }
        if (GameObject.Find("ThemeController") == null && GameObject.Find("Shop System") == null) // buat scene menu
        {
            if (GameObject.Find("GameControl") == null) // biar gak ngaruh ke scene gameplay jadi nambah dua kali malahan
                money += 50000;
        }
    }
    public void buy4()
    {
        if (GameObject.Find("Shop System") != null) // buat scene charac selec dimaan ada shopsys
        {
            ShopSystem.Money += 80000;
        }
        if (GameObject.Find("ThemeController") != null) // buat scene pilih level dimana ada themecontr
        {
            ThemeController.cash += 80000;
        }
        if (GameObject.Find("GameControl") != null) // buat gameplay dimana ada gamecontrol
        {
            money += 80000;
        }
        if (GameObject.Find("ThemeController") == null && GameObject.Find("Shop System") == null) // buat scene menu
        {
            if (GameObject.Find("GameControl") == null) // biar gak ngaruh ke scene gameplay jadi nambah dua kali malahan
                money += 80000;
        }
    }
    public void buy5()
    {
        if (GameObject.Find("Shop System") != null) // buat scene charac selec dimaan ada shopsys
        {
            ShopSystem.Money += 200000;
        }
        if (GameObject.Find("ThemeController") != null) // buat scene pilih level dimana ada themecontr
        {
            ThemeController.cash += 200000;
        }
        if (GameObject.Find("GameControl") != null) // buat gameplay dimana ada gamecontrol
        {
            money += 200000;
        }
        if (GameObject.Find("ThemeController") == null && GameObject.Find("Shop System") == null) // buat scene menu
        {
            if (GameObject.Find("GameControl") == null) // biar gak ngaruh ke scene gameplay jadi nambah dua kali malahan
                money += 200000;
        }
    }


    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == "www.kwodeegames.rushdown.2000xcoins")
        {
            buy1();
            successText.text = "2000 XCoins successfully purchased and added to your balance.   Thank You for purchasing! (^_^)";
            successPanel.SetActive(true);
        }
        if (product.definition.id == "www.kwodeegames.rushdown.10000xcoins")
        {
            buy2();
            successText.text = "10000 XCoins successfully purchased and added to your balance.   Thank You for purchasing! (^_^)";
            successPanel.SetActive(true);
        }
        if (product.definition.id == "www.kwodeegames.rushdown.50000xcoins")
        {
            buy3();
            successText.text = "50000 XCoins successfully purchased and added to your balance.   Thank You for purchasing! (^_^)";
            successPanel.SetActive(true);
        }
        if (product.definition.id == "www.kwodeegames.rushdown.80000xcoins")
        {
            buy4();
            successText.text = "80000 XCoins successfully purchased and added to your balance.   Thank You for purchasing! (^_^)";
            successPanel.SetActive(true);
        }
        if (product.definition.id == "www.kwodeegames.rushdown.200000xcoins")
        {
            buy5();
            successText.text = "200000 XCoins successfully purchased and added to your balance.   Thank You for purchasing! (^_^)";
            successPanel.SetActive(true);
        }
        if (product.definition.id == "www.kwodeegames.rushdown.removeads")
        {
            PlayerPrefs.SetInt("adsremoved", 1);
            successText.text = "In-game pop-up ads has been disabled completely.   Thank You for purchasing! (^_^)";
            successPanel.SetActive(true);
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        failedText.text = "Ooops purchase failed due to : " + failureReason;
        failedPanel.SetActive(true);
    }
}
