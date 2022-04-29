using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyVision : MonoBehaviour
{
    RangeEnemyBehaviour _rangeEnemy;

    private void Awake()
    {
        _rangeEnemy = GetComponentInParent<RangeEnemyBehaviour>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _rangeEnemy.LookAt();
            _rangeEnemy.Shoot();
        }
    }
}
