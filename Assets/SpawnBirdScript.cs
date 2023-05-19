using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirdScript : MonoBehaviour
{
    public GameObject bird;
    public float spawnRate = 3;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnBirb();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnBirb();
            timer = 0;
        }
    }

    void spawnBirb()
    {
        Instantiate(bird, transform.position, transform.rotation);
    }
}
