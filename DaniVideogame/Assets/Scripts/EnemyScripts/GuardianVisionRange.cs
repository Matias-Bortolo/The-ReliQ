using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianVisionRange : MonoBehaviour
{
    [HideInInspector]
    public bool following, trigger;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _player;
    [SerializeField] private NavMeshAgent _enemy;
    [SerializeField] private SphereCollider _visionCollider;

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        if (following)
        {
            _enemy.isStopped = false;
            _animator.SetBool("Walking", true);

            _enemy.destination = _player.position;
        }
        else
        {
            _enemy.isStopped = true;
            _animator.SetBool("Walking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            following = true;
            trigger = true;
            _visionCollider.enabled = false;
        }
    }
}
