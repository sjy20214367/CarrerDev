using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class Dialogue : MonoBehaviour
    {
        public DialogueDataBase dialogueDataBase;
        public Image darkPanel;
        public GameObject outputDoneArrow;        
        public GameObject skip;
        public GameObject skipEffects;
        public CanvasGroup uiGroup;
        protected List<string> dialogueTextList = new List<string>();
        protected List<string> dialogueNameList = new List<string>();
        protected List<int> dialogueExpressionIdxList = new List<int>();
        protected string speecherAName;
        protected string speecherBName;

        public float timeDelay = 0.1f;
        public bool isAuto = true;
        public bool isHided;
        private float autoTimeDelay = 3.0f;

        protected void ReadXLSXFile(int sceneNumber)
        {
            // string output = "";
            dialogueDataBase.Chapter1.ForEach(entity => 
                {
                    if(entity.SceneNumber != sceneNumber) return;
                    dialogueTextList.Add(entity.Text);
                    dialogueExpressionIdxList.Add(SetCharactorImageIdx(entity.Expressions));
                    dialogueNameList.Add(entity.Name);
                }
            );
        }

        private int SetCharactorImageIdx(string expression)
        {
            switch(expression)
            {
                default:
                case "idle":
                    return 0;
                case "smile":
                    return 1;
                case "laughs":
                    return 2;
                case "depression":
                    return 3;
                case "rage":
                    return 4;
            }
        }   

        protected IEnumerator ReadText
        (float timeDelay, TextMeshProUGUI currentSpeecherName, TextMeshProUGUI speecherDialogue, 
        Image speecherA, Image speecherB, Sprite[] speecherAExpression, Sprite[] speecherBExpression, 
        string speecherAName, string speecherBName)
        {
            speecherDialogue.text = "";
            speecherA.sprite = speecherAExpression[0];
            speecherB.sprite = speecherBExpression[0];
            for(int i = 0; i < dialogueTextList.Count; i++)
            {
                int idx = dialogueExpressionIdxList[i];
                if(dialogueNameList[i] == speecherAName)
                {
                    currentSpeecherName.text = speecherAName;
                    speecherA.sprite = speecherAExpression[idx];
                    speecherA.color = new Color(1f,1f,1f,1f); 
                    speecherB.color = new Color(1f,1f,1f,0.3f);
                }
                else
                {
                    currentSpeecherName.text = speecherBName;                    
                    speecherB.sprite = speecherBExpression[idx];
                    speecherB.color = new Color(1f,1f,1f,1f);                     
                    speecherA.color = new Color(1f,1f,1f,0.3f);                    
                }
                for(int j = 0; j < dialogueTextList[i].Length; j++)
                {
                    yield return new WaitUntil(() => !isHided);
                    speecherDialogue.text += dialogueTextList[i][j];
                    yield return new WaitForSeconds(timeDelay);
                }
                outputDoneArrow.SetActive(true);
                if(isAuto) yield return new WaitForSeconds(autoTimeDelay);
                else yield return new WaitUntil(() => GameManager.isTouchedScreen || isAuto);
                outputDoneArrow.SetActive(false);
                speecherDialogue.text = "";
            }
            dialogueTextList.Clear();
            dialogueExpressionIdxList.Clear();
            dialogueNameList.Clear();
        }


        public void SkipOption()
        {
            if(darkPanel.gameObject.activeSelf) skip.SetActive(true);
        }

        public void SkipOption_No()
        {
            skip.SetActive(false);            
        }

        public void AutoOption()
        {
            isAuto = !isAuto;
            if(isAuto) skipEffects.SetActive(true);
            else skipEffects.SetActive(false);
        }
        public void HideOption_On()
        {
            isHided = true;
            uiGroup.blocksRaycasts = true;
            uiGroup.alpha = 0;
        }

        public void HideOption_Off()
        {
            isHided = false;
            uiGroup.blocksRaycasts = false;
            uiGroup.alpha = 1;
        }

        // public int GetDialogueCount()
        // {
        //     return dialogueTextList.Count;
        // }
    }
}
