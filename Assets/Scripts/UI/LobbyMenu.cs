using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using Unity.Services;

using Unity.Services.Core;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _joinCodeText;
    [SerializeField] private TMP_InputField _joinCodeInputField;
    [SerializeField] private GameObject _button;

    private UnityTransport _transport;
    private const int MaxPlayers = 2;

    private static async Task Authenticate()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
        private async void Awake()
    {
        _transport = FindObjectOfType<UnityTransport>();
        _button.SetActive(false);
        await Authenticate();
        _button.SetActive(true);
    }

    public async void CreateGame()
    {
        _button.SetActive(false);

        Allocation a = await RelayService.Instance.CreateAllocationAsync(MaxPlayers);
        _joinCodeText.text = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);

        _transport.SetHostRelayData(a.RelayServer.IpV4,
            (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);

        NetworkManager.Singleton.StartHost();
    }

    public async void JoinGame()
    {
        _button.SetActive(false);

        JoinAllocation a = await RelayService.Instance.JoinAllocationAsync(_joinCodeInputField.text);
        _transport.SetClientRelayData(a.RelayServer.IpV4,
            (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData, a.HostConnectionData);

        NetworkManager.Singleton.StartClient();
    }



    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Back to Main Menu");
    }
}
