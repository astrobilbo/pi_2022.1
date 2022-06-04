using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project1.Dialogue;
using TMPro;
using UnityEngine.UI;

namespace Project1.UI.Dialogue
{
    public class DialogueUI : MonoBehaviour
    {
        Conversant conversant;
        [SerializeField] TextMeshProUGUI currentSpeaker;
        [SerializeField] TextMeshProUGUI aiText;
        [SerializeField] Button nextButton;
        [SerializeField] Transform choiceRoot;
        [SerializeField] GameObject choicePrefab;
        [SerializeField] GameObject AIResponse;
        [SerializeField] Button quitButton;
        [SerializeField] CanvasGroup dialogueUI;
         [SerializeField] WindowsVoice dialogueVoice;
        void Start()
        {
            conversant = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Conversant>();
            conversant.onConversationUpdated += UpdateUI;
            nextButton.onClick.AddListener(() => conversant.Next());
            quitButton.onClick.AddListener(() => conversant.Quit());
            UpdateUI();
        }


        void UpdateUI()
        {
            if (conversant.IsActive())
            {
                dialogueUI.alpha = 1;
                dialogueUI.blocksRaycasts = true;
            }
            else
            {
                dialogueUI.alpha = 0;
                dialogueUI.blocksRaycasts = false;
            }
            if (!conversant.IsActive())
            {
                return;
            }
            AIResponse.SetActive(!conversant.IsChoosing());
            choiceRoot.gameObject.SetActive(conversant.IsChoosing());
            currentSpeaker.text = conversant.GetCurrentSpeaker()+":";
            dialogueVoice.speak(currentSpeaker.text );

            if (conversant.IsChoosing())
            {
                BuildChoiceList();
            }
            else
            {
                aiText.text = conversant.GetChatText();
                dialogueVoice.speak(aiText.text);
                nextButton.gameObject.SetActive(conversant.HasNext());
                quitButton.gameObject.SetActive(!conversant.HasNext());
            }

        }
        private void BuildChoiceList()
        {
            choiceRoot.DetachChildren();
            foreach (DialogueNode choice in conversant.GetChoices())
            {
                GameObject choiceInstance = Instantiate(choicePrefab, choiceRoot);
                var textcomp = choiceInstance.GetComponentInChildren<TextMeshProUGUI>();
                textcomp.text = choice.GetText();
                Button button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    conversant.SelectChoice(choice);
                    UpdateUI();
                });
            }
        }
    }
}