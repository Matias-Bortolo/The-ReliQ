using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAttack : MonoBehaviour
{
    [HideInInspector]
    public bool attacking;

    [SerializeField] private GuardianVisionRange _visionScript;
    [SerializeField] private float _cooldown;
    [SerializeField] private Animator _animator;
    [SerializeField] private SphereCollider attackCollider;

    private float _time;

    private void Awake()
    {
        _time = _cooldown;
    }

    private void Update()
    {
        Attack();

        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            attackCollider.enabled = true;
        }
    }

    private void Attack()
    {
        if (attacking)
        {
            attackCollider.enabled = false;
            _visionScript.following = false;
            _time = 0;
        }
        else if (attacking == false && _visionScript.trigger)
        {
            _visionScript.following = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _time >= _cooldown)
        {
            attacking = true;
            _animator.SetTrigger("Attacking");
        }
    }
}
