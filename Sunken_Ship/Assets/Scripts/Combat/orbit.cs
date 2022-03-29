using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit : MonoBehaviour
{
    public GameObject target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        orbitaround();   
    }
    void orbitaround()
    {
        transform.RotateAround(target.transform.position, Vector3.right, speed * Time.deltaTime);
    }
}
