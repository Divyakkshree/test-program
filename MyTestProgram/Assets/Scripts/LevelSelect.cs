using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;
   
    private void Awake()
    {
    // PlayerPrefs.DeleteAll();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel",1);
        
        for(int i=0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for(int i=0; i < unlockedLevel; i++)
        {
            levelButtons[i].interactable = true;
        }

    }
    public void OpenLevel(int levelId)
    {
        string levelName="Scene"+ levelId;
        SceneManager.LoadScene(levelName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
