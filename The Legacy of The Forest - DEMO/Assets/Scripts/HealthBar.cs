using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image HealthBarImage;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerController player;

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        CurrentHealth = player.health;
        HealthBarImage.fillAmount = CurrentHealth / MaxHealth;
    }
}
