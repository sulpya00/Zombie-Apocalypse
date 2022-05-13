using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectScript : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemyy;
    public float chaseSpeed = 5f;
    public float hitSpeed = 10f;
    public float timeToHit = 1.3f;
    float originalTime;

    public NavMeshAgent enemy;
    public Transform Player;


    // Start is called before the first frame update



    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        originalTime = timeToHit;
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            Debug.Log("Detected");
            enemy.speed = chaseSpeed;
            enemyy.LookAt(target.transform);
            enemy.SetDestination(target.transform.position);
        }
        else
        {
            Debug.Log("Did not detect");
        }
        //if (detected)
        //{
        //    enemyy.LookAt(target.transform);
        //    enemy.SetDestination(Player.position);
        //}
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToHit -= Time.deltaTime;


            if (timeToHit < 0)
            {
                //HitPlayer();
                timeToHit = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
            Debug.Log("Collisionnnnnnn");
        }
    }

    //private void HitPlayer()
    //{
    //    GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    //    Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
    //    Destroy(currentBullet, 1f);
    //    rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    //}
}
