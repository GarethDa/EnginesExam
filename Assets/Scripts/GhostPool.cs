using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPool : MonoBehaviour
{
    [SerializeField] int maxGhosts = 5;

    List<GameObject> ghosts = new List<GameObject>();

    [SerializeField] GameObject ghostPrefab;

    float currentTime = -1f;

    [SerializeField] float spawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxGhosts; i++)
        {
            GameObject newGhost = Instantiate(ghostPrefab);
            newGhost.SetActive(false);
            ghosts.Add(newGhost);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= -1f)
        {
            currentTime = 0f;

            SpawnGhost(new Vector3(0f, 1f, 0f), false);
        }
        
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            currentTime = 0f;

            SpawnGhost(new Vector3(0f, 1f, 0f), false);
        }
    }

    public void SpawnGhost(Vector3 pos, bool overMax)
    {
        //Look through the list, find an inactive ghost
        foreach(GameObject ghost in ghosts)
        {
            if (ghost.activeSelf == false)
            {
                ghost.SetActive(true);
                ghost.GetComponent<Transform>().position = pos;
                return;
            }
        }

        //If we get to this point, there were no inactive ghosts
        if (overMax)
        {
            maxGhosts++;
            GameObject newGhost = Instantiate(ghostPrefab);
            ghosts.Add(newGhost);
        }
    }
}
