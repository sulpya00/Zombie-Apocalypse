using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float health = 400f;

    

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            health = health - 10;
            Debug.Log(health);
        }
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("Hit");
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(gameObject);
       

    }

}
