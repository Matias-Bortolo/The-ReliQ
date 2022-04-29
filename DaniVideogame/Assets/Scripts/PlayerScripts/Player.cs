using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public Transform charCam;
    public CharacterController charControl;
    public PlayerMovement movement;

    Animator _animator;
    AudioManager _AM;

    PlayerControl _control;
    PlayerAttack _attack;
    
    [HideInInspector]
    public Vector3 moveDir;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _AM = FindObjectOfType<AudioManager>();

        movement = new PlayerMovement(transform, charCam, moveDir, charControl, playerSpeed);
        _attack = new PlayerAttack(_animator, _AM);
        _control = new PlayerControl(movement, _attack, _animator);
    }

    void Update()
    {
        _control.ArtificialUpdate();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.playerCurrentHP--;

            GameManager.Instance.hpSlider.value = GameManager.Instance.playerCurrentHP / GameManager.Instance.playerMaxHP;
        }
    }
}
