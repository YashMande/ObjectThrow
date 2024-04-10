using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour,IPooledObjects
{
    Rigidbody objectRigidbody;
    ObjectRotate objectRotate;
    bool collidedwithWall = false;
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectRotate = gameObject.GetComponent<ObjectRotate>();
       
    }
    public void OnObjectSpawn()
    {
        objectRigidbody.isKinematic = false;
        objectRotate.isRotating = true;
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        collidedwithWall = false;
    }

    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(!collidedwithWall)
            {
                collidedwithWall = true;
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
