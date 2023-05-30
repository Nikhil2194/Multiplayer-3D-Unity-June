using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
   // public GameObject[] playerPrefab1;
   // public Transform[] spawnPoints;
    //public TMP_Text pingRateText;

    void Start()
    {
       // int randomIndex = Random.Range(0, spawnPoints.Length);
      //  int randomIndexPlayerPref = Random.Range(0, playerPrefab1.Length);
       // pingRateText.text = "Network Ping : " + PhotonNetwork.GetPing();
        if (PhotonNetwork.IsConnected)
        {
            // Create the player object across the network
            // PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, Quaternion.identity);
            // PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[randomIndex].position, Quaternion.identity);
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0,0.18f,0.08f), Quaternion.identity);
        }
    }
}