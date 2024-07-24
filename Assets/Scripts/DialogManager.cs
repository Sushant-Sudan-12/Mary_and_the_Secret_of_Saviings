using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.MemoryProfiler;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField]int lettersPerSecond;
    int currentLine = 0;
    Dialog dialog;
    bool isTyping;

    public event Action onShowDialog;
    public event Action onHideDialog;
    public static DialogManager Instance { get; private set;}
    private void Awake(){
        Instance = this;
    }

    public IEnumerator ShowDialog(Dialog dialog){
        yield return new WaitForEndOfFrame();
        onShowDialog?.Invoke(); 
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }
    
    public void HandleUpdate(){
        if(Input.GetKeyUp(KeyCode.E)&& !isTyping){
            ++currentLine;
            if(currentLine<dialog.Lines.Count){
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else{
                dialogBox.SetActive(false);
                onHideDialog?.Invoke();

            }
        }

    }

    public IEnumerator TypeDialog(string line){
        isTyping = true;
        dialogText.text = "";
        foreach(var letter in line.ToCharArray()){
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);

        }
        isTyping = false;
    }
}
