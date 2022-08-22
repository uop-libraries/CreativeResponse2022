
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    private static string LastScene;
    private static string CurrentScene;
    private int sceneIndex;
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
        if (LastScene == null)
        {
            LastScene = CurrentScene;
        }
    }

    void Update()
    {
        Debug.Log("Current Scene Index: " + sceneIndex);
    }
    
    //NOTE: DO NOT USE THIS METHOD FOR THE BACK BUTTON ON OPTIONS. ONLY USE THIS FOR ANYTHING BUT OPTIONS
    public void ReturnToPrev() //TODO include more of the branching statements here when necessary
    {
        if (sceneIndex == 2)
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Title");
        }
        else if (sceneIndex == 4 || sceneIndex == 5 || sceneIndex == 6) //brawn jame, grayce, marie
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Japanese Club");
        }
        else if (sceneIndex == 8 || sceneIndex == 9 || sceneIndex == 10) //george, mary, toshio & kei
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Pacific Weekly");
        }
        else if (sceneIndex == 20 || sceneIndex == 21 || sceneIndex == 22) //outpost, nono, personal 
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Rohwer");
        }
        else if (sceneIndex == 23 || sceneIndex == 24 || sceneIndex == 25) //education, commitments, recreational
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Personal Experiences");
        }
        else //everything else
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene(sceneIndex - 1);
        }
    }

    public void GoForward()
    {
        if (sceneIndex == 0) //title
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Context");
        }
        else if (sceneIndex == 4 || sceneIndex == 5 || sceneIndex == 6) //brawn jame, grayce, marie
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Pacific Weekly");
        }
        else if (sceneIndex == 8 || sceneIndex == 9 || sceneIndex == 10) //george, mary, toshio & kei
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("Executive Order 9066");
        }
        else if (sceneIndex == 23 || sceneIndex == 24 || sceneIndex == 25) //education, commitments, recreational
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene("End of WW2");
        }
        else //everything else
        {
            LastScene = CurrentScene;
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }

    // LastScene should be set to CurrentScene when loading a page that convenes after different options.
    public void LastVisitedScene() //NOTE: ONLY USE THIS FOR OPTIONS!!!
    {
        // Update value of LastScene to CurrentScene
        SceneManager.LoadScene(LastScene);
    }
    public void Load_Title()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Title");
    }
    public void Load_Options()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Options");
    }
    // When the user enters the decision tree, save the last scene they were just in so they can go back to it when they 
    // press back.
    //these are explicitly for those that are branching
    public void Load_Grayce()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Grayce Kaneda");
    }

    public void Load_Marie()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Marie Mizutani");
    }

    public void Load_JapaneseClub()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Japanese Club");
    }

    public void Load_PacificWeekly()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Pacific Weekly");
    }

    public void Load_MaryYamashita()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Mary Yamashita");
    }

    public void Load_ToshioKei()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Toshio and Kei Kaneda");
    }

    public void Load_Splash()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Splash Page");
    }

    ////////////////////////////
    /// transition to during ///
    ////////////////////////////
    public void Load_Goodbye()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Goodbye Assembly");
    }

    public void Load_ElJoaquin()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("El Joaquin");
    }
    public void Load_ElJoaquinArticle1()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("El Joaquin Article (1)");
    }
    public void Load_ElJoaquinArticle2()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("El Joaquin Article (2)");
    }
    public void Load_ElJoaquinArticle3()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("El Joaquin Article (3)");
    }

    public void Load_No()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("No No Boys");
    }

    public void Load_PersonalExp()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Personal Experiences");
    }

    public void Load_Commit()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("CommitAndResp");
    }
    
    public void Load_Recreational()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Recreational");
    }
    
    public void Load_Rohwer()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Rohwer");
    }

    public void Load_EndWar()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("End of WW2");
    }

    public void Load_RohwerOutpostArticle1()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Rohwer Outpost Article (1)");
    }
    public void Load_RohwerOutpostArticle2()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Rohwer Outpost Article (2)");
    }
    public void Load_RohwerOutpostArticle3()
    {
        LastScene = CurrentScene;
        SceneManager.LoadScene("Rohwer Outpost Article (3)");
    }
}
