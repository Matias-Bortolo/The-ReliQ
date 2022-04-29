using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public GameObject enemy;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemy.GetComponent<NavMeshAgent>().isStopped = false;
            enemy.GetComponent<NavMeshAgent>().destination = other.GetComponent<Rigidbody>().position;

            _animator.SetBool("Walking", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemy.GetComponent<NavMeshAgent>().isStopped = true;

        _animator.SetBool("Walking", false);
    }
}
