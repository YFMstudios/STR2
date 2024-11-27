using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerInfoPrefab; // Prefab'inizi buraya atayın.
    public RectTransform Panel; // Prefab'lerin yerleşeceği panel (UI RectTransform).
    private List<int> playerOrder = new List<int>(); // Oyuncu sırasını tutan liste.
    private Dictionary<int, GameObject> playerObjects = new Dictionary<int, GameObject>();

    private float yOffset = 140f; // Her prefab arasındaki mesafe.
    private float topPadding = 150f; // En üst prefab için başlangıç mesafesi (panelin üstünden aşağı doğru).

    private void Start()
    {
        StartCoroutine(UpdatePlayerData());
    }

    private IEnumerator UpdatePlayerData()
    {
        while (true)
        {
            if (PhotonNetwork.InRoom)
            {
                foreach (KeyValuePair<int, Player> playerEntry in PhotonNetwork.CurrentRoom.Players)
                {
                    Player player = playerEntry.Value;

                    // Krallık bilgisi al
                    string kingdom = player.CustomProperties.ContainsKey("Kingdom")
                        ? player.CustomProperties["Kingdom"].ToString()
                        : "Unknown";

                    // Bilgiler eksikse prefab oluşturmayı atla
                    if (kingdom == "Unknown")
                        continue;

                    // Eğer prefab zaten varsa güncelle
                    if (playerObjects.ContainsKey(player.ActorNumber))
                    {
                        var playerDisplay = playerObjects[player.ActorNumber].GetComponent<PlayerInfoDisplay>();
                        playerDisplay.UpdateInfo(player.NickName, kingdom);
                    }
                    else
                    {
                        // Yeni prefab oluştur
                        GameObject playerObject = Instantiate(PlayerInfoPrefab, Panel);
                        playerObjects[player.ActorNumber] = playerObject;
                        playerOrder.Add(player.ActorNumber);
                        UpdatePrefabPositions();
                    }
                }
            }

            yield return new WaitForSeconds(1f); // 1 saniyede bir güncelle
        }
    }

    private void UpdatePrefabPositions()
    {
        // Panelin üst kısmını başlangıç pozisyonu olarak al ve biraz aşağı kaydır
        float startY = Panel.rect.height / 2 - topPadding;

        for (int i = 0; i < playerOrder.Count; i++)
        {
            int actorNumber = playerOrder[i];
            if (playerObjects.ContainsKey(actorNumber))
            {
                // Prefab'in pozisyonunu güncelle
                GameObject playerObject = playerObjects[actorNumber];
                RectTransform rectTransform = playerObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(0, startY - (i * yOffset));
            }
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // Prefab ve oyuncu sırasını kaldır
        if (playerObjects.ContainsKey(otherPlayer.ActorNumber))
        {
            Destroy(playerObjects[otherPlayer.ActorNumber]);
            playerObjects.Remove(otherPlayer.ActorNumber);
            playerOrder.Remove(otherPlayer.ActorNumber);
            UpdatePrefabPositions();
        }
    }
}
