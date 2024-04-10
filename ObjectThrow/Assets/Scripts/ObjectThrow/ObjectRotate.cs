using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] private GameObject rotationObject;
    [HideInInspector]public bool isRotating = true;

    void Update()
    {
        if(isRotating)
        {
            rotationObject.transform.Rotate(Vector3.forward, 1000 * Time.deltaTime);
        }
       
    }

 


}
