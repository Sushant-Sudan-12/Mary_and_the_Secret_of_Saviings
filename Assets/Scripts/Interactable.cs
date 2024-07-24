using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Interactable :MonoBehaviour
{
    [SerializeField] Dialog dialog;
    public void Interact(){
       StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
