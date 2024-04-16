using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private SpawnPoints[] spawnPoint;
    private int spawnPointNumber;
    private bool startSpawning;
    float spawnDelay = 0;
    GameManager gameManager;

    [SerializeField] private float spawnDelayMin;
    [SerializeField] private float spawnDelayMax;
    
    private void Start()
    {
        gameManager = GameManager.gameManagerInstance;
    }

    void Update()
    {
        CheckIfGameStarted();
    
    }
    void CheckIfGameStarted() // if yes, start spawning
    {
        startSpawning = gameManager.gameStarted;
        if (startSpawning && spawnDelay == 0)
        {
            SelectSpawnPoint();
           
        }
    }
    public void SelectSpawnPoint()
    {
        spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        StartCoroutine(WaitTimerBeforeNextSpawn());
        spawnPointNumber = Random.Range(0, 14);
        spawnPoint[spawnPointNumber].SetTheForceAndAngle();
    }
    IEnumerator WaitTimerBeforeNextSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        spawnDelay = 0;
    }

}
