using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyBehaviour : MonoBehaviour
{
    public float attackCooldown, bulletSpeed, enemyDelayRotation, bulletDuration;
    public GameObject bullet;

    [SerializeField]
    private GameObject _player;

    private float _time;
    private Rigidbody _shoot;

    public void Shoot()
    {
        _time += Time.deltaTime;

        if (_time >= attackCooldown)
        {
            _time = 0;
            _shoot = Instantiate(bullet.GetComponent<Rigidbody>(), transform.position, transform.rotation);
            _shoot.AddForce(transform.forward * bulletSpeed);
            Destroy(_shoot.gameObject, bulletDuration);
        }       
    }

    public void LookAt()
    {
        var lookPos = _player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * enemyDelayRotation);
    }
}
