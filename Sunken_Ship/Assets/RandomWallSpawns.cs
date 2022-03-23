using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallSpawns : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Min;
    private Vector3 Max;
    private float[] zAxis = new float[3]; 
    private Vector3 randomPosition;
    public GameObject RandomWall;
    public int numOfWalls = 3;

    void Start()
    {
        SetRanges();
        zAxis[0] = Random.Range(100f, 700f);
        zAxis[1] = Random.Range(100f, 700f);
        while(zAxis[1] - zAxis[0] < 150)
        {
            zAxis[1] = Random.Range(100f, 700f);
        }
        zAxis[2] = Random.Range(100f, 700f);
        while (zAxis[2] - zAxis[1] < 150)
        {
            zAxis[2] = Random.Range(100f, 700f);
        }
        for(int i = 0;i<3;i++)
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
