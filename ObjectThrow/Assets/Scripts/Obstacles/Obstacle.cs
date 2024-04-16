using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IPooledObjects
{
    ObjectPooler objectPooler;
    [SerializeField]private Rigidbody rb;
    GameMeter gameMeter;
    [SerializeField] private float DestroyReward;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        gameMeter = GameMeter.Instance;
    }
    public void OnObjectSpawn()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        rb.velocity = new Vector3(0,0,0);
        rb.angularVelocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AXE"))
        {
            ObjectDestroyed();

        }
       
    }
    void ObjectDestroyed()
    {
        gameMeter.meterSlider.value += DestroyReward;
        objectPooler.SpawnFromPool("BoxCracked", gameObject.transform.position);
        gameObject.SetActive(false);
    }
}
