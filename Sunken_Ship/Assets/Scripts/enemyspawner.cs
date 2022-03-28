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

    [SerializeField]
    private GameObject minimapManager;

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
        Min = new Vector3(16.6f, 45f, 21.3f);
        Max = new Vector3(81.8f, 45f, 193.1f);
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
            minimapManager.GetComponent<MinimapManager>().AddEnemy(Example);
            Example.gameObject.tag = "Clone";

            numActive++;
        }
    }
}