using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Collections;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.Events;

public class SignalRQueriesListener : MonoBehaviour
{

    /*[field: SerializeField]*/ public bool isSetup { get; set; } = false;
    [SerializeField]private string signalRHubURL;

    public UnityAction OnConnected;
    public List<string> queries= new();
    public string teamsJson = null;
    //[SerializeField]private Text uiText;
    public int ID;
    public int cityId;
    public bool isConnected = false;

    
    private string hubMethodA = "JoinGroup";

    private string statusText = "Awaiting Connection...";
    private string disconnectedText = "Connection Disconnected";

    private const string HANDLER_A = "InvalidEvent";

    private const string HANDLER_B = "TeamsList";
    private const string HANDLER_C = "InitEvents";
    public GameObject isConnectedMarker;
    public GameObject isReconnectingMarker;
    public GameObject isDisconnectedMarker;
    private List<string> _args = new();



    public List<string> GetQueries()
    {
        return queries;
    }
    
    void Start()
    {
        try
        {
            DisplayMessage(statusText);

            SignalR signalR = new SignalR();
            signalR.Init(signalRHubURL);


            signalR.On(HANDLER_A, (string payload) =>
             {
                 queries.Add(payload);
                 Debug.Log(payload);

             });

            signalR.On(HANDLER_C, (string payload) =>
            {
                queries.Reverse();
                queries.Add(payload);
                queries.Reverse();
                Debug.Log(payload);
            });

            signalR.On(HANDLER_B, (string payload) =>
            {
                teamsJson = payload;
                Debug.Log($"{HANDLER_B}: {payload}");
            });

            signalR.ConnectionStarted += (object sender, ConnectionEventArgs e) =>
            {

                signalR.Invoke(hubMethodA, ID.ToString());
                Debug.Log("Connected");
                isConnected = true;
                isReconnecting = false;
                OnConnected.Invoke();
            };
            signalR.ConnectionClosed += (object sender, ConnectionEventArgs e) =>
            {
                Debug.Log($"Disconnected: {e.ConnectionId}");
                DisplayMessage(disconnectedText);
                isConnected = false;
                isSetup = false;
            };
            signalR.Connect();
            isReconnecting = true;
            Debug.developerConsoleVisible = true;
        }
        catch(Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }
    public void SetReadyStatus(bool val)
    {
        isSetup = val;
    }
    public bool IsReady() { return isSetup; }
    void DisplayMessage(string message)
    {
        //uiText.text = $"{message}";
        
        Debug.Log(message);
    }

    private bool isReconnecting = false;

    public void Update()
    {
        isDisconnectedMarker?.SetActive(!isConnected);
        isReconnectingMarker?.SetActive(isReconnecting);
        isConnectedMarker?.SetActive(isConnected);
        if (!isConnected &&!isReconnecting && Input.GetKeyDown( KeyCode.F5))
        {
            Start();
        }
    }
    
    


    public class JsonPayload
    {
        public string message;
    }


}









