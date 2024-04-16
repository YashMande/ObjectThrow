using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IPooledObjects
{
    ObjectPooler objectPooler;
    [SerializeField]private Rigidbody rb;
    GameMeter gameMeter;
    [SerializeField] private int DestroyReward;
    [SerializeField] private int DoubleLineDestroyReward;
    [SerializeField] private Transform pointsTextPosition;

    bool collidingWithDoubleLine = false;
    GameManager gameManager;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        gameMeter = GameMeter.Instance;
        gameManager = GameManager.gameManagerInstance;
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
            if (collidingWithDoubleLine)
            {
                ObjectDestroyed(DoubleLineDestroyReward,"x2");
            }
            else
            {
                ObjectDestroyed(DestroyReward,"x1");
            }
           
        }
             
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "DoubleLine")
        {
            collidingWithDoubleLine = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DoubleLine")
        {
            collidingWithDoubleLine = false;
        }
    }
    void ObjectDestroyed(int destroyReward,string scoreText)
    {
        gameMeter.meterSlider.value += destroyReward;
        objectPooler.SpawnFromPool("BoxCracked", gameObject.transform.position);
        objectPooler.SpawnFromPool(scoreText, pointsTextPosition.position);
        gameManager.cratesDestroyed+= destroyReward;
        gameObject.SetActive(false);
    }
}
