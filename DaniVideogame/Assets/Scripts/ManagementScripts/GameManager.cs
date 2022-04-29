using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Slider hpSlider;
    public float playerCurrentHP, playerMaxHP;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerCurrentHP = playerMaxHP;
        hpSlider.value = 1;
    }

    private void Update()
    {
        if (playerCurrentHP <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
