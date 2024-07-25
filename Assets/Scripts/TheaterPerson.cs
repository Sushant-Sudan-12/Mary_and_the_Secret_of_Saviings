using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheaterKeeper : MonoBehaviour, Interactable
{
    public static TheaterKeeper Instance { get; private set; }
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject optionBox;
    [SerializeField] GameObject priceBox;
    public TheaterKeeper theaterManager;
    private int i =0;
    


    public void Interact(){
        i = 0;
        StartCoroutine(DialogManager.Instance.TypeDialog("Would you like to buy anything, sir?"));
        dialogBox.SetActive(true);
        optionBox.SetActive(true);
        TheaterManager.Instance.ShowDialog(OnYesResponse, OnNoResponse);

    }

    private void OnNoResponse()
    {
        StartCoroutine(DialogManager.Instance.TypeDialog("Then stop wasting my time"));
    }

    private void OnYesResponse()
    {
        StartCoroutine(DialogManager.Instance.TypeDialog("Flowers will cost 200 each"));
        priceBox.SetActive(true);
        TheaterManager.Instance.ShowDialog(onFirst,onSecond,onThird,onFourth);

    }
    private void onFirst(){
        if(i > Random.Range(2, 5) ){
            StartCoroutine(DialogManager.Instance.TypeDialog("I'm in not in the mood for this, come another time"));
            priceBox.SetActive(false);
        }else{
            StartCoroutine(DialogManager.Instance.TypeDialog("Are u kidding me"));
        }
            
        i++;
    }
    private void onSecond(){
        if(i > Random.Range(2, 5)){
            StartCoroutine(DialogManager.Instance.TypeDialog("I'm in not in the mood for this, come another time"));
            priceBox.SetActive(false);
        }
        else{
        
            StartCoroutine(DialogManager.Instance.TypeDialog("I have a family to feed"));
        }
        i++;
    }
    private void onThird(){
        if(i > Random.Range(2, 5)){
            StartCoroutine(DialogManager.Instance.TypeDialog("I'm in not in the mood for this, come another time"));
            priceBox.SetActive(false);
        }else{
            StartCoroutine(DialogManager.Instance.TypeDialog("A little more and its a deal"));
        }
        i++;
    }
    private void onFourth(){
        StartCoroutine(DialogManager.Instance.TypeDialog("Deal hope your girlfriend likes them come again!!"));
        priceBox.SetActive(false);
        i++;
    }
    
}


