using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject[] _boxes;
    [SerializeField]
    Transform[] _boxesPosition;
    [SerializeField]
    CharacterController _player;

    CheckpointSub _cpSub;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            _cpSub.BackToCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cpSub = new CheckpointSub(_boxes, _boxesPosition, _player, gameObject);
        }
    }
}
