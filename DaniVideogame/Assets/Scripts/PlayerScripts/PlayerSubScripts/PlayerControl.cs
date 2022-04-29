using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl
{
    PlayerMovement _movement;
    PlayerAttack _attack;
    Animator _animator;

    float _time = 0;
    float _length = .55f;

    public PlayerControl(PlayerMovement m, PlayerAttack a, Animator anim)
    {
        _movement = m;
        _attack = a;
        _animator = anim;
    }

    public void ArtificialUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 logicMove = new Vector3(horizontal, 0, vertical);
        _animator.SetFloat("Movement", logicMove.magnitude);
        _time += Time.deltaTime;

        if (logicMove.magnitude >= 0.01f)
        {
            _movement.Move(logicMove);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _time >= _length)
        {
            _attack.Attack();
            _time = 0;
        }
    }
}
