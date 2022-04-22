using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playertakedamage : MonoBehaviour
{
    private int playerHealth = 300;
    private int percentageHealth;
    public TextMeshProUGUI HPtext;
    private string Hpstring;
  //  public ProgressBar bar;
    //private int damage = 0;
    public void Update()
    {
        percentageHealth = (playerHealth * 100) / 300;
        
        HPtext.text = "Hull Integrity " + percentageHealth.ToString() + "%";
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "sentrybullet")
        {
            playerHealth = playerHealth - 5;
            Debug.Log(playerHealth);
            //damage += 5;
           // if (damage == playerhealth )
             if(playerHealth <= 0)
             {
                Destroy(gameObject);
                SceneManager.LoadScene(5);
               // Debug.Log(playerhealth);
             }
        }
        if (col.gameObject.tag == "torona")
        {
            
                Destroy(gameObject);
                SceneManager.LoadScene(5);
           
        }
        if (col.gameObject.tag == "Khnumian")
        {
            playerHealth = playerHealth - 20;
            //damage += 20;
            Debug.Log(playerHealth);
            if (playerHealth <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(5);
               
            }
        }


    }
}
