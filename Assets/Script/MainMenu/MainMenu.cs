using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int GameLevel;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + GameLevel);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void BackToLoadout()
    {
        SceneManager.LoadScene("SelectionMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SelectLevel(int level)
    {
        GameLevel = level;
    }
}
