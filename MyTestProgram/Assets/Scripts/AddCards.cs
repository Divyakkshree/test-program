using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCards : MonoBehaviour
{
    [SerializeField]
    private Transform CardPanel;

    public GameObject Card;
    public int totalCards;


    private void Awake()
    {
        for(int i=0; i<totalCards; i++)
        {
            GameObject _card = Instantiate(Card);
            _card.name=""+i;
            _card.transform.SetParent(CardPanel,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
