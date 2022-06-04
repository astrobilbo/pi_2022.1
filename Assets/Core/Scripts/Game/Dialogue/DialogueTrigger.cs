using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project1.Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField]string action;
        [SerializeField] UnityEvent onTrigger;
        public void Trigger (string actionToTrigger)
        {
                if (actionToTrigger==action)
                {
                    onTrigger.Invoke();
                }
        }
    }
}