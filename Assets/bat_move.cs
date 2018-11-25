using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bat_move : MonoBehaviour
{
    float speed = 6.0f;
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;
    }
}
