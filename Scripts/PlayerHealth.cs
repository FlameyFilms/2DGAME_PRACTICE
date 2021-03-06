using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    public void UpdateHealth(float mod)
    {
        health += mod;
        if(health > maxHealth) {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            Destroy(gameObject);
        }
    }


    private void OnGUI()
    {
        healthSlider.value = health;
    }
}
