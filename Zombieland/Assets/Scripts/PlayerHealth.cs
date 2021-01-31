using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthPoints;

    private void Start() {
        healthPoints.text = "+" + hitPoints.ToString();
    }

    public void TakeDamage(float damage) {
        hitPoints -= damage;
        healthPoints.text = hitPoints.ToString();
        if (hitPoints <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
