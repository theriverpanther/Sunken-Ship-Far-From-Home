using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MinimapIcon" && other.gameObject.tag != "Player")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("Inner");
        }
    }
}
