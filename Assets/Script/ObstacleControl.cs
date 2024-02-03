using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {

	public float moveSpeed = -5f;
    private float stopcode = 0; // game over or no ( karakter nabrak )
    //classification auto stuff
    public bool jumpObs;
    public bool sledObs;
    public bool birdObs;
    private bool alrediJump = false; // autoplay ga ke spam teros

    //object pooling stuff
    public bool isRestart = true;
    public Transform[] posisiKoin;
    private Vector3[] simpenPermanen = new Vector3[25];

    //for koin yang terdisable
    public GameObject[] collectable;

    void Start()
    {
        // u wondrin why the fuck so complex? well say thank u to fukin object pooling gey not destroyed so posisi akibat magnet lerp still spawn langsung directly di depan muka player and everything fucks up in the middle of my waktu istirahat which ruins my istirahat and fukk untll night very impressivve huh
        //if (posisiKoin.Length > 0)
        //{
        //for (int i = 0; i < posisiKoin.Length; i++)
        //{
        //simpenPermanen[i] = posisiKoin[i].position;
        //}
        //}
        if (collectable.Length > 0)
        {
            for (int i = 0; i < collectable.Length; i++)
            {
                simpenPermanen[i] = collectable[i].transform.position;
            }
        }
    }
    void Update()
    {
        stopcode = GameControl.stopcode;

        if (isRestart)
            onStart();

        if (transform.position.x < -18.5f) // 2 itu buat respawn dari nyawa
        {
            if (stopcode == 3)
            {
                gameObject.SetActive(false);
                isRestart = true;
            }
            if (stopcode == 2)
            {
                gameObject.SetActive(false);
                isRestart = true;
            }
        }
        if (stopcode == 0)
        {
            Reverse();
        }     
	}
    private void onStart()
    {
        isRestart = false;
        //if (posisiKoin.Length > 0)
        //{
        //    for (int i = 0; i < posisiKoin.Length; i++)
        //    {
        //        posisiKoin[i].position = simpenPermanen[i];
        //   }
        //}
        if (collectable.Length > 0)
        {
            for(int i = 0; i < collectable.Length; i++)
            {
                collectable[i].transform.position = simpenPermanen[i];
                collectable[i].SetActive(true);
            }
        }
    }
    public void Reverse()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -35 && gameObject != null)
        {
            gameObject.SetActive(false);
            isRestart = true;
        }
        if (transform.position.x < -22.8f && alrediJump == false)
        {
            if(jumpObs == true)
            {
                DinoControl.autoVal = 1; // choose jump, slide, or roll
                GameControl.tabrakValue = 0; // fail ui identification
            }
            if (sledObs == true)
            {
                DinoControl.autoVal = 2;
                GameControl.tabrakValue = 1;
            }
            if (jumpObs == true && birdObs == true)
            {
                DinoControl.autoVal = 3;
                GameControl.tabrakValue = 3;
            }
            if(birdObs == true && jumpObs == false)
            {
                DinoControl.autoVal = 4;
                GameControl.tabrakValue = 2;
            }
            alrediJump = true;
        }         
    }
}
