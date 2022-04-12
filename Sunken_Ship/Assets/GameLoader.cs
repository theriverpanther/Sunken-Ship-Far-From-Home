using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameLoader : MonoBehaviour
{
    public static GameLoader instance;
    public GameObject loadingScreen;
    public ProgressBar bar;
    public TMP_Text text;

    public List<string> loadingMessages;
    public int loadingIndex = 0;

    private bool loading;

    void Awake()
    {
        instance = this;
        StartCoroutine(LoadStart());
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame()
    {
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync(1));
        scenesLoading.Add(SceneManager.LoadSceneAsync(2));

        StartCoroutine(GetSceneLoadProgress());
    }

    IEnumerator LoadStart()
    {
        AsyncOperation loadedLevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        yield return loadedLevel.isDone;
        // Find the start button and assign it's click to load in the game
        GameObject startButton = GameObject.Find("Canvas/StartButton");
        startButton.GetComponent<Button>().onClick.AddListener(LoadGame);
    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        loading = true;
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while(!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                totalSceneProgress = totalSceneProgress / scenesLoading.Count * 100f;

                bar.current = Mathf.RoundToInt(totalSceneProgress);
                yield return null;
            }
        }
        loading = false;
        loadingScreen.SetActive(false);
    }

    public IEnumerator ChangeText()
    {
        if(loading)
        {
            text.text = loadingMessages[loadingIndex];
            yield return new WaitForSeconds(0.5f);
            loadingIndex++;
            StartCoroutine(ChangeText());
        }
    }
}
