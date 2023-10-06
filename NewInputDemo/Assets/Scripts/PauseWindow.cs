using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
    public Button _resumeBtn;
    public Button _backToMenuBtn;

    public string _menuToReturnTo;

    void Awake()
    {
        _resumeBtn.onClick.AddListener(OnResumePressed);
        _backToMenuBtn.onClick.AddListener(OnBackToMenuPressed);
    }

    public void SetWindowVisible(bool isVisible)
    {
        gameObject.SetActive(isVisible);
        _resumeBtn.Select();
        foreach (PlayerInput pi in PlayerInput.all)
        {
            if(isVisible)
                pi.SwitchCurrentActionMap("UI");
            else
                pi.SwitchCurrentActionMap("Player");

        }
    }

    private void OnResumePressed()
    {
        SetWindowVisible(false);
    }

    private void OnBackToMenuPressed()
    {
        SceneManager.LoadScene(_menuToReturnTo);
    }
}
