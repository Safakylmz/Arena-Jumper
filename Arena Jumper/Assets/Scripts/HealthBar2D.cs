using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar2D : MonoBehaviour
{
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    public void Start()
    {
        totalhealthBar.fillAmount = Health2D.currentHealth / 10;
    }
    public void Update()
    {
        currenthealthBar.fillAmount = Health2D.currentHealth / 10;
    }
}
