using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GeriButonu : MonoBehaviourPunCallbacks
{
    public void GeriButonunaBasildi()
    {
        if (PhotonNetwork.InRoom)
        {
            // Oyuncu odadaysa, odadan çık
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            // Odada değilse doğrudan lobiye dön
            SceneManager.LoadScene(8);
        }
    }

    public override void OnLeftRoom()
    {
        // Odadan çıkıldıktan sonra lobi sahnesini yükle
        SceneManager.LoadScene(8);
    }
<<<<<<< Updated upstream
}
=======
<<<<<<< HEAD
} 
=======
}
>>>>>>> 6a036ac4ab7c1ab6d801be4818d97a4d52850e86
>>>>>>> Stashed changes
