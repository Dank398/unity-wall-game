using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGen : MonoBehaviour
{
    // Awake is called before Start
    void Awake()
    {
        Gen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject WallPrefab;
    int x = 0;
    int z = 0;
    public static int numOfWallTiles = 20;
    public static int numOfWalls = 4;
    static int wallNum = 0;
    int rngFloor = 0;
    // This number tells us which corner the generater is at
    //public static int cornerNum = 0;
    // Two-dimensional array that stores the x and z coords of each corner
    public static int[,] cornerCoords = new int[2, 3];
    // These coords will be used for the start positon of the floor gen
    public static int floorStartX = 0;
    public static int floorStartZ = 0;
    // This is the length and height of the map
    // Initalised to 1 to compensate for the iteration
    public static int mapLength = 1;
    public static int mapHeight = 1;
    public static List<Wall> wallList = new List<Wall>();
    public static int[] rngArray = new int[numOfWalls];
    bool setWin = false;
    Vector3 winPos = new Vector3();
    public static bool genComplete = false;

    public void Gen()
    {
        for (int w = 0; w < numOfWalls; w++)
        {
            int cornerNum = 0;
            int[] numArray = new int[numOfWallTiles];
            bool genRNG = true;
            for (int n = 0; n < numOfWallTiles; n++)
            {
                numArray[n] = n;
            }
            // This is an rng number for choosing which wall is destructable
            int wallRNG = Random.Range(rngFloor, numOfWallTiles);
            for (int i = 0; i < numOfWallTiles; i++)
            {
                bool atCorner = false;
                // Detect if the generator is at a corner
                if (i % (numOfWallTiles / 4) == 0 && i >= (numOfWallTiles / 4))
                {
                    atCorner = true;
                    cornerNum++;
                    cornerCoords[0, cornerNum - 1] = x;
                    cornerCoords[1, cornerNum - 1] = z;
                }

                // Deviate the pos of the walls
                switch (cornerNum)
                {
                    case 1:
                        x++;
                        if (wallNum == 3)
                        {
                            mapHeight++;
                        }
                        break;
                    case 2:
                        z--;
                        break;
                    case 3:
                        x--;
                        break;
                    default:
                        z++;
                        if (wallNum == 3)
                        {
                            mapLength++;
                        }
                        break;
                }

                GameObject newWall = Instantiate(
                    WallPrefab,
                    new Vector3(x, 0, z),
                    Quaternion.identity,
                    this.transform);

                // Use the Wall class
                var wall = new Wall(newWall, i);
                wall.GetWall.name = string.Format($"Wall {x},{z}");

                // Use the RNG number and compare with the wall's num
                // If it matches make that wall destructable
                // After that stop assigning
                // For this wall 5, 10 and 15 cannot be used as they are the corners
                // Other walls will have a different set of numbers
                if (genRNG == true && numArray[wallRNG] == wall.GetWallNum && !atCorner && i != 0)
                {
                    wall.SetDestruct = true;
                    genRNG = false;
                    Debug.Log($"Destruct: Wall {wallNum} {wall.GetWall.name}");
                }

                if (wallNum == 3 && genRNG == false && setWin == false)
                {
                    winPos = wall.WallPos;
                    Debug.Log(winPos);
                    setWin = true;
                }

                wallList.Add(wall);

                //Debug.Log(wallList[i]);
            }
            for (int c = 0; c < 3; c++)
            {
                Debug.Log($"Wall {wallNum}: Corner {cornerCoords[0, c]},{cornerCoords[1,c]}");
            }
            wallNum++;
            rngArray[w] = wallRNG;
            int xRNG = Random.Range(2, 5);
            int zRNG = Random.Range(2, 5);
            x -= xRNG;
            z -= zRNG;
            numOfWallTiles += (xRNG + zRNG) * 4;
            if (wallNum == 3)
            {
                floorStartX = x;
                floorStartZ = z;
            }
        }
        
        genComplete = true;
        Debug.Log("The map length is " + mapLength);
        Debug.Log("The map height is " + mapHeight);
    }
}
