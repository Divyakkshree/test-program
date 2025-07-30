using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject levels;
   
    private void Awake()
    {
            buttonToArray();

    //PlayerPrefs.DeleteAll();
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
    void buttonToArray()
    {
        int childCount = levels.transform.childCount;
        levelButtons= new Button[childCount];
        for(int i=0;i<childCount;i++)
        {
            levelButtons[i]=levels.transform.GetChild(i).gameObject.GetComponent<Button>();
        }
    }
}
