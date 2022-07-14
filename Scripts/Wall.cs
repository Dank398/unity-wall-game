using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
    private readonly GameObject wall;
    private readonly int wallNum = 0;
    Vector3 wallPosition;
    private bool IsDestruct;

    public Wall(GameObject newWall, int num)
    {
        wall = newWall;
        wallNum = num;
        wallPosition = wall.transform.position;
        IsDestruct = false;
    }

    public GameObject GetWall
    {
        get { return wall; }
    }

    public int GetWallNum
    {
        get { return wallNum; }
    }

    public Vector3 WallPos
    {
        get { return wallPosition; }
    }

    public bool GetDestruct
    {
        get { return IsDestruct; }
    }

    public bool SetDestruct
    {
        set { IsDestruct = value; }
    }
}
