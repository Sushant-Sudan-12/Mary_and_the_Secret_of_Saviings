using System;
using UnityEngine;
using UnityEngine.UI;

public class TheaterManager : MonoBehaviour
{
    public static TheaterManager Instance { get; private set; }

    public Text dialogText;
    public GameObject dialogBox;
    public GameObject optionBox;
    public GameObject priceBox;
    public Button yesButton;
    public Button noButton;
    public Button first;
    public Button second;
    public Button third;
    public Button fourth;

    private Action onYesAction;
    private Action onNoAction;
    private Action onFirstAction;
    private Action onSecondAction;
    private Action onThirdAction;
    private Action onFourthAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
        first.onClick.AddListener(OnFirstClicked);
        second.onClick.AddListener(OnSecondClicked);
        third.onClick.AddListener(OnThirdClicked);
        fourth.onClick.AddListener(OnFourthClicked);
    }

    public void ShowDialog(Action onYes, Action onNo)
    {
        dialogBox.SetActive(true);
        onYesAction = onYes;
        onNoAction = onNo;
    }
    public void ShowDialog(Action first, Action second, Action third, Action fourth)   
    {
        dialogBox.SetActive(true);
        onFirstAction = first;
        onSecondAction = second;
        onThirdAction = third;
        onFourthAction = fourth;
    }


    private void OnYesButtonClicked()
    {
        onYesAction?.Invoke();
        optionBox.SetActive(false);
    }

    private void OnNoButtonClicked()
    {
        onNoAction?.Invoke();
        optionBox.SetActive(false);
    }
    private void OnFirstClicked()
    {
        onFirstAction?.Invoke();
        
    }
    private void OnSecondClicked()
    {
        onSecondAction?.Invoke();
        
    }
    private void OnThirdClicked()
    {
        onThirdAction?.Invoke();
    
    }
    private void OnFourthClicked()
    {
        onFourthAction?.Invoke();
        
    }
}



