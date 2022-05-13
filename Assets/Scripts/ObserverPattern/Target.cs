using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;


    void OnCollisionEnter(Collision Other)
    {
            if (Other.gameObject.tag == "Bullet")
            {
                Debug.Log("Hit");
                health = health - 10;
                Debug.Log(health);
        }
    }

    //void Update()
    //{
    //    if (health <= 0f)
    //    {
    //        Die();
    //    }
    //}
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
        
        Destroy(gameObject);

    }
}
