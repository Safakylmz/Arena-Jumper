using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2D : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public static float currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            GameManager2D.isGameOver = true;
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

}
