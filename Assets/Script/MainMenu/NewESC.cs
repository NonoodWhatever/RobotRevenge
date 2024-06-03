using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewESC : MonoBehaviour
{

    private bool EscPress = false;
    [SerializeField] GameObject KeepitDown;
    public GameObject PlayerGun;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && EscPress == false)
        {
            EscPress = true;
            PlayerGun.SetActive(false);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && EscPress == true)
        {
            EscPress = false;
            PlayerGun.SetActive(true);
            Time.timeScale = 1f;
        }
        if(EscPress == false)
        {
            KeepitDown.SetActive(false);
        }
        if(EscPress == true)
        {
            KeepitDown.SetActive(true);
        }
    }
   public void BackToSelect()
    {
        SceneManager.LoadScene("SelectionMenu-New");
    }
  public  void InstantOut()
    {
        Application.Quit();
    }
}
