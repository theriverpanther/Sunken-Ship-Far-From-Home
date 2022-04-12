using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField]
    public GameObject menu;
    [SerializeField]
    public GameObject settings;
    [SerializeField]
    public GameObject quitMenu;

    public bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = (paused ? 0 : 1);
        menu.SetActive(paused);
    }

    public void ToggleSettings()
    {
        menu.SetActive(!menu.activeSelf);
        settings.SetActive(!settings.activeSelf);
    }

    public void QuitMenu()
    {
        menu.SetActive(!menu.activeSelf);
        quitMenu.SetActive(!quitMenu.activeSelf);
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuOpened());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator MainMenuOpened()
    {
        SceneManager.UnloadSceneAsync(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        yield return operation.isDone == true;
        //SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
    }
}
