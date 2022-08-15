
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    private static string LastScene;
    private static string CurrentScene;

    void Awake()
    {
        // CurrentScene to what we're currently on
        CurrentScene = SceneManager.GetActiveScene().name;
        // Debug.Log("current scene: " + CurrentScene);
        // Debug.Log("last scene: " + LastScene);
        if (LastScene == null)
        {
            LastScene = CurrentScene;
        }
        else if (LastScene == CurrentScene)
        {
            // case by case basis, i'll figure it out when i get there.
            LastScene = "1 - Title";
        }

    }

    // This function should only be set to the back button on a convening page after given different options,
    // the decision tree page, and the option page.
    public void LastVisitedScene()
    {
        // Update value of LastScene to CurrentScene
        SceneManager.LoadScene(LastScene);
    }
    public void Load_Title()
    {
        SceneManager.LoadScene("1 - Title");
    }
    // When the user enters the decision tree, save the last scene they were just in so they can go back to it when they 
    // press back.
    public void Load_DecisionTree()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Decision Tree");
    }
    public void Load_PrefabExample()
    {
        SceneManager.LoadScene("2 - Prefab Example");
    }
    public void Load_DifferentChoices()
    {
        SceneManager.LoadScene("3 - Different Choices");
    }
    public void Load_Example1()
    {
        SceneManager.LoadScene("4.1 - Example");
    }
    public void Load_Example2()
    {
        SceneManager.LoadScene("4.2 - Example");
    }
    public void Load_Example3()
    {
        SceneManager.LoadScene("4.3 - Example");
    }
    // LastScene should be set to CurrentScene when loading a page that convenes after different options.
    public void Load_ConveningPage()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("5 - Convening Page");
    }
    // When the user enters options, save the last scene they were just in so they can go back to it when they 
    // press back.
    public void Load_Options()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Options");
    }
}
