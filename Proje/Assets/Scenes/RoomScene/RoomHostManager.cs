<<<<<<< Updated upstream
=======
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> 6a036ac4ab7c1ab6d801be4818d97a4d52850e86
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomHostManager : MonoBehaviourPunCallbacks
{
    public Button startButton; // Başlat butonu referansı
    public int targetSceneIndex = 6; // Geçiş yapılacak sahnenin indexi (örn. 6)

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
    private List<Player> playerList = new List<Player>(); // Oyuncuları tutacak liste

    void Start()
    {
        // Sürekli olarak oyuncu listesini güncelle
        InvokeRepeating(nameof(UpdatePlayerList), 0f, 1f); // Her saniyede bir günceller
        UpdateStartButton(); // İlk buton durumunu ayarla
    }

    private void UpdatePlayerList()
    {
        if (!PhotonNetwork.InRoom) return; // Eğer odada değilsek işlem yapma

        // Mevcut oyuncuları listeye ekle
        playerList.Clear();
        foreach (KeyValuePair<int, Player> playerEntry in PhotonNetwork.CurrentRoom.Players)
        {
            Player player = playerEntry.Value;
            if (!playerList.Contains(player))
            {
                playerList.Add(player);
            }
        }

        Debug.Log($"Player listesi güncellendi. Toplam oyuncu sayısı: {playerList.Count}");

        // Oda sahibini kontrol et ve ata
        AssignNewMaster();
=======
>>>>>>> Stashed changes
    void Start()
    {
        // Odaya girildiğinde butonu kontrol et
        UpdateStartButton();
<<<<<<< Updated upstream
=======
>>>>>>> 6a036ac4ab7c1ab6d801be4818d97a4d52850e86
>>>>>>> Stashed changes
    }

    public override void OnJoinedRoom()
    {
<<<<<<< Updated upstream
        // Yeni oyuncu odaya girdiğinde buton durumunu kontrol et
        UpdateStartButton();
=======
<<<<<<< HEAD
        Debug.Log($"{PhotonNetwork.LocalPlayer.NickName} odaya katıldı.");
        UpdatePlayerList(); // Listeyi güncelle
        UpdateStartButton(); // Buton durumunu güncelle
=======
        // Yeni oyuncu odaya girdiğinde buton durumunu kontrol et
        UpdateStartButton();
>>>>>>> 6a036ac4ab7c1ab6d801be4818d97a4d52850e86
>>>>>>> Stashed changes
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
        Debug.Log($"{otherPlayer.NickName} odadan ayrıldı.");
        UpdatePlayerList(); // Oyuncu listesi güncelle
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log($"Yeni oda sahibi atandı: {newMasterClient.NickName}");
        UpdateStartButton(); // Yeni oda sahibine göre buton durumu güncelle
    }

    public void UpdateStartButton()
    {
        // Eğer oda sahibi isek buton görünür ve aktif, değilse gizli olur
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
>>>>>>> 6a036ac4ab7c1ab6d801be4818d97a4d52850e86
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
<<<<<<< HEAD

    // Yeni oda sahibini belirle
private void AssignNewMaster()
{
    if (PhotonNetwork.CurrentRoom.Players.Count > 0)
    {
        Player currentMaster = PhotonNetwork.MasterClient;

        // Eğer mevcut oda sahibi bizsek, butonu güncelle ve çık
        if (currentMaster == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("Zaten oda sahibiyim. Buton güncelleniyor.");
            UpdateStartButton();
            return;
        }

        // Yeni oda sahibini kontrol et
        foreach (Player player in PhotonNetwork.CurrentRoom.Players.Values)
        {
            if (player.IsMasterClient)
            {
                Debug.Log($"Yeni oda sahibi otomatik atanmış: {player.NickName}");
                UpdateStartButton(); // Buton durumunu güncelle
                return;
            }
        }

        // Eğer otomatik atanmadıysa manuel olarak ilk oyuncuyu ata (çok nadir bir durum)
        var firstPlayer = PhotonNetwork.CurrentRoom.Players.Values.GetEnumerator();
        if (firstPlayer.MoveNext())
        {
            Player newMaster = firstPlayer.Current;
            PhotonNetwork.SetMasterClient(newMaster);
            Debug.Log($"Yeni oda sahibi manuel olarak atandı: {newMaster.NickName}");
        }
    }

    // Buton durumunu güncelle
    UpdateStartButton();
}


=======
>>>>>>> 6a036ac4ab7c1ab6d801be4818d97a4d52850e86
>>>>>>> Stashed changes
}
