using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public List<Button> btns = new List<Button>();

    [SerializeField]
    private Sprite bgImage;

    public Sprite[] Cards;

    public List<Sprite> gameCards = new List<Sprite>();
    
    private bool firstMatch, secondMatch;

    private int countMatches;
    private int countCorrectMatches;
    private int Matches;

    private int firstMatchIndex, secondMatchIndex;

    private string firstMatchCard, secondMatchCard;
    
    public GameObject gameWinPanel;
    public GameObject gameLossPanel;
    public TMP_Text GameScore;
    public TMP_Text GameTimer;
    public TMP_Text gameScoreTxt;
    public int GameScoreCount;
    public bool TimerRunning=true;
    public float Timer;

     void Start()
    {
        GetButtons();
        AddListeners();
        AddCards();
        Shuffle(gameCards);
        Matches=gameCards.Count/2;
         Time.timeScale=1;

        }


     private void Awake()
    {
        Cards =Resources.LoadAll<Sprite>("Images/Cards");
    }
     void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardBtn");

        for(int i = 0; i<objects.Length;i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite=bgImage;
        }
    }
      void AddCards()
    {
        int countcard = btns.Count;
        int index=0;

        for(int i = 0; i < countcard; i++)
        {
            if(index == countcard/2)
            {
                index = 0;
            }
            gameCards.Add(Cards[index]);
            index++;
        }
    }
     void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(()=>PickCard());
        }
    }
    public void PickCard()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        
        print("hey"+name);
         if(!firstMatch)
        {
            firstMatch=true;
            firstMatchIndex=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstMatchCard=gameCards[firstMatchIndex].name;
            btns[firstMatchIndex].image.sprite=gameCards[firstMatchIndex];
            
        }
        else if(!secondMatch){
        
            secondMatch=true;
            secondMatchIndex=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondMatchCard=gameCards[secondMatchIndex].name;
            btns[secondMatchIndex].image.sprite=gameCards[secondMatchIndex];
           
            if(firstMatchCard==secondMatchCard)
            {
                print("card match");
                GameScoreCount++;
            }
            else{
                print("card not match");
            }
                        StartCoroutine(checkCardMatch());

                      //  Matches++;
                      }
    }
     IEnumerator checkCardMatch()
        {
            yield return new WaitForSeconds(0.5f);
            if(firstMatchCard==secondMatchCard)
            {
           // btns[firstMatchIndex].interactable=false;
           // btns[secondMatchIndex].interactable=false;
           GameScore.text="SCORES:"+ GameScoreCount;
            GameFinish();
            }
            else
            {
                btns[firstMatchIndex].image.sprite=bgImage;
                btns[secondMatchIndex].image.sprite=bgImage;
            }
             firstMatch=secondMatch=false;

        }
   public void GameFinish()
   {
        

        countCorrectMatches++;
        if(countCorrectMatches == Matches)
        {
            print("game win");
            Time.timeScale=0;
            PlayerPrefs.SetInt("UnlockedLevel",(SceneManager.GetActiveScene().buildIndex));
        print(SceneManager.GetActiveScene().buildIndex);
            gameWinPanel.SetActive(true);
            gameScoreTxt.text=GameScore.text;
            print("took"+countCorrectMatches+ countMatches);
        }
   }
   void Update()
   {
          if(TimerRunning)
          {
          if(Timer>0)
          {
                Timer -= Time.deltaTime;
                int timerInt = (int)Timer;
                GameTimer.text= "TIME:" + timerInt.ToString();
           }
          else
          {
                Timer=0;
                TimerRunning=false;
                gameLossPanel.SetActive(true);
               // gameScoreTxt.text=GameScore.text;

                print ("time up");
          }
          }
          
   }
   public void NextBtn()
   {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

   }
   public void RetryBtn()
   {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

   }
   void Shuffle(List<Sprite> list)

   {
    for (int i = 0; i < list.Count; i++)
    {
        Sprite temp =list[i];
        int randomIndex =Random.Range(i,list.Count);
        list[i]=list[randomIndex];
        list[randomIndex]=temp;
    }
   }

}
