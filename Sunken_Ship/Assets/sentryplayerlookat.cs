using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryplayerlookat : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationalDamp = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
     //  turn();
    }
    void turn()
    {
        Vector3 pos = target.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        Debug.DrawLine(transform.position, target.position, Color.green);
    }
    // Update is called once per frame
    void Update()
    {
        turn();
         //Debug.DrawLine(transform.position, target.position, Color.green);
    }
}
