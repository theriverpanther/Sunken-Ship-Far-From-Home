using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "MinimapIcon" && other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Outer");
        }
    }
}
