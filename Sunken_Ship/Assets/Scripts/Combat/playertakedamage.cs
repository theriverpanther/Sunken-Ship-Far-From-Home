using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playertakedamage : MonoBehaviour
{
    private int playerhealth = 100;
    public Slider slider;
    //private int damage = 0;
    public void Update()
    {
        slider.value = playerhealth;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "sentrybullet")
        {
            playerhealth = playerhealth - 5;
            Debug.Log(playerhealth);
            //damage += 5;
           // if (damage == playerhealth )
                if(playerhealth == 0)
            {
                Destroy(gameObject);
               // Debug.Log(playerhealth);
            }
        }
        if (col.gameObject.tag == "torona")
        {
            
                Destroy(gameObject);
           
        }
        if (col.gameObject.tag == "Khnumian")
        {
            playerhealth = playerhealth - 20;
            //damage += 20;
            Debug.Log(playerhealth);
            if (playerhealth == 0)
            {
                Destroy(gameObject);
               
            }
        }


    }
}
