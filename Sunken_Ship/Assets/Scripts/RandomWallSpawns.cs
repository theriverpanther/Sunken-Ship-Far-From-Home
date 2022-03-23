using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallSpawns : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Min;
    private Vector3 Max;
    private float[] zAxis = new float[4]; 
    private Vector3 randomPosition;
    public GameObject RandomWall;
    public int numOfWalls = 3;

    void Start()
    {
        SetRanges();
        zAxis[0] = Random.Range(100f, 200f);
        zAxis[1] = Random.Range(zAxis[0], 300f);
        for (int i = 0;i<3;i++)
        {
            if (zAxis[1] - zAxis[0] >= 150)
            {
                break;
            }
            else
            {
                zAxis[1] = Random.Range(zAxis[0], 300f);
            }
        }
        zAxis[2] = Random.Range(zAxis[1], 500f);
        for (int j = 0; j < 3; j++)
        {
            if (zAxis[2] - zAxis[1] >= 2000)
            {
                break;
            }
            else
            {
                zAxis[2] = Random.Range(zAxis[1], 500f);
            }
        }
        zAxis[3] = Random.Range(zAxis[2], 700f);
        for (int k = 0; k < 3; k++)
        {
            if (zAxis[3] - zAxis[2] >= 150)
            {
                break;
            }
            else
            {
                zAxis[3] = Random.Range(zAxis[2], 700f);
            }
        }
        for (int i = 0;i<4;i++)
        {
            InstantiateWalls(zAxis[i]);
        }
    }


    private void SetRanges()
    {
        Min = new Vector3(116f, 49f, 100f);
        Max = new Vector3(116f, 49f, 700f);
    }
    private void InstantiateWalls(float zCord)
    {
            
            randomPosition = new Vector3(116f, 49f, zCord);
            GameObject Example = Instantiate(RandomWall, randomPosition, Quaternion.identity);
            numOfWalls++;
    }
}
