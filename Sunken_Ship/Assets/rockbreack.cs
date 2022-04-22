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

            //   cutsceneendtofinishscreen();

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
        loadNextScene();




    }
    void loadNextScene()
    {
        Debug.Log("this is before yeild line in load scene");
        StartCoroutine(cutsceneendtofinishscreen());
        //cutsceneendtofinishscreen();
        Debug.Log("this is after the call to enumerator");
    }

    IEnumerator cutsceneendtofinishscreen()
    {
        Debug.Log("this is the enumerator");
        yield return new WaitForSeconds(10);
        Debug.Log("this is after the wait of 5 seconds");
        SceneManager.LoadScene(4);
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
