using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour
{
    ObjectPooler objectPooler;
    [SerializeField] private LayerMask groundMask;

    public GameObject prefab;
    [SerializeField]private Camera mainCamera;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
    }
    void Update()
    {
        Aim();
    }
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            //// You might want to delete this line.
            //// Ignore the height difference.
            //direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
            if (Input.GetMouseButtonDown(0))
            {
               
               GameObject obj= objectPooler.SpawnFromPool("AXE", gameObject.transform.position);
                obj.transform.forward = direction;
                //obj.GetComponent<Rigidbody>().velocity = direction * 2;
                obj.GetComponent<Rigidbody>().AddForce(direction * 250, ForceMode.Impulse);
            }
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

  
}
