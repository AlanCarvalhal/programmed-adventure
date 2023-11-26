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
    public GameObject nextCode;
    public GameObject NextPlace;

    private float textSpeed;
    private int index;
    private bool dontRepeat = false;
    private bool aux = true;

    void Update()
    {       
        if (aux && Dialoguebox.activeSelf)
        {
            textDialogue.text = string.Empty;
            StartDialogue();
            aux = false;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F) && Dialoguebox.activeSelf)
        {
            if (textDialogue.text == dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();                
                textDialogue.text = dialogueLines[index];                
            }
        }
        if (changeMission && !dontRepeat && Dialoguebox.activeSelf)
        {
            textMission.text = missionLines[0];            
        }
        if (nextCode != null && !dontRepeat && Dialoguebox.activeSelf) nextCode.GetComponent<Interaction>().enabled = true;
        if (NextPlace != null && !dontRepeat) NextPlace.GetComponent<ChangeScene>().enabled = true;
    }

    void StartDialogue()
    {
        if (!dontRepeat) index = 0;
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
        if (index < dialogueLines.Length - 1)
        {
            index++;
            textDialogue.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dontRepeat = true;
            Dialoguebox.SetActive(false);
            aux = true;
        }
    }
}
