using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MenuOpcoes : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void ControlaVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);      
    }

      public void ControlaSense(float sense)
    {
        //FirstPersonController.mouseSensitivity = sense;
        Debug.Log(sense);
    }

    public void TelaCheia(bool telaCheia)
    {
        Screen.fullScreen = telaCheia;
    }

    public void SemLimite(bool semLimite)
    {
        if (semLimite)
        {
            Application.targetFrameRate = -1;
        }
    }

    public void Limite60(bool limite60)
    {
        if (limite60)
        {
            Application.targetFrameRate = 60;
        }
    }
}
