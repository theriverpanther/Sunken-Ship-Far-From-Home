using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    [SerializeField] GameObject[] shipLights;
    MinimapManager minimap;

    // Start is called before the first frame update
    void Start()
    {
        minimap = FindObjectOfType<MinimapManager>();
        minimap.AddTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //shipLights = other.gameObject.GetComponentsInChildren<Light>();
            for (int i = 0; i < shipLights.Length; i++)
            {
                shipLights[i].SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
