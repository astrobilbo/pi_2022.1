using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Project1.Dialogue
{

    public class Conversant : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;
        [SerializeField] string playerName;
        [SerializeField] string activeCharacterName;
        [SerializeField] Dialogue CurrentDialogue;
        DialogueNode currentNode = null;
        AIConversant currentConversant = null;
        bool isChoosing = false;

        public event Action onConversationUpdated;

        public void StartDialogue(AIConversant newConversant, Dialogue newDialogue)
        {
            currentConversant = newConversant;
            CurrentDialogue = newDialogue;
            currentNode = CurrentDialogue.GetRootNode();
            TriggerEnterAction();
            onConversationUpdated();
            if (gameManager != null)
            {
                gameManager.playing = false;
            }

        }
        public void Quit()
        {
            CurrentDialogue = null;
            TriggerExitAction();
            currentNode = null;
            isChoosing = false;
            currentConversant = null;
            playerName = null;
            onConversationUpdated();
            if (gameManager != null)
            {
                gameManager.playing = true;
            }

        }
        public bool IsActive()
        {
            return CurrentDialogue != null;
        }
        public bool IsChoosing()
        {
            return isChoosing;
        }
        public string GetChatText()
        {
            if (currentNode == null)
            {
                return "";
            }
            return currentNode.GetText();
        }

        public string GetCurrentSpeaker()
        {
            if (CurrentDialogue == null)
            {
                return "";
            }
            activeCharacterName = CurrentDialogue.Characters[currentNode.GetCharacterSpeaking()];
            if (currentNode.GetCharacterSpeaking() == 0 || isChoosing)
            {
                if (playerName == null || playerName == "")
                {
                    playerName = activeCharacterName;
                }
                activeCharacterName = playerName;
            }
            return activeCharacterName;
        }
        public IEnumerable<DialogueNode> GetChoices()
        {
            return CurrentDialogue.GetPlayerChildren(currentNode);
        }
        public void SelectChoice(DialogueNode chosenNode)
        {
            currentNode = chosenNode;
            TriggerEnterAction();
            isChoosing = false;
            Next();
        }
        public void Next()
        {
            int numPlayerResponses = CurrentDialogue.GetPlayerChildren(currentNode).Count();
            GetCurrentSpeaker();
            if (numPlayerResponses > 0)
            {
                isChoosing = true;
                TriggerExitAction();
                onConversationUpdated();
                return;
            }
            DialogueNode[] children = CurrentDialogue.GetAIChildren(currentNode).ToArray();
            if (children.Length > 0)
            {
                TriggerExitAction();
                currentNode = children[UnityEngine.Random.Range(0, children.Length)];
                onConversationUpdated();
            }
        }

        public bool HasNext()
        {
            return CurrentDialogue.GetAllChildren(currentNode).Count() > 0;
        }

        private void TriggerEnterAction()
        {
            if (currentNode != null && currentNode.GetOnEnterAction() != "")
            {
                TriggerAction(currentNode.GetOnEnterAction());
            }
        }
        private void TriggerExitAction()
        {
            if (currentNode != null && currentNode.GetOnExitAction() != "")
            {
                TriggerAction(currentNode.GetOnExitAction());
            }
        }
        private void TriggerAction(string action)
        {
            if (action == "") return;
            foreach (DialogueTrigger trigger in currentConversant.GetComponents<DialogueTrigger>())
            {
                trigger.Trigger(action);
            }
        }
    }
}