using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    [SerializeField]
    private float _units, _boxSpeed;

    private Rigidbody _RB;
    private Vector3 _destination, _face;
    private bool _activate;
    private float _time;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _destination = transform.position;
    }

    private void Update()
    {
        Activation();
        Deactivation();

        _time += Time.deltaTime;
    }

    void Activation()
    {
        if (_activate)
        {
            _destination.y = transform.position.y;
            _RB.MovePosition(Vector3.MoveTowards(transform.position, _destination, _boxSpeed * Time.deltaTime));
            _time = 0;
        }
    }

    void Deactivation()
    {
        if (transform.position.x == _destination.x && transform.position.z == _destination.z)
        {
            _activate = false;
            _destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PushHitbox") && _time >= .3f)
        {
            FindObjectOfType<AudioManager>().Play("BoxBeingPushed");

            _face = transform.position - other.transform.parent.position;

            if (Mathf.Abs(_face.x) > Mathf.Abs(_face.z))
            {
                if (_face.x < 0) // Izquierda
                {
                    _destination.x -= _units;
                }
                else // Derecha
                {
                    _destination.x += _units;
                }
            }
            else
            {
                if (_face.z < 0) // Atras
                {
                    _destination.z -= _units;
                }
                else // Adelante
                {
                    _destination.z += _units;
                }
            }

            _activate = true;
        }
    }

    
}
