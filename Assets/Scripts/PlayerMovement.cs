using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int verticalInput;
    int horizInput;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = 0;
        horizInput = 0;
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput++;
        }

        if (Input.GetKey(KeyCode.S))
        {
            verticalInput--;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizInput--;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizInput++;
        }

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(horizInput * speed, 0f, verticalInput * speed);
    }
}
