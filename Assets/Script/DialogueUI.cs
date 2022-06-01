using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// * expression order *
// -> idle(0), smile(1), laughs(2), depression(3), rage(4)
namespace DialogueSystem
{
    public class DialogueUI : Dialogue
    {
        public TextMeshProUGUI speecherName;
        public TextMeshProUGUI speecherDialogue;
        public Image charactorA;
        public Image charactorB;

        private void OnEnable()
        {
            SetSkipEffects();
        }

        private void SetSkipEffects()
        {          
            if(isAuto) skipEffects.SetActive(true);
            else skipEffects.SetActive(false);
        }

        private void SetActiveObjects(int i, bool isVisible)
        {
            this.transform.GetChild(i).gameObject.SetActive(isVisible);
        }

        // private void SetAlphaObjects(Speecher speecher, bool isVisible)
        // {
        //     Color color = speecher.image.color;
        //     color.a = isVisible == true ? 1 : 0.2f;
        //     speecher.image.color = color;
        // }
     

        public void ShowDialogueUI(int sceneNumber, 
        Sprite[] charactorAExpression, Sprite[] charactorBExpression, 
        string charactorAName, string charactorBName)
        {
            darkPanel.gameObject.SetActive(true);
            this.gameObject.SetActive(true);
            for(int i = 0; i < transform.childCount; i ++) SetActiveObjects(i, true);
            ReadXLSXFile(sceneNumber);
            StartCoroutine(ReadText(timeDelay, speecherName, speecherDialogue, 
            charactorA, charactorB, charactorAExpression, charactorBExpression,
            charactorAName, charactorBName));
        }

        public void CloseDialogueUI()
        {
            for(int i = 0; i < transform.childCount; i ++) SetActiveObjects(i, false);
            this.gameObject.SetActive(false);
            darkPanel.gameObject.SetActive(false);
        }     
    }
}
