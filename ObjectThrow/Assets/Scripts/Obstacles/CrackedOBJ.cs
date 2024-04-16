using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedOBJ : MonoBehaviour,IPooledObjects
{
    [SerializeField] private GameObject[] chilObjects;
    [SerializeField] GameObject spawnEffect;
 
    void SetActive()
    {
        gameObject.SetActive(false);
    }
    public void OnObjectSpawn()
    {
        Invoke("SetActive", 1.5f);
        spawnEffect.SetActive(true);

        foreach (GameObject childOBJ in chilObjects)
        {
            childOBJ.SetActive(true);
            childOBJ.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

  

}
