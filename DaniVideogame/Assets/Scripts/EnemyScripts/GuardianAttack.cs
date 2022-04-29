using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianAttack : MonoBehaviour
{
    public GameObject followRadius;
    public float cooldown;

    [HideInInspector]
    public bool attacking;

    private Animator _animator;
    private float _time;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _time = cooldown;
    }

    private void Update()
    {
        Attack();

        _time += Time.deltaTime;

        if (_time >= cooldown)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }

    private void Attack()
    {
        if (attacking)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            followRadius.GetComponent<GuardianVisionRange>().following = false;
            _time = 0;
        }
        else if (attacking == false && followRadius.GetComponent<GuardianVisionRange>().trigger)
        {
            followRadius.GetComponent<GuardianVisionRange>().following = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _time >= cooldown)
        {
            attacking = true;
            _animator.SetTrigger("Attacking");
        }
    }
}
