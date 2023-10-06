using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSinglePlayer : MonoBehaviour
{
    public Button _startBtn;
    public Button _flashColorsBtn;
    public Image _backgroundImage;

    void Awake()
    {
        _startBtn.onClick.AddListener(OnStartClicked);
        _flashColorsBtn.onClick.AddListener(FlashColors);

        _startBtn.Select();

    }

    private void OnStartClicked()
    {
        SceneManager.LoadScene("SinglePlayerIngame");
    }
    private void FlashColors()
    {
        _backgroundImage.color = new Color(Random.Range(0, 1f),
            Random.Range(0, 1f),
            Random.Range(0, 1f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
