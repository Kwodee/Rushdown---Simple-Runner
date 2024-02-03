using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCycle : MonoBehaviour {

    //[SerializeField]
    //float moveSpeed = 5f;
    //[SerializeField]
    //float leftWayPointX = -8f, rightWayPointX = 8f;

    // Update is called once per frame
    //void Update () {
    //transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime,
    //transform.position.y);

    //	if (transform.position.x < leftWayPointX)
    //	transform.position = new Vector2 (rightWayPointX, transform.position.y);
    //}
    //public Rigidbody rb;
    public float Cyclinglul = -1f;
    //private float currentspeed;
    private float stopcode;

    void Update()
    {
        if (stopcode == 0)
        {
            bgCycling();
        }
        stopcode = GameControl.stopcode;       
    }
    public void bgCycling()
    {
        //if (transform.position.x > -41f)
        //{
        //rb.AddForce(Cyclinglul , 0, 0);
        //currentspeed += Cyclinglul * Time.deltaTime;
        //}
        transform.position = new Vector3(transform.position.x + Cyclinglul * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
