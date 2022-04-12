using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playertakedamage : MonoBehaviour
{
    private int playerHealth = 100;
    public ProgressBar bar;
    //private int damage = 0;
    public void Update()
    {
        bar.current = playerHealth;
        if (bar.current <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "sentrybullet")
        {
            playerHealth = playerHealth - 5;
            Debug.Log(playerHealth);
            //damage += 5;
           // if (damage == playerhealth )
                if(playerHealth == 0)
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
            playerHealth = playerHealth - 20;
            //damage += 20;
            Debug.Log(playerHealth);
            if (playerHealth == 0)
            {
                Destroy(gameObject);
               
            }
        }


    }
}
