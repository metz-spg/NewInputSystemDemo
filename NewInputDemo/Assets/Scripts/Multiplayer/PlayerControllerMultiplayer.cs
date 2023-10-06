using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerMultiplayer : MonoBehaviour
{
    public GameObject _playerMotorPrefab;
    public PlayerMotor _playerMotor;

    private Color[] _playerColors = {new Color(231/255f,46/255f,90/255f),
    new Color(27/255f, 169 / 255f, 240 / 255f),
    new Color(0,215/255f,121/255f),
    new Color(255/255f,230/255f,59/255f)};

    void Awake()
    {

    }

   private void Update()
    {
       
    }
}
