using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrow : MonoBehaviour
{
    ObjectPooler objectPooler;
    [SerializeField] private LayerMask groundMask;

    public GameObject prefab;
    [SerializeField]private Camera mainCamera;
    GameManager gameManager;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        gameManager = GameManager.gameManagerInstance;
    }
    void Update()
    {
        CheckIfGameStarted();
        
    }
    void CheckIfGameStarted()
    {
        if(gameManager.gameStarted)
        {
            Aim();
        }
      
    }
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            transform.forward = direction;
            if (Input.GetMouseButtonDown(0))
            {        
               GameObject obj= objectPooler.SpawnFromPool("AXE", gameObject.transform.position);
               obj.transform.forward = direction;
               obj.GetComponent<Rigidbody>().AddForce(direction * 250, ForceMode.Impulse);
            }
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

  
}
