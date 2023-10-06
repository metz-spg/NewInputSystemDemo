using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControllerMultiplayer : MonoBehaviour
{
    public GameObject _playerPrefab;
    public PlayerMotor _playerMotor;
    private PlayerInput _playerInput;

    private Color[] _playerColors = {new Color(231/255f,46/255f,90/255f),
    new Color(27/255f, 169 / 255f, 240 / 255f),
    new Color(0,215/255f,121/255f),
    new Color(255/255f,230/255f,59/255f)};

    void Awake()
    {

        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Fire"].performed += OnFire;
        _playerInput.actions["Pause"].performed += OnPause;
        _playerInput.actions["Cancel"].performed += OnCancel;

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    private void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        if (newScene.name == "MultiplayerMenu")
            _playerInput.SwitchCurrentActionMap("UI");
        else
        {
            GameObject newPlayer = Instantiate(_playerPrefab, new Vector3(-3 + _playerInput.playerIndex * 2, 0, 0), Quaternion.identity);
            newPlayer.name = "Player_" + _playerInput.playerIndex;
            newPlayer.GetComponent<SpriteRenderer>().color = _playerColors[_playerInput.playerIndex];
            _playerMotor = newPlayer.GetComponent<PlayerMotor>();
            _playerInput.SwitchCurrentActionMap("Player");
        }
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
        if (SceneManager.GetActiveScene().name != "MultiplayerMenu")
        {
            FindObjectOfType<PauseWindow>(true).SetWindowVisible(true);
        }
    }
    private void OnCancel(InputAction.CallbackContext context)
    {
        print("Cancel");
        if (SceneManager.GetActiveScene().name != "MultiplayerMenu")
        {
            FindObjectOfType<PauseWindow>(true).SetWindowVisible(false);
        }
    }
}
