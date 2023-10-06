using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
