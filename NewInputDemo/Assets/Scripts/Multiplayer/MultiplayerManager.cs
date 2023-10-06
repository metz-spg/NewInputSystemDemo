using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MultiplayerManager : MonoBehaviour
{
    private static MultiplayerManager _instance;
    private PlayerInputManager _playerInputManager;

    private void Awake()
    {
        //Singleton
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _playerInputManager = GetComponent<PlayerInputManager>();
    }

    void Start()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDestroy()
    {
        if (PlayerInputManager.instance != null)
        {
            PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
            PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
        }
    }

    private void OnPlayerJoined(PlayerInput newPlayer)
    {
        newPlayer.transform.parent = transform;
        newPlayer.gameObject.name = "P" + newPlayer.playerIndex + "_PlayerInput";
        print("Player " + newPlayer.playerIndex + "joined");
    }

    private void OnPlayerLeft(PlayerInput leftPlayer)
    {
        print("Player " + leftPlayer.playerIndex + " left");
    }
}