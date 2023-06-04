using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [SerializeField] public TMP_Text playerNameTExt;
    public Player player;

    public void InitilizePlayerName(string _player)
    {
        playerNameTExt.text = _player;
    }

}
