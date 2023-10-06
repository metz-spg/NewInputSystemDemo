using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float _moveSpeed = 5;
    public Vector3 _moveDirection;

    void Update()
    {
        transform.position += _moveDirection * Time.deltaTime * _moveSpeed;
    }

    public void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = new Color
        (Random.Range(0, 1f),
        Random.Range(0, 1f),
        Random.Range(0, 1f));
    }

}
