using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPopup : MonoBehaviour
{
    public Text popUptext;
    private int value;
    // Start is called before the first frame update
    void Start()
    {
        value = GameControl.jumlahNambahnya;
        if(value == 0)
        {
            value = 1;
        }
        popUptext.text = "+" + value;
    }


    public void Ded()
    {
        Destroy(gameObject);
    }
}
