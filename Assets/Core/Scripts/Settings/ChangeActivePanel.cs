using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeActivePanel : MonoBehaviour
{
    [SerializeField]Button desactiveButton;
    [SerializeField]CanvasGroup activeButtonPanel;
  
   public void DesactiveButton(Button newButton){
       desactiveButton.interactable=true;
       newButton.interactable=false;
       desactiveButton=newButton;
   }
   public void ActivePanel(CanvasGroup nextPanel){
       activeButtonPanel.alpha=0;
       activeButtonPanel.blocksRaycasts=false;
       nextPanel.alpha=1;
       nextPanel.blocksRaycasts=true;
       activeButtonPanel=nextPanel;
   }
}
