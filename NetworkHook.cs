using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Prototype.NetworkLobby;

public class NetworkHook : LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        SetUpLocalPlayer localplayer = gamePlayer.GetComponent<SetUpLocalPlayer>();

        localplayer.Pname = lobby.name;
        localplayer.playercolor = lobby.playerColor;
    }
}