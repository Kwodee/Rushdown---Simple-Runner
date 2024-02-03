using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantaiSpawner : MonoBehaviour
{
    public Transform deTarget;
    public GameObject lantai;
    public bool mundurorno;
    public float spawnRate;
    private float nextSpawn;
    private int isded;

    // Update is called once per frame
    void Update()
    {
        if (mundurorno == true && isded == 0)
        {
            mundur();
        }
        if (mundurorno == false && Time.time > nextSpawn && isded == 0)
        {
            spawn();
        }
        isded = GameControl.stopcode;
    }

    private void mundur()
    {
        transform.position = new Vector3(transform.position.x + -5 * Time.deltaTime, transform.position.y);
        if (transform.position.x < -35)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
    private void spawn()
    {
        nextSpawn = Time.time + spawnRate;
        //Instantiate(lantai, deTarget.position, Quaternion.identity);
        ObjectPooler.Instance.SpawnFromPool("flor", deTarget.position, Quaternion.identity);
    }
}
