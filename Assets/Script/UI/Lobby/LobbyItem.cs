using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyItem : MonoBehaviour
{
    [SerializeField] private TMP_Text lobbyNameText;
    [SerializeField] private TMP_Text lobbyPlayerCountText;
    private LobbiesList lobbiesList;
    private Lobby lobby;

    public void Initialise(LobbiesList lobbiesList,Lobby lobby)
    {
        this.lobbiesList = lobbiesList;
        this.lobby = lobby;

        lobbyNameText.text = lobby.Name;
        lobbyPlayerCountText.text = $"{lobby.Players.Count} P {lobby.MaxPlayers}";
    }

    public void JoinLobby()
    {
        lobbiesList.JoinAsync(lobby);
    }
}
