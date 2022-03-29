using System.Collections;
using UnityEngine;

public class khnumianmovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementspeed = 10f;
    [SerializeField] float rotationalDamp = 0.5f;
    [SerializeField] float detectiondistance = 20f;
    [SerializeField] float raycastoffset = 2.5f;
    public int maxRange = 100;
    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, target.transform.position) < maxRange))
        {
            // transform.LookAt(target);
            pathfinding();
            // Turn();
            Move();
        }
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp* Time.deltaTime);

    }

  void Move()
    {
       
            transform.position += transform.forward * movementspeed * Time.deltaTime;
        
       
    }

    void pathfinding()
    {

        RaycastHit hit;
        Vector3 raycastoffset_temp = Vector3.zero;

        Vector3 left = transform.position - transform.right * raycastoffset;
        Vector3 right  = transform.position + transform.right * raycastoffset;
        Vector3 up = transform.position + transform.up * raycastoffset;
        Vector3 down = transform.position - transform.up * raycastoffset;

        if (Physics.Raycast(left, transform.forward, out hit, detectiondistance))
            raycastoffset_temp += Vector3.right;
        else if (Physics.Raycast(left, transform.forward, out hit, detectiondistance))
            raycastoffset_temp -= Vector3.right;

        if (Physics.Raycast(up, transform.forward, out hit, detectiondistance))
            raycastoffset_temp -= Vector3.up;
        else if (Physics.Raycast(down, transform.forward, out hit, detectiondistance))
            raycastoffset_temp += Vector3.up;

        if (raycastoffset_temp != Vector3.zero)
            transform.Rotate(raycastoffset_temp * 5f * Time.deltaTime);
        else
            Turn();
        

    }
}
