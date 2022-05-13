using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score ;

    public static Score instance;

    private void Start()
    {
        InvokeRepeating("AddScore", 2.0f, 5.0f);

    }

    private void Update()
    {
        
        

    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
       
        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
        AddScore();
    }

    public void AddScore()
    {

        score = score + 10;
        scoreText.text = score.ToString();
        
    }

}
