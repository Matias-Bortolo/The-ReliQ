using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed, dashTime;

    Player _Player;

    void Awake()
    {
        _Player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {           
            StartCoroutine(Dash());
        }           
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            _Player.charControl.Move(_Player.movement.moveDirection * dashSpeed * Time.deltaTime);
        
            yield return null;
        }
    }
}
