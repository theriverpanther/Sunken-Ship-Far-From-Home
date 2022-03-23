using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallSpawns : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Min;
    private Vector3 Max;
    private float[] zAxis = new float[16]; 
    private Vector3 randomPosition;
    public GameObject RandomWall;
    void Start()
    {
     
        zAxis[0] = Random.Range(100f, 200f);
        zAxis[1] = Random.Range(zAxis[0]+100f, 350f);
        zAxis[2] = Random.Range(zAxis[1]+100f, 450f);
        zAxis[3] = Random.Range(zAxis[2]+100f, 700f);
        zAxis[4] = Random.Range(600f, 700f);
        zAxis[5] = Random.Range(450f, zAxis[4] - 100f);
        zAxis[6] = Random.Range(200f, zAxis[5] - 100f);
        zAxis[7] = Random.Range(100f, zAxis[6] -50);
        zAxis[8] = Random.Range(100f, 200f);
        zAxis[9] = Random.Range(zAxis[8] + 100f, 350f);
        zAxis[10] = Random.Range(zAxis[9] + 100f, 550f);
        zAxis[11] = Random.Range(zAxis[10] + 100f, 700f);
        zAxis[12] = Random.Range(600f, 700f);
        zAxis[13] = Random.Range(450f, zAxis[12] - 100f);
        zAxis[14] = Random.Range(200f, zAxis[13] - 100f);
        zAxis[15] = Random.Range(100f, zAxis[14] - 50);
        for (int i = 0;i<4;i++)
        {
            InstantiateWallsArea1(zAxis[i]);
        }
        for (int i = 4; i < 8; i++)
        {
            InstantiateWallsArea2(zAxis[i]);
        }
        for (int i = 8; i < 12; i++)
        {
            InstantiateWallsArea3(zAxis[i]);
        }
        for (int i = 12; i < 16; i++)
        {
            InstantiateWallsArea4(zAxis[i]);
        }
    }
    private void InstantiateWallsArea1(float zCord)
    {
            
            randomPosition = new Vector3(116f, 49f, zCord);
            GameObject Example = Instantiate(RandomWall, randomPosition, Quaternion.identity);
           
    }
    private void InstantiateWallsArea2(float zCord)
    {

        randomPosition = new Vector3(312f, 49f, zCord);
        GameObject Example = Instantiate(RandomWall, randomPosition, Quaternion.identity);
   
    }
    private void InstantiateWallsArea3(float zCord)
    {

        randomPosition = new Vector3(513f, 49f, zCord);
        GameObject Example = Instantiate(RandomWall, randomPosition, Quaternion.identity);
      
    }
    private void InstantiateWallsArea4(float zCord)
    {

        randomPosition = new Vector3(725f, 49f, zCord);
        GameObject Example = Instantiate(RandomWall, randomPosition, Quaternion.identity);
       
    }
}
