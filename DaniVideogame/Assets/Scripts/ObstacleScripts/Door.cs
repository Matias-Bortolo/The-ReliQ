using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float speed, yDisplacement;
    [SerializeField] private Rigidbody _RB;
    [SerializeField] private PressurePlate[] _plates;
    [SerializeField] private PushableBox[] _boxes;

    private Vector3 _destination;
    private bool _allBoxesOnTop;
    private float _time;

    private void Start()
    {
        _destination = transform.position;
        _destination.y += yDisplacement;
    }

    private void Update()
    {
        for (int i = 0; i < _plates.Length; i++)
        {
            if (_plates[i].boxOnTop)
            {
                _allBoxesOnTop = true;
            }
            else
            {
                _allBoxesOnTop = false;
                return;
            }
        }

        if (_allBoxesOnTop)
        {
            ActivateDoor();
        }
    }

    private void ActivateDoor()
    {
        _RB.MovePosition(Vector3.MoveTowards(transform.position, _destination, speed * Time.deltaTime));
        _time += Time.deltaTime;

        if (_time >= .2f)
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].enabled = false;
            }
        }       
    }
}
