using UnityEngine;
using Photon.Pun;
using TMPro;
using System.Collections.Generic;
using Photon.Realtime;
using System;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject artistPrefab, teacherPrefab;
    public GameObject characterSelection;

    // public GameObject[] playerPrefab1;
    // public Transform[] spawnPoints;
    //public TMP_Text pingRateText;

    void Start()
    {
        // int randomIndex = Random.Range(0, spawnPoints.Length);
        //  int randomIndexPlayerPref = Random.Range(0, playerPrefab1.Length);
        // pingRateText.text = "Network Ping : " + PhotonNetwork.GetPing();
        if (PhotonNetwork.IsConnected )
        {
            characterSelection.SetActive(true);
            // Create the player object across the network
            // PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, Quaternion.identity);
            // PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[randomIndex].position, Quaternion.identity);
           /* GameObject obj = PhotonNetwork.Instantiate(artistPrefab.name, new Vector3(0, 0.18f, 0.08f), Quaternion.identity);
            obj.transform.SetParent(this.transform);*/

        }
    }

    public void Teacher()
    {
        characterSelection.SetActive(false);
        GameObject obj = PhotonNetwork.Instantiate(teacherPrefab.name, new Vector3(0, 0.18f, 0.08f), Quaternion.identity);
        obj.transform.SetParent(this.transform);
    }

    public void Artist()
    {
        characterSelection.SetActive(false);
        GameObject obj = PhotonNetwork.Instantiate(artistPrefab.name, new Vector3(0, 0.85f, 10f),Quaternion.Euler(0,180,0));
        obj.transform.SetParent(this.transform);
    }



}