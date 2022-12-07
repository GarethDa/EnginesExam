using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int health = 3;

    public bool gameLost = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameLost = true;
        }
    }

    public void LoseHealth()
    {
        health--;
        Debug.Log("Current Health: " + health);
    }
}
