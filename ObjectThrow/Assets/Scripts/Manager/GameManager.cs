using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public static GameManager gameManagerInstance;

    [SerializeField] private GameObject[] canvases;
    private void Awake()
    {
        gameManagerInstance = this;
        canvases[0].SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
        }

    }

    public void OnClickPlayButton()
    {
        StartCoroutine(StartTheGame());
        canvases[0].SetActive(false);
    }

    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(0.5f);
        canvases[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        gameStarted = true;

    }

}
