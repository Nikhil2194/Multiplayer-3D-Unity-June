 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;
using UnityEngine.UI;
using Photon.Voice.Unity;
using Photon.Realtime;

public class UIScript : MonoBehaviour
{
    public Recorder recorder;
    public Toggle transmitVoicetoggle;
    public GameObject PlayerNameTextPrefab;


    private void Start()
    {
        transmitVoicetoggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isMuted)
    {
        if (recorder != null)
        {
            recorder.TransmitEnabled = !isMuted;
        }
    }

}
