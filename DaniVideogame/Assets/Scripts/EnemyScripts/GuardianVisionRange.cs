using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianVisionRange : MonoBehaviour
{
    [HideInInspector]
    public bool following, trigger;

    [SerializeField]
    private GameObject _enemy, _player;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (following)
        {
            _enemy.GetComponent<NavMeshAgent>().isStopped = false;
            _animator.SetBool("Walking", true);

            _enemy.GetComponent<NavMeshAgent>().destination = _player.GetComponent<Rigidbody>().position;
        }
        else
        {
            _enemy.GetComponent<NavMeshAgent>().isStopped = true;
            _animator.SetBool("Walking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            following = true;
            trigger = true;
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
