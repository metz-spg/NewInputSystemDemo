using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMultiplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _joinedTexts;

    private void Start()
    {
        
    }

    private void Update()
    {

    }


    private void StartGame()
    {
        SceneManager.LoadScene("MultiplayerIngame");
    }
}
