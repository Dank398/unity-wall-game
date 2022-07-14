using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GenerateFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject FloorPrefab;
    public static List<string> floorList = new List<string>();

    public void GenerateFloor()
    {
        // Column is z and row is x
        // Use the cornerCoords array from WallGen
        // to find out the dimensions for floor tile gen
        int columnNum = WallGen.mapLength;
        int rowNum = WallGen.mapHeight;
        // Waits until WallGen has completed to get the coords
        /*
        do
        {
            columnNum = WallGen.mapLength;
            rowNum = WallGen.mapHeight;
        } while (WallGen.genComplete == false);
        */
        int startX = WallGen.floorStartX;
        int startZ = WallGen.floorStartZ;

        // int row = startX; row < rowNum + startX; row++
        // int column = startZ; column < columnNum + startZ; column++

        for (int column = startZ; column < columnNum + startZ; column++)
        {
            for (int row = startX; row < rowNum + startX; row++)
            {
                GameObject floorTile = Instantiate(
                    FloorPrefab,
                    new Vector3(row, 0, column),
                    Quaternion.identity,
                    this.transform);

                // This rng number will be used for choosing the type of floor tile
                int floorRNG = Random.Range(0, 100);
                var floor = new Floor(floorTile, floorRNG);
                floor.GetFloor.name = string.Format($"Floor {column},{row}");

                if (floorRNG > 50 && floorRNG <= 80)
                {
                    floor.tileType = "Mud";
                }
                else if (floorRNG > 80)
                {
                    floor.tileType = "Water";
                }

                floorList.Add(floor.tileType);
            }
        }
        /*
        for (int i = 0; i < floorList.Count; i++)
        {
            Debug.Log(floorList[i]);
        }
        */
    }
}
