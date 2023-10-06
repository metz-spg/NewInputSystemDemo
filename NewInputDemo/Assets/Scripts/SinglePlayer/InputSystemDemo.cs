using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputSystemDemo : MonoBehaviour
{
    private PlayerInput _playerInput;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Fire"].performed += OnFire;
    }

    private void Update()
    {
        Vector2 moveVector = _playerInput.actions["Move"].ReadValue<Vector2>();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        print("Firing bullet");
    }

}
