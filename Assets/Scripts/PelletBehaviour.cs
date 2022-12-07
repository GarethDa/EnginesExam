using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletBehaviour : MonoBehaviour
{
    WinLoss winLossComponent;

    // Start is called before the first frame update
    void Start()
    {
        winLossComponent = GameObject.Find("GameManager").GetComponent<WinLoss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            winLossComponent.AddScore();
        }
    }
}
