using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public Text healthDisplay;

    public float health = 100f;

    void Update()
    {
        healthDisplay.text = health.ToString();
        Debug.Log(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "Zombie")
        {
            Debug.Log("collision");
            health = health - 10;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            
            Debug.Log("Collisionnnnnnn!!!");
            health = health - 10;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        
        Debug.Log("You died");
    }
}
