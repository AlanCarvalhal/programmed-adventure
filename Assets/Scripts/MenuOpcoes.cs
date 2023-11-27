using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpcoes : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle limitFPS;
    public Toggle unlimitedFPS;
    public void ControlaVolume(float volume)
    {
        AudioListener.volume = volume;
    }

      public void ControlaSense(float sense)
    {
        FirstPersonController.sensitivity = sense;
    }

    public void TelaCheia(bool telaCheia)
    {
        Screen.fullScreen = telaCheia;
    }

    public void SemLimite(bool semLimite)
    {
        if (semLimite)
        {
            limitFPS.isOn = false;
            Application.targetFrameRate = -1;
        }
    }

    public void Limite60(bool limite60)
    {
        if (limite60)
        {
            unlimitedFPS.isOn = false;
            Application.targetFrameRate = 60;
        }
    }
}
