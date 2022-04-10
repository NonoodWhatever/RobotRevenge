using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewESC : MonoBehaviour
{

    private bool EscPress = false;
    [SerializeField] GameObject KeepitDown;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && EscPress == false)
        {
            EscPress = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && EscPress == true)
        {
            EscPress = false;
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
        SceneManager.LoadScene("SelectionMenu");
    }
  public  void InstantOut()
    {
        Application.Quit();
    }
}
