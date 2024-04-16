using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CratesDestroyed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cratesDestroyedText;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManagerInstance;
    }

    // Update is called once per frame
    void Update()
    {
        cratesDestroyedText.text = gameManager.cratesDestroyed.ToString("00");
    }
}
