using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = player.gameObject.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = player.gameObject.transform.position; 
    }
}
