using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;

public class PlayerNameBoard : MonoBehaviourPunCallbacks
{
    public GameObject PlayerNamePrefabs;
    public Transform playerNameContainer;

    private void Start()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        // Instantiate leaderboard entries for each player in the room
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GameObject leaderboardEntry = Instantiate(PlayerNamePrefabs, playerNameContainer);
            PlayerName PlayerName_ = leaderboardEntry.GetComponent<PlayerName>();
            PlayerName_.InitilizePlayerName(player.NickName);      
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        // A new player joined the room, instantiate a leaderboard entry for them
        GameObject leaderboardEntry = Instantiate(PlayerNamePrefabs, playerNameContainer);
        PlayerName playerName_ = leaderboardEntry.GetComponent<PlayerName>();
        playerName_.InitilizePlayerName(newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // A player left the room, remove their leaderboard entry
        foreach (Transform child in playerNameContainer)
        {
            PlayerName playerName = child.GetComponent<PlayerName>();
            if (playerName != null && playerName.playerNameTExt.text == otherPlayer.NickName)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

}
