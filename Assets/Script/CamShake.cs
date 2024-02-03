using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class CamShake : MonoBehaviour
{
    
    private int crashkode;
    private bool alrediCrash;
    public static bool isGeter = false;
    public Animator animator;

    IEnumerator geterrr()
    {
        animator.SetBool("ded", true);
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("ded", false);
        alrediCrash = true;
        isGeter = false;
    }
    void Update()
    {
        if (crashkode == 0)
        {
            animator.SetBool("ded", false);
            alrediCrash = false;
        }
        crashkode = GameControl.stopcode;
        if (crashkode == 1 & alrediCrash == false)
        {           
            StartCoroutine(geterrr());
        }
        if(crashkode == 0 & alrediCrash == true)
        {
            alrediCrash = false;
        }
        if(isGeter == true)
        {
            StartCoroutine(geterrr());
        }
    }
}
