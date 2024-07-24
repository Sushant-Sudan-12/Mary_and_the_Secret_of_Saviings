using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour, Interactable
{
     public static ShopKeeper Instance { get; private set; }
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject optionBox;
    public ShopManager shopManager;
    


    public void Interact(){
        StartCoroutine(DialogManager.Instance.TypeDialog("Would you like to buy a movie ticket, sir?"));
        dialogBox.SetActive(true);
        optionBox.SetActive(true);
        ShopManager.Instance.ShowDialog(OnYesResponse, OnNoResponse);

    }
    private void OnYesResponse()
    {
        StartCoroutine(DialogManager.Instance.TypeDialog("Here is your ticket for 200"));
    }

    private void OnNoResponse()
    {
        StartCoroutine(DialogManager.Instance.TypeDialog("Thank you so much!"));
    }
    
    
}
