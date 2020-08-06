﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Quickstartlobbycontroller : MonoBehaviourPunCallbacks
{
    public GameObject quickstartbutton;
    public GameObject quickcancelbutton;
    public int Roomsize;
    private int SurCount = 0;
    private bool HaveHunter = false;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickstartbutton.SetActive(true);
    }
    public void QuickStart()
    {
        quickstartbutton.SetActive(false);
        quickcancelbutton.SetActive(true);
        if (Swaprole.chooserole.Role == "Survival")
        {
            if (SurCount <= 3)
            {
                SurCount++;
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                CreateRoom();
            }
        }
        else
        {
            if (!HaveHunter)
            {
                CreateRoom();
            }
            else
            {
                HaveHunter = !HaveHunter;
                PhotonNetwork.JoinRandomRoom();
            }
        }
        Debug.Log("Quick start");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join");
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("Create Room");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)Roomsize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    public void QuickCancel()
    {
        quickcancelbutton.SetActive(false);
        quickstartbutton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
