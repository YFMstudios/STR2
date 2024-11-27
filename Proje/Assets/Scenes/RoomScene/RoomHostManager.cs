using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomHostManager : MonoBehaviourPunCallbacks
{
    public Button startButton; // Başlat butonu referansı
    public int targetSceneIndex = 6; // Geçiş yapılacak sahnenin indexi (örn. 6)

    void Start()
    {
        // Odaya girildiğinde butonu kontrol et
        UpdateStartButton();
    }

    public override void OnJoinedRoom()
    {
        // Yeni oyuncu odaya girdiğinde buton durumunu kontrol et
        UpdateStartButton();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // Oda sahibi çıkarsa yeni oda sahibi belirlenir ve buton durumu güncellenir
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Yeni oda sahibi sizsiniz!");
            UpdateStartButton();
        }
    }

    private void UpdateStartButton()
    {
        // Eğer oda sahibi isek buton görünür ve aktif, değilsek gizli olur
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.gameObject.SetActive(true);
            startButton.interactable = true;
        }
        else
        {
            startButton.gameObject.SetActive(false);
        }
    }

    public void OnStartButtonPressed()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Tüm oyuncuları hedef sahneye yönlendir
            PhotonNetwork.LoadLevel(targetSceneIndex);
        }
        else
        {
            Debug.LogWarning("Sadece oda sahibi oyunu başlatabilir!");
        }
    }
}
