using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }

    public Text dialogText;
    public GameObject dialogBox;
    public GameObject optionBox;
    public Button yesButton;
    public Button noButton;

    private Action onYesAction;
    private Action onNoAction;

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
    }

    public void ShowDialog(Action onYes, Action onNo)
    {
        dialogBox.SetActive(true);
        onYesAction = onYes;
        onNoAction = onNo;
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
}

