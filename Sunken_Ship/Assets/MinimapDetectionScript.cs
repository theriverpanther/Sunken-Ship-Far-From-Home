using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapDetectionScript : MonoBehaviour
{
    public GameObject selfReference;
    public MinimapManager minimap;
    // Start is called before the first frame update
    void Start()
    {
        minimap = GameObject.Find("MinimapManager").GetComponent<MinimapManager>();
        minimap.AddEnemy(selfReference);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
