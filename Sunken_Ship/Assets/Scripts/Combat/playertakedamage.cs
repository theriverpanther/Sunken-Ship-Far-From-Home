using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playertakedamage : MonoBehaviour
{
    private int playerhealth = 100;
    public Slider slider;
    //private int damage = 0;
    public void Update()
    {
        slider.value = playerhealth;
        if (slider.value <= 0)
        {
            SceneManager.LoadScene(2);
        }

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
                SceneManager.LoadScene(2);
               // Debug.Log(playerhealth);
             }
        }
        if (col.gameObject.tag == "torona")
        {
            
                Destroy(gameObject);
                SceneManager.LoadScene(2);
           
        }
        if (col.gameObject.tag == "Khnumian")
        {
            playerhealth = playerhealth - 20;
            //damage += 20;
            Debug.Log(playerhealth);
            if (playerhealth == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(2);
               
            }
        }


    }
}
