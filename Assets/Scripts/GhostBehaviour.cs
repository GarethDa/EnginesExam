using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    List<Transform> lerpPoints = new List<Transform>();

    float currentTime = 0f;
    float maxTime = 2f;

    int startingPoint;
    int endingPoint;

    WinLoss winLossComponent;

    public float iTime = 1f;
    float currentITime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        winLossComponent = GameObject.Find("GameManager").GetComponent<WinLoss>();

        gameObject.GetComponent<Rigidbody>().freezeRotation = true;

        foreach (Transform transform in GameObject.Find("LerpPoints").GetComponentInChildren<Transform>())
        {
            lerpPoints.Add(transform);
        }

        startingPoint = Random.Range(0, lerpPoints.Count - 1);

        endingPoint = Random.Range(0, lerpPoints.Count - 1);

        while (endingPoint == startingPoint)
            endingPoint = Random.Range(0, lerpPoints.Count - 1);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentITime += Time.deltaTime;

        if (currentTime >= maxTime)
        {
            
            startingPoint = endingPoint;

            endingPoint = Random.Range(0, lerpPoints.Count - 1);

            while (endingPoint == startingPoint)
                endingPoint = Random.Range(0, lerpPoints.Count - 1);

            currentTime = 0f;
        }

        gameObject.GetComponent<Transform>().position = Vector3.Lerp(lerpPoints[startingPoint].position, lerpPoints[endingPoint].position, currentTime / maxTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && currentITime >= iTime)
        {
            winLossComponent.LoseHealth();
            currentITime = 0f;
        }
    }
}
