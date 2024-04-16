using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private Vector3 forceAngle;
    [SerializeField] private float xForceMax;
    [SerializeField] private float yForceMax;
    [SerializeField] private float xForceMin;
    [SerializeField] private float yForceMin;
    [SerializeField] private float forcePower;
    [SerializeField] private float forcePowerMin;
    [SerializeField] private float forcePowerMax;

    ObjectPooler objectPooler;
    [SerializeField] float objectMass;
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void SetTheForceAndAngle()
    {
        forceAngle = new Vector3(Random.Range(xForceMin, xForceMax), Random.Range(yForceMin, yForceMax), 0);
        forcePower = Random.Range(forcePowerMin, forcePowerMax);
        SpawnTheObjectWithForceAndAngle();
    }

    void SpawnTheObjectWithForceAndAngle()
    {
        GameObject obj = objectPooler.SpawnFromPool("BoxOBJ", transform.position);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.mass = objectMass;
        rb.AddForce(forceAngle* forcePower, ForceMode.Impulse);
        
    }

}
