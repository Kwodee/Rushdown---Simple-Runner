using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles1000;
    public GameObject[] obstacles2000;
    public Transform spawntarget;
    public float SpawnRate = 1f;
    private float nextspawn;
    public Text scoretext;
    private float score;

    void Start()
    {
        nextspawn = Time.time + SpawnRate;
    }
    void Update()
    {
        if(Time.time > nextspawn)
        {
            Spawn();
        }
        score += 1;
        scoretext.text = "You Scored : " + score.ToString();
    }
    private void Spawn()
    {
        if (score < 1000)
        {
            nextspawn = Time.time + SpawnRate;
            int randomcode = Random.Range(0, obstacles1000.Length);
            Instantiate(obstacles1000[randomcode], spawntarget.position, Quaternion.identity);
        }
        if (score > 1000)
        {
            nextspawn = Time.time + SpawnRate;
            int randomcode = Random.Range(0, obstacles2000.Length);
            Instantiate(obstacles2000[randomcode], spawntarget.position, Quaternion.identity);
        }
    }
}
