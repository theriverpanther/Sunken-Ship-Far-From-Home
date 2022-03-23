using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int randomZ = Random.Range(-40, 40);
        Vector3 originalPoition = this.gameObject.transform.position;
        originalPoition.z = originalPoition.z + randomZ; 
        if(this.gameObject.transform.rotation.y == 0)
        {
            this.transform.position = originalPoition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
