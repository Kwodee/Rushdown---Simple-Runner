using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoControl : MonoBehaviour 
{
    public bool AutoPlay = false;
    public static int autoVal;
    public Rigidbody rb;
    public AudioSource LoncatSFX;
    private float jumPowaa = 4.8f;
    public Animator animator;
    private bool roll = false;
    public static bool nobutton;
    public static int airTime = 0;
    public GameObject charac;
    private int stopcode;
    private int dobelint;
    private int jumpKe;
    private int highint;
    public Transform target;
    public SkinnedMeshRenderer renderer;
    private ParticleSystem ps;
    private bool noDetek;
    private bool isFloor;
    public GameObject[] particleTypes;

    void Start()
    {
        nobutton = true;
        rb.isKinematic = false;
        noDetek = true;
        animator.SetBool("ded", false);
        animator.SetFloat("gamestarted", 1);
        rb.AddForce(3500, 0, 0);
        renderer.enabled = true;
        Invoke("tEst", 1.3f);
        dobelint = PlayerPrefs.GetInt("dobelint");
        jumpKe = 0;
        highint = PlayerPrefs.GetInt("highint");
        autoVal = 0;

        if (highint == 0)
        {
            jumPowaa = 4.8f;
        }
        if (highint == 1)
        {
            jumPowaa = 5.8f;
        }
        if (PlayerPrefs.GetInt("trailke") == 0)
        {
            particleTypes[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("trailke") == 1)
        {
            particleTypes[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("trailke") == 2)
        {
            particleTypes[2].SetActive(true);
        }
        ps = GetComponentInChildren<ParticleSystem>();

        if (PlayerPrefs.GetInt("trail") == 0)
        {
            ps.enableEmission = false;
        }
        if (PlayerPrefs.GetInt("trail") == 1)
        {
            ps.enableEmission = true;
        }
   
        float red = PlayerPrefs.GetFloat("red cala");
        float green = PlayerPrefs.GetFloat("green cala");
        float blue = PlayerPrefs.GetFloat("blue cala");
        ps.startColor = new Color(red, green, blue, 1);      
    }
    private void tEst()
    {
        nobutton = false;
    }
    IEnumerator Respawned()
    {
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.15f);
        renderer.enabled = true;
    }
    public void  jumplul()
    {
        if (nobutton == false && transform.position.y < 1.7 && highint == 0)
        {
            if(dobelint == 0) //can only jump once
            {
                if(transform.position.y < 0.6)
                {
                    LoncatSFX.Play();
                    rb.velocity = Vector2.up * jumPowaa;                   
                    roll = false;
                    animator.SetBool("sleded", false);                   
                }
                if(isFloor == true)
                {
                    LoncatSFX.Play();
                    rb.velocity = Vector2.up * jumPowaa;
                    roll = false;
                    animator.SetBool("sleded", false);                  
                }
            }
            if (dobelint == 1 && jumpKe < 1) // can jump twice, and only twice no more.
            {
                jumpKe += 1;
                LoncatSFX.Play();
                rb.velocity = Vector2.up * jumPowaa;
                roll = false;
                animator.SetBool("sleded", false);               
            }
        }
        if (nobutton == false && transform.position.y < 2.5 && highint == 1)
        {
            if (dobelint == 0) //can only jump once
            {
                if (transform.position.y < 0.6)
                {
                    LoncatSFX.Play();
                    rb.velocity = Vector2.up * jumPowaa;
                    roll = false;
                    animator.SetBool("sleded", false);               
                }
            }
            if (dobelint == 1 && jumpKe < 1) // can jump twice, and only twice no more.
            {
                jumpKe += 1;
                LoncatSFX.Play();
                rb.velocity = Vector2.up * jumPowaa;
                roll = false;
                animator.SetBool("sleded", false);               
            }
        }
        if (isFloor == true)
        {
            LoncatSFX.Play();
            rb.velocity = Vector2.up * jumPowaa;
            roll = false;
            animator.SetBool("sleded", false);          
        }
    }
    public void oldJumpMethod()
    {
        if (nobutton == false)
        {
            //rb.velocity = new Vector3 (0, jumPowaa, 0);
            rb.AddForce(0, 2400, 0);
            roll = false;
            animator.SetBool("sleded", false);
            //Loncat.Play(); 
        }
    }
    public void nunduklul()
    {
        if (transform.position.y < 1.2 && nobutton == false) //0.9
        {
            animator.SetBool("sleded", true);
        }
        if (transform.position.y > 0.5 && nobutton == false) //0.7
        {           
            roll = true;
            rb.AddForce(0, -3000, 0);     
        }
    }       
    public void nonunduk()
    {
        if (transform.position.y < 1.2) //0.501f
        {
            animator.SetBool("sleded", false);
        }
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (stopcode == 0)
        {
            if (collisionInfo.collider.tag == "Obstacle")
            {
                if (GameControl.shieldpicked == 0)
                {
                    GameControl.instance.DinoHit();
                    animator.SetBool("ded", true);
                    ps.enableEmission = false;
                    Handheld.Vibrate();
                }
                if (GameControl.shieldpicked == 2)
                {
                    GameControl.shieldpicked = 0;
                    GameControl.stopcode = 3;                   
                    CamShake.isGeter = true;
                    Invoke("shieldyo", 0.1f);
                    Handheld.Vibrate();
                }
            }
            if (collisionInfo.collider.tag == "Floor")
            {
                isFloor = true;
            }
            else
                isFloor = false;
        }
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        if(isFloor == true)
        {
            isFloor = false;
        }
    }
    private void shieldyo() // buat shield nabrak
    {
        GameControl.stopcode = 0;
    }

    void Update()
    {
        if (transform.position.y < 0.6) //0.6
        {
            animator.SetBool("Jumped", false);
            airTime = 0;
        }
        if(isFloor == true)
        {
            animator.SetBool("Jumped", false);
            roll = false;
            airTime = 0;
        }
        if (transform.position.y < 0.51) //0.3
        {
            roll = false;
            jumpKe = 0;
        }
        if (transform.position.y > 0.6 && isFloor == false)
        {
            animator.SetBool("Jumped", true);
            airTime = 1;
        }
        if(transform.position.x > -31.5f)
        {
            noDetek = false; //biar ga ke dinohit kecepatan cahaya per detik
        }
        if (transform.position.x < -31.5f && noDetek == false) // supaya bug mundur tak terjadi
        {
            noDetek = true;
            GameControl.instance.DinoHit();
            animator.SetBool("ded", true);
            ps.enableEmission = false;
            Handheld.Vibrate();
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 900, 0);
        }
        if (Input.GetKey("s"))
        {
            nunduklul();
        }
        if (roll == true)
        {
            animator.SetBool("roll", true);
        }
        if (roll == false)
        {
            animator.SetBool("roll", false);
        }
 
        stopcode = GameControl.stopcode;
        if (stopcode == 0)
        {
            animator.SetBool("ded", false);
            if (PlayerPrefs.GetInt("trail") == 1)
            {
                ps.enableEmission = true;
            }
        }
        if (stopcode == 2)
        {
            noDetek = true;
            charac.transform.position = target.transform.position;
            StartCoroutine(Respawned());
            animator.SetBool("ded", false);
            animator.SetBool("roll", false);
            animator.SetBool("sleded", false);
        }
        float red = PlayerPrefs.GetFloat("red cala");
        float green = PlayerPrefs.GetFloat("green cala");
        float blue = PlayerPrefs.GetFloat("blue cala");
        ps.startColor = new Color(red, green, blue, 1);

        //AI Stuff
        if(AutoPlay == true)
        {
            if(autoVal == 1)
            {
                jumplul();
                autoVal = 0;
            }
            if (autoVal == 2)
            {
                nunduklul();
                Invoke("nonunduk", 0.6f);
                autoVal = 0;
            }
            if (autoVal == 3)
            {
                jumplul();
                Invoke("nunduklul", 0.5f);
                autoVal = 0;
            }
            if (autoVal == 4)
            {
                jumplul();
                Invoke("nunduklul", 0.25f);
                autoVal = 0;
            }
        }
    }
}
