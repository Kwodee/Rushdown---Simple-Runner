using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartPlus : MonoBehaviour
{
    public Text plesormin;
    // Start is called before the first frame update
    void Start()
    {
        if(GameControl.pickinHeart == false)
        {
            plesormin.text = "-1";
        }
        if (GameControl.pickinHeart == true)
        {
            plesormin.text = "+1";
        }
    }

    public void dEstRoY()
    {
        Destroy(gameObject);
    }
    public void stoppp()
    {
        GameControl.pickinHeart = false;
    }
}
