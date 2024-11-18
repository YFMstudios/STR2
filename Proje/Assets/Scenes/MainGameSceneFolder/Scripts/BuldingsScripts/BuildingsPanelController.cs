using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsPanelController : MonoBehaviour
{
    public GameObject KislaPaneli;
    public GameObject TasOcagiPaneli;
    public GameObject HastanePaneli;
    public GameObject KeresteciPaneli;
    public GameObject DemirciPaneli;
    public GameObject CiftlikPaneli;
    public GameObject LaboratuvarPaneli;

    public TMP_Text goldText;     // Altın miktarını gösterecek TMP_Text bileşeni
    public TMP_Text woodText;     // Kereste miktarını gösterecek TMP_Text bileşeni
    public TMP_Text stoneText;    // Taş miktarını gösterecek TMP_Text bileşeni
    public TMP_Text ironText;     // Demir miktarını gösterecek TMP_Text bileşeni
    public TMP_Text foodText;     // Yemek miktarını gösterecek TMP_Text bileşeni
    public TMP_Text buildLevelText;     // Bina seviyesini gösterecek TMP bileşeni
    public TMP_Text productionRateText; // Üretim Miktarını gösterecek TMP bileşeni
    public TMP_Text maliyetText;

    public Image goldImage;        // Altın için resim
    public Image woodImage;        // Kereste için resim
    public Image stoneImage;       // Taş için resim
    public Image ironImage;        // Demir için resim
    public Image foodImage;

    // A��k olabilecek panellerin listesi
    private List<GameObject> allPanels;

    private void Start()
    {
        // T�m panelleri listeye ekleyelim
        allPanels = new List<GameObject> {
            KislaPaneli, TasOcagiPaneli, HastanePaneli,
            KeresteciPaneli, DemirciPaneli, CiftlikPaneli, LaboratuvarPaneli
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

    //Binalar seviye atladığında açıklamalarını güncelleyen fonksiyon.
    public void refreshFarm()
    {

        if (Farm.buildLevel == 1)
        {
            buildLevelText.text = "1";
            productionRateText.text = "5 b/s";
            goldText.text = "2200";
            foodText.text = "1000";
            woodText.text = "1600";
            stoneText.text = "700";
            ironText.text = "400";
        }
        if (Farm.buildLevel == 2)
        {
            buildLevelText.text = "2";
            productionRateText.text = "10 b/s";
            goldText.text = "3600";
            foodText.text = "2000";
            woodText.text = "3200";
            stoneText.text = "1200";
            ironText.text = "800";
        }
        if (Farm.buildLevel == 3)
        {
            buildLevelText.text = "3";
            productionRateText.text = "15 b/s";
            DestroyComponents();
        }
    }

    public void refreshBlacksmith()
    {

        if (Blacksmith.buildLevel == 1)
        {
            buildLevelText.text = "1";
            productionRateText.text = "5 b/s";
            goldText.text = "3500";
            foodText.text = "2000";
            woodText.text = "1800";
            stoneText.text = "1500";
            ironText.text = "1200";
        }
        if (Blacksmith.buildLevel == 2)
        {
            buildLevelText.text = "2";
            productionRateText.text = "10 b/s";
            goldText.text = "7000";
            foodText.text = "4000";
            woodText.text = "3600";
            stoneText.text = "3000";
            ironText.text = "2400";
        }
        if (Blacksmith.buildLevel == 3)
        {
            buildLevelText.text = "3";
            productionRateText.text = "15 b/s";
            DestroyComponents();
        }
    }

    public void refreshStonePit()
    {

        if (StonePit.buildLevel == 1)
        {
            buildLevelText.text = "1";
            productionRateText.text = "5 b/s";
            goldText.text = "3200";
            foodText.text = "1800";
            woodText.text = "1600";
            stoneText.text = "1300";
            ironText.text = "1000";
        }
        if (StonePit.buildLevel == 2)
        {
            buildLevelText.text = "2";
            productionRateText.text = "10 b/s";
            goldText.text = "6500";
            foodText.text = "3600";
            woodText.text = "3200";
            stoneText.text = "2600";
            ironText.text = "2000";
        }
        if (StonePit.buildLevel == 3)
        {
            buildLevelText.text = "3";
            productionRateText.text = "15 b/s";
            DestroyComponents();
        }
    }

    public void refreshSawmill()
    {

        if (Sawmill.buildLevel == 1)
        {
            buildLevelText.text = "1";
            productionRateText.text = "5 b/s";
            goldText.text = "2000";
            foodText.text = "1600";
            woodText.text = "1600";
            stoneText.text = "1300";
            ironText.text = "1000";
        }
        if (Sawmill.buildLevel == 2)
        {
            buildLevelText.text = "2";
            productionRateText.text = "10 b/s";
            goldText.text = "4000";
            foodText.text = "3200";
            woodText.text = "3200";
            stoneText.text = "2600";
            ironText.text = "2000";
        }
        if (Sawmill.buildLevel == 3)
        {
            buildLevelText.text = "3";
            productionRateText.text = "15 b/s";
            DestroyComponents();
        }
    }

    public void refreshBarracks()
    {
        if (Barracks.buildLevel == 1)
        {
            buildLevelText.text = "1";
            productionRateText.text = "5 asker/dk";
            goldText.text = "3000";
            foodText.text = "2000";
            woodText.text = "2200";
            stoneText.text = "1800";
            ironText.text = "1500";
        }
        else if (Barracks.buildLevel == 2)
        {
            buildLevelText.text = "2";
            productionRateText.text = "10 asker/dk";
            goldText.text = "4500";
            foodText.text = "3000";
            woodText.text = "3000";
            stoneText.text = "2500";
            ironText.text = "2000";
        }
        else if (Barracks.buildLevel == 3)
        {
            buildLevelText.text = "3";
            productionRateText.text = "15 asker/dk";

            DestroyComponents();

        }
    }

    public void refreshHospital()
    {
        if (Hospital.buildLevel == 1)
        {
            buildLevelText.text = "1";
            productionRateText.text = "5 asker/dk";
            goldText.text = "3500";
            foodText.text = "1800";
            woodText.text = "2200";
            stoneText.text = "2000";
            ironText.text = "1500";
        }
        else if (Hospital.buildLevel == 2)
        {
            buildLevelText.text = "2";
            productionRateText.text = "10 asker/dk";
            goldText.text = "5000";
            foodText.text = "2500";
            woodText.text = "3500";
            stoneText.text = "3000";
            ironText.text = "2000";
        }
        else if (Hospital.buildLevel == 3)
        {
            buildLevelText.text = "3";
            productionRateText.text = "15 asker/dk";

            DestroyComponents();

        }
    }

    public void refreshLab()
    {
        if (Lab.buildLevel == 1)
        {
            buildLevelText.text = "1";
            goldText.text = "5000";
            foodText.text = "4000";
            woodText.text = "3500";
            stoneText.text = "4500";
            ironText.text = "4000";
        }
        else if (Lab.buildLevel == 2)
        {
            buildLevelText.text = "2";
            goldText.text = "7500";
            foodText.text = "6000";
            woodText.text = "5000";
            stoneText.text = "7000";
            ironText.text = "6500";
        }
        else if (Lab.buildLevel == 3)
        {
            buildLevelText.text = "3";
            DestroyComponents();

        }
    }


    public void DestroyComponents()
    {
        // TMP_Text bileşenlerini yok et
        if (goldText != null) Destroy(goldText);
        if (woodText != null) Destroy(woodText);
        if (stoneText != null) Destroy(stoneText);
        if (ironText != null) Destroy(ironText);
        if (foodText != null) Destroy(foodText);
        if (maliyetText != null) Destroy(maliyetText);

        // Image bileşenlerini yok et
        if (goldImage != null) Destroy(goldImage);
        if (woodImage != null) Destroy(woodImage);
        if (stoneImage != null) Destroy(stoneImage);
        if (ironImage != null) Destroy(ironImage);
        if (foodImage != null) Destroy(foodImage);
    }
}