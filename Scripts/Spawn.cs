using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject FPSController;
    Vector3 spawnCoords = new Vector3();
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlayer()
    {
        spawnCoords = GetComponent<Transform>().position;

        GameObject Player = Instantiate(
                            FPSController,
                            spawnCoords,
                            Quaternion.identity,
                            this.transform);
    }
}
