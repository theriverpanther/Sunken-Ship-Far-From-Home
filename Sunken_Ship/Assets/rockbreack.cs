using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockbreack : MonoBehaviour
{
    public GameObject cinemachinetmeline2;
    public GameObject cutsceneship;
    public GameObject cinemachinevirtualcameras;
    public GameObject cinemachinemaincamera;

    public GameObject mainplayer;
    public GameObject Canvas;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "megabullet")
        {
            Debug.Log("We hit the megabullet");
            cutsceneactivate();
            
          
        }

    }

    void cutsceneactivate()
    {
        mainplayer.SetActive(false);
        Canvas.SetActive(false);
        cinemachinetmeline2.SetActive(true);
        cutsceneship.SetActive(true);
        cinemachinevirtualcameras.SetActive(true);
        cinemachinemaincamera.SetActive(true);

     //   cutsceneendtofinishscreen();

    }

    IEnumerator cutsceneendtofinishscreen()
    {
        yield return new WaitForSeconds(13);
        //change scene to finish screen
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
