
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    private static string LastScene;
    private static string CurrentScene;
    // LastScene should be set to CurrentScene when loading a page that convenes after different options.
    void Awake()
    {
        // CurrentScene to what we're currently on
        CurrentScene = SceneManager.GetActiveScene().name;
        //Debug.Log("current scene: " + CurrentScene);
        //Debug.Log("last scene: " + LastScene);
        //Debug.Log("last last scene: " + LastLastScene);
        if (LastScene == null)
        {
            LastScene = CurrentScene;
        }
    }

    // This function should only be set to the back button on a convening page after given different options,
    // the decision tree page, and the option page.
    public void LastVisitedScene()
    {
        // Update value of LastScene to CurrentScene
        SceneManager.LoadScene(LastScene);
    }
    public void Load_Blank()
    {
        SceneManager.LoadScene("Blank");
    }
    public void Load_Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void Load_Options()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Options");
    }
    // When the user enters the decision tree, save the last scene they were just in so they can go back to it when they 
    // press back.
    public void Load_Context()
    {
        SceneManager.LoadScene("Context");
    }
    public void Load_JapaneseClub()
    {
        SceneManager.LoadScene("Japanese Club");
    }
    public void Load_JamesDoi()
    {
        SceneManager.LoadScene("James Doi");
    }
    public void Load_GrayceKaneda()
    {
        SceneManager.LoadScene("Grayce Kaneda");
    }
    public void Load_MarieMizutani()
    {
        SceneManager.LoadScene("Marie Mizutani");
    }
    public void Load_GeorgeAkimoto()
    {
        SceneManager.LoadScene("George Akimoto");
    }
    public void Load_MaryYamashita()
    {
        SceneManager.LoadScene("Mary Yamashita");
    }
    public void Load_ToshioKei()
    {
        SceneManager.LoadScene("Toshio and Kei Kaneda");
    }
    public void Load_ExecOrder()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Executive order 9066");
    }

    public void Load_Splash()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Splash Page");
    }

    public void Load_Assembly()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Stockton Assembly Center");
    }
}
