using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour,IPooledObjects
{
    Rigidbody objectRigidbody;
    ObjectRotate objectRotate;
    BoxCollider boxCollider;
    bool collidedwithWall = false;
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectRotate = gameObject.GetComponent<ObjectRotate>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
       
    }
    public void OnObjectSpawn()
    {
        boxCollider.enabled = true;
        objectRigidbody.isKinematic = false;
        objectRotate.isRotating = true;
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        collidedwithWall = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(!collidedwithWall)
            {
                collidedwithWall = true;
                boxCollider.enabled = false;
                objectRigidbody.isKinematic = true;
                objectRotate.isRotating = false;
                Invoke("SetObjectDeactive", 1);
            }
       
        }
    }

    private void SetObjectDeactive()
    {
        gameObject.SetActive(false);

    }
}
