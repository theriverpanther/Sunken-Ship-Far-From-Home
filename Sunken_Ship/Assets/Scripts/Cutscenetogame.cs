using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenetogame : MonoBehaviour
{
    public GameObject player;
    public GameObject cutsceneplayermodel;
    public GameObject cinemachinecamera;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        canvas.SetActive(false);
        yield return new WaitForSeconds(25);
        cutsceneplayermodel.SetActive(false);
        cinemachinecamera.SetActive(false);
        canvas.SetActive(true);
        player.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
