using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    [SerializeField]
    GameObject playerPrefab;

    public static GameManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (playerPrefab != null)
            {
                int randomPoint = Random.Range(-45, -40);

                PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(randomPoint, -10, 235), Quaternion.identity);
            }
        }
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLauncherScene");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
