using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singelton
    public static ObjectPooler Instance;

    //private void Awake()
    //{
        //Instance = this;
    //}
    #endregion

    [System.Serializable] // supaya muncul di inspector
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools; // sebuah list yang terdiri dari komponen di dalam class "Pool"
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        // THE POOLING MECHANISM WITH FOREACH AND FOR LOOP
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }    
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
