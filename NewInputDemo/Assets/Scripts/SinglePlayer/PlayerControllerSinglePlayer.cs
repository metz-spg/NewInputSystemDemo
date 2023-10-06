using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerSinglePlayer : MonoBehaviour
{
    public GameObject _playerPrefab;

    private PlayerInput _playerInput;
    private PlayerMotor _playerMotor;

    private static PlayerControllerSinglePlayer _instance;

    void Awake()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Fire"].performed += OnFire;
        _playerInput.actions["Pause"].performed += OnPause;
        _playerInput.actions["Cancel"].performed += OnCancel;

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        if (newScene.name == "SinglePlayerMenu")
            _playerInput.SwitchCurrentActionMap("UI");
        else
            IngameInitialization();
    }

    private void IngameInitialization()
    {
        GameObject newPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
        newPlayer.name = "Player_" + _playerInput.playerIndex;
        newPlayer.GetComponent<SpriteRenderer>().color = new Color(231 / 255f, 46 / 255f, 90 / 255f);
        _playerMotor = newPlayer.GetComponent<PlayerMotor>();
        _playerInput.SwitchCurrentActionMap("Player");
    }

    private void Update()
    {
        if (_playerMotor != null)
        {
            Vector2 moveVector = _playerInput.actions["Move"].ReadValue<Vector2>();
            _playerMotor._moveDirection = moveVector;
        }
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (_playerMotor != null)
        {
            _playerMotor.ChangeColor();
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        print("Pause");
        _playerInput.SwitchCurrentActionMap("UI");
        FindObjectOfType<PauseWindow>(true).SetWindowVisible(true);
    }
    private void OnCancel(InputAction.CallbackContext context)
    {
        print("Cancel");
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            FindObjectOfType<PauseWindow>(true).SetWindowVisible(false);
        }
    }
}
