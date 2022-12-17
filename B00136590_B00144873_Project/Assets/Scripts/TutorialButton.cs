using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public int sceneIndex;

    void Start()
    {
    }

    void Update()
    {
    }

    public void LoadGame()
    {
        Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(sceneIndex);
    }
}
