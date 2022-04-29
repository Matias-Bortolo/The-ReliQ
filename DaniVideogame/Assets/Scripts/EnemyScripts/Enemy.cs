using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackHitbox"))
        {
            hp--;
            Debug.Log("Enemigo HP: " + hp);

            if (hp <= 0)
            {
                Destroy(gameObject);
            }

            FindObjectOfType<AudioManager>().Play("EnemyReceivingDamage");
        }
    }
}
