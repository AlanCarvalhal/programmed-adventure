using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public TextMeshProUGUI textMission;
    public GameObject missionBox;
    public bool changeMission;
    public GameObject Dialoguebox;    
    public string[] dialogueLines;
    public string[] missionLines;

    private float textSpeed;
    private int index;
    private bool dontRepeat = false;
    private bool aux = true;
 
    void Update()
    {
            if (aux && Dialoguebox.activeSelf)
            {
            missionBox.SetActive(false);
            textDialogue.text = string.Empty;
            StartDialogue();
            aux = false;
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F) && Dialoguebox.activeSelf)
            {
            if(textDialogue.text ==  dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textDialogue.text =  dialogueLines[index];
            }
        }
    }

    void StartDialogue()
    {        
        if (!dontRepeat)index = 0;
        if (dontRepeat) index = dialogueLines.Length - 1;
        StartCoroutine(TypeLine());        
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void NextLine()
    {
        if (index <  dialogueLines.Length - 1)
        {
            index++;
            textDialogue.text = string.Empty;
            StartCoroutine(TypeLine());
        }        
        else
        {            
            if (changeMission && !dontRepeat)
            {
                textMission.text = missionLines[0];
            }            
            dontRepeat = true;
            Dialoguebox.SetActive(false);
            missionBox.SetActive(true);
            aux = true;
        }
    }

 
}
