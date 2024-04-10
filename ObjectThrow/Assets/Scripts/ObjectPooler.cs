using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;  //which type of object to spawn
        public GameObject prefab; //The object
        public int size; //Total number of objects 
    }

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools; //list of pools
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools) //for every poolk entry in Pools
        {
            Queue<GameObject> objectPool = new Queue<GameObject>(); //start a queue of objects

            for (int i = 0; i < pool.size; i++) //for the pool size mentioned in inspector
            {
                GameObject obj = Instantiate(pool.prefab); //create the object specified in Pool
                obj.SetActive(false); //sets it inactive
                objectPool.Enqueue(obj); //gets the next object in queue
            }

            poolDictionary.Add(pool.tag, objectPool); //adds the object to the pool Dictonary
        }
    }

    public GameObject SpawnFromPool( string tag, Vector3 position) //spawn from the pool and queue
    {
        if(!poolDictionary.ContainsKey(tag)) //check if the the pool dictonary contain the name tag for given object to spawn
        {
            Debug.LogWarning("Pool with tag" + tag + "Doest exist"); //if not, warning
            return null;//return (dpnt run the code below)
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue(); //dequeue the object which in queue

        objectToSpawn.SetActive(true);//set it to active
        objectToSpawn.transform.position = position; //set the position to the spawnPoint position
       

        IPooledObjects pooledObj = objectToSpawn.GetComponent<IPooledObjects>();
        if(pooledObj!= null)
        {
            pooledObj.OnObjectSpawn(); //start function runs everytime the object is used 
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
