using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMeter : MonoBehaviour
{
    public Slider meterSlider;
    [Range(0,60)] [SerializeField]private float meterMaxValue;
  
    [SerializeField] private float meterCurrentValue;

    GameManager gameManager;
    public static GameMeter Instance;

    private void Awake()
    {
        Instance = this;
        meterSlider.maxValue = meterMaxValue;
        meterSlider.value = meterMaxValue;
    }
    private void Start()
    {
        gameManager = GameManager.gameManagerInstance;
    }

    private void FixedUpdate()
    {
        if(gameManager.gameStarted)
        {
            StartReducingMeter();
           
        }
    }

    void StartReducingMeter()
    {
        if(meterSlider.value > 0)
        {
            meterSlider.value = meterSlider.value - 1 * Time.fixedDeltaTime;
        }
       
    }
}
