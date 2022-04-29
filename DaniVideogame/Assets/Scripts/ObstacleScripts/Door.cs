using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed, yDisplacement;
    public GameObject[] plates, boxes;

    private Vector3 _destination;
    private Rigidbody _RB;
    private bool _allBoxesOnTop;
    private float _time;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _destination = transform.position;
        _destination.y += yDisplacement;
    }

    private void Update()
    {
        for (int i = 0; i < plates.Length; i++)
        {
            if (plates[i].GetComponent<PressurePlate>().boxOnTop)
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
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].GetComponent<PushableBox>().enabled = false;
            }
        }       
    }
}
