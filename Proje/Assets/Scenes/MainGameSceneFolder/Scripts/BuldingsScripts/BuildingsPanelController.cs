using System.Collections.Generic;
using UnityEngine;

public class BuildingsPanelController : MonoBehaviour
{
    public GameObject KislaPaneli;
    public GameObject TasOcagiPaneli;
    public GameObject HastanePaneli;
    public GameObject KeresteciPaneli;
    public GameObject DemirciPaneli;
    public GameObject CiftlikPaneli;

    // A��k olabilecek panellerin listesi
    private List<GameObject> allPanels;

    private void Start()
    {
        // T�m panelleri listeye ekleyelim
        allPanels = new List<GameObject> {
            KislaPaneli, TasOcagiPaneli, HastanePaneli,
            KeresteciPaneli, DemirciPaneli, CiftlikPaneli
        };
    }

    // Belirli bir paneli a� ve di�erlerini kapat veya aktifse kapat
    public void OpenPanel(GameObject panelToToggle)
    {
        // E�er panel zaten a��ksa, t�kland���nda kapat�r
        if (panelToToggle.activeSelf)
        {
            panelToToggle.SetActive(false);
            return;
        }

        // Paneli a� ve di�er panelleri kapat
        foreach (GameObject panel in allPanels)
        {
            if (panel == panelToToggle)
            {
                panel.SetActive(true); // Paneli a�
            }
            else
            {
                panel.SetActive(false); // Di�er panelleri kapat
            }
        }
    }
}
