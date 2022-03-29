using System.Collections;
using UnityEngine;

public class khnumattack : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
      void Update()
    {
        Infront();
        
    }
    bool Infront()
    {
        Vector3 directiontotarget = target.position - target.position;
        float angle = Vector3.Angle(transform.forward, directiontotarget);

        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            return true;
        }
        return false;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
   
}
