using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    public Vector3 moveDirection;
    
    Transform _transform, _charCam;
    CharacterController _charControl;
    float _playerSpeed;

    public PlayerMovement(Transform t, Transform cC, Vector3 mD, CharacterController charC, float pS)
    {
        _transform = t;
        _charCam = cC;
        moveDirection = mD;
        _charControl = charC;
        _playerSpeed = pS;
    }

    public void Move(Vector3 lM)
    {
        float angle = Mathf.Atan2(lM.x, lM.z) * Mathf.Rad2Deg + _charCam.eulerAngles.y;
        _transform.rotation = Quaternion.Euler(0, angle, 0);

        moveDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        _charControl.Move(moveDirection * _playerSpeed * Time.deltaTime);
    }
}
