using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{


    public List<Button> btns = new List<Button>();
    [SerializeField]
    private Sprite bgImage;

     void Start()
    {
        GetButtons();
        AddListeners();
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
