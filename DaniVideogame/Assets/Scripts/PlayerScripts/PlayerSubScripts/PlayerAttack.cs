using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    Animator _anim;
    AudioManager _AM;

    public PlayerAttack(Animator a, AudioManager am)
    {
        _anim = a;
        _AM = am;
    }

    public void Attack()
    {
        _anim.SetTrigger("Attacking");
        _AM.Play("ProtAttacking");
    }
}
