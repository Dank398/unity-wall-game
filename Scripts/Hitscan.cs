using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitscan : MonoBehaviour
{
    float maxDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject hit;
        bool find = false;
        bool findDestruct = false;
        int i = 0;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, maxDistance))
        {
            hit = hitInfo.collider.gameObject.transform.parent.gameObject;

            while (find == false)
            {
                if (hit == WallGen.wallList[i].GetWall)
                {
                    findDestruct = WallGen.wallList[i].GetDestruct;
                    find = true;
                }
                else if (i > WallGen.numOfWallTiles * WallGen.numOfWalls)
                {
                    Debug.Log("Wall could not be found!");
                    find = true;
                }
                else
                {
                    i++;
                }
            }

            if (findDestruct == true)
            {
                Destroy(hit);
            }

            Debug.Log("Hit " + hit.name);
            Debug.Log(findDestruct);
        }
    }
}
