using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomPieceDestroy : MonoBehaviour
{
   // public GameObject WallPiece;

   [SerializeField] public int ChildToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        ChildToDestroy = Random.Range(0,10);
        ChildToDestroy++;
        string sChildToDestory;
        sChildToDestory = ChildToDestroy.ToString();
        Transform[] allRocks = GetComponentsInChildren<Transform>();
        foreach (Transform child in allRocks)
        {
            if(child.gameObject.tag == sChildToDestory)
            {
                Destroy(child.gameObject);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
