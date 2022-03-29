using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapDetectionScript : MonoBehaviour
{
    public GameObject selfReference;
    // Start is called before the first frame update
    void Start()
    {
        MinimapManager minimapManager = new MinimapManager();
        minimapManager.AddEnemy(selfReference);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
