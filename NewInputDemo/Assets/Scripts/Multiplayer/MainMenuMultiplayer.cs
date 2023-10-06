using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMultiplayer : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    
    [SerializeField] private TMP_Text[] _joinedTexts;

    private void Start()
    {
        //Disable all joinedTexts
        for (int i = 0; i < 4; i++)
        {
            PlayerInput pi = PlayerInput.GetPlayerByIndex(i);
            if (pi== null)
                SetPlayerJoinedText(i, false);
            else
                SetPlayerJoinedText(i, true);

        }
        
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void Update()
    {
        if(Gamepad.current.startButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
            StartGame();
    }

    private void OnDestroy()
    {
        //Important: Always unsubscribe from Events when destroyed!
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
        }
    }
    private void StartGame()
    {
        SceneManager.LoadScene("MultiplayerIngame");
    }

    public void SetPlayerJoinedText(int playerId, bool hasJoined)
    {
        _joinedTexts[playerId].gameObject.SetActive(hasJoined);
    }


    
    private void OnPlayerJoined(PlayerInput newPlayer)
    {
        SetPlayerJoinedText(newPlayer.playerIndex, true);
    }
    
    private void OnPlayerLeft(PlayerInput leftPlayer)
    {
        SetPlayerJoinedText(leftPlayer.playerIndex, false);
    }
}
