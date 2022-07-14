using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor
{
    private readonly GameObject floor;
    private readonly int floorNum = 0;
    public string tileType { get; set; }

    public Floor(GameObject newFloor, int num)
    {
        floor = newFloor;
        floorNum = num;
        tileType = "";
    }

    public GameObject GetFloor
    {
        get { return floor; }
    }

    public int GetFloorNum
    {
        get { return floorNum; }
    }
}
