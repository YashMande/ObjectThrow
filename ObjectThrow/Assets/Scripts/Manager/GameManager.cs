using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public static GameManager gameManagerInstance;

    [SerializeField] private GameObject[] canvases;
    public int cratesDestroyed;

    public int comboScore;
    [SerializeField] private TextMeshProUGUI streakText;
    [SerializeField]GameMeter gameMeter;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameManagerInstance = this;
        canvases[0].SetActive(true);
       
    }
    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStarted = true;
        }
        if(comboScore>3)
        {
            streakText.text = "Streak x" + comboScore;
        }
 

    }
    public void AddStreakScoreToMain()
    {
        streakText.text = "";
        if(comboScore>3)
        {
            gameMeter.meterSlider.value += comboScore;
            cratesDestroyed += comboScore;
        }    
        comboScore = 0;
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
