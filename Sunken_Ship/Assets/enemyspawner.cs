using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Min;
    private Vector3 Max;
    private float xAxis;
    private float yAxis;
    private float zAxis; //If you need this, use it
    private Vector3 randomPosition;
    public bool canInstantiate = true;
    public GameObject trap;
    public int numActive;
    public int maxActive;
    void Start()
    {
        SetRanges();
    }
    private void Update()
    {
        InstantiateTraps();
        if (numActive == maxActive)
        {
            canInstantiate = false;
        }
    }

    private void SetRanges()
    {
        Min = new Vector3(0, 45f, 0);
        Max = new Vector3(100, 45f, 150);
    }
    private void InstantiateTraps()
    {
        if (canInstantiate)
        {
            xAxis = UnityEngine.Random.Range(Min.x, Max.x);
            //  yAxis = UnityEngine.Random.Range(Min.y, Max.y);
            zAxis = UnityEngine.Random.Range(Min.z, Max.z);
            randomPosition = new Vector3(xAxis, 45f, zAxis);
            GameObject Example = Instantiate(trap, randomPosition, Quaternion.identity);
            Example.gameObject.tag = "Clone";

            numActive++;
        }
    }
}