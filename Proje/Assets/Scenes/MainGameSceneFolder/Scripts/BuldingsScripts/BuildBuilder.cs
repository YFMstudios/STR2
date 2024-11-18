using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildBuilder : MonoBehaviour
{
    public ResearchController researchController;
    public Button buildButton;
    private Text buttonText;
    public static bool checkResources(Building building) // Artýk Building türü kabul ediliyor
    {
        // Güncel maliyetleri kontrol edin
        building.UpdateCosts();

        if ((building.buildGoldCost > Kingdom.myKingdom.GoldAmount) ||
            (building.buildStoneCost > Kingdom.myKingdom.StoneAmount) ||
            (building.buildTimberCost > Kingdom.myKingdom.WoodAmount) ||
            (building.buildIronCost > Kingdom.myKingdom.IronAmount) ||
            (building.buildFoodCost > Kingdom.myKingdom.FoodAmount))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void BuildStonePit()
    {
        // Zaten var olan taþ ocaðý nesnesini kullanmak için kontrol edin
        StonePit stonePit = GetComponent<StonePit>();

        if (!StonePit.wasStonePitCreated)
        {
            stonePit = gameObject.AddComponent<StonePit>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(stonePit))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= stonePit.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= stonePit.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= stonePit.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= stonePit.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= stonePit.buildFoodCost;

                StonePit.wasStonePitCreated = true;
                StonePit.canIStartProduction = true;
                StonePit.buildLevel = 1;
                StonePit.refreshStoneProductionRate();
                stonePit.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + StonePit.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir taþ ocaðý varsa, yeni bir nesne yaratmayýn
            if (checkResources(stonePit))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= stonePit.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= stonePit.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= stonePit.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= stonePit.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= stonePit.buildFoodCost;

                StonePit.buildLevel++;
                StonePit.refreshStoneProductionRate(); // Üretim miktarýný güncelliyoruz.
                stonePit.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (StonePit.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildBlacksmith()
    {
        // Zaten var olan demirci nesnesini kullanmak için kontrol edin
        Blacksmith blacksmith = GetComponent<Blacksmith>();

        if (!Blacksmith.wasBlacksmithCreated)
        {
            blacksmith = gameObject.AddComponent<Blacksmith>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(blacksmith))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= blacksmith.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= blacksmith.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= blacksmith.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= blacksmith.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= blacksmith.buildFoodCost;

                Blacksmith.wasBlacksmithCreated = true;
                Blacksmith.canIStartProduction = true;
                Blacksmith.buildLevel = 1;
                Blacksmith.refreshIronProductionRate();
                blacksmith.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + Blacksmith.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir demirci varsa, yeni bir nesne yaratmayýn
            if (checkResources(blacksmith))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= blacksmith.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= blacksmith.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= blacksmith.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= blacksmith.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= blacksmith.buildFoodCost;

                Blacksmith.buildLevel++;
                Blacksmith.refreshIronProductionRate(); // Üretim miktarýný güncelliyoruz.
                blacksmith.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (Blacksmith.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildSawmill()
    {
        // Zaten var olan kereste fabrikasý nesnesini kullanmak için kontrol edin
        Sawmill sawmill = GetComponent<Sawmill>();

        if (!Sawmill.wasSawmillCreated)
        {
            sawmill = gameObject.AddComponent<Sawmill>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(sawmill))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= sawmill.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= sawmill.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= sawmill.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= sawmill.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= sawmill.buildFoodCost;

                Sawmill.wasSawmillCreated = true;
                Sawmill.canIStartProduction = true;
                Sawmill.buildLevel = 1;
                Sawmill.refreshTimberProductionRate();
                sawmill.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + Sawmill.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir kereste fabrikasý varsa, yeni bir nesne yaratmayýn
            if (checkResources(sawmill))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= sawmill.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= sawmill.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= sawmill.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= sawmill.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= sawmill.buildFoodCost;

                Sawmill.buildLevel++;
                Sawmill.refreshTimberProductionRate(); // Üretim miktarýný güncelliyoruz.
                sawmill.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (Sawmill.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildFarm()
    {
        // Zaten var olan çiftlik nesnesini kullanmak için kontrol edin
        Farm farm = GetComponent<Farm>();

        if (!Farm.wasFarmCreated)
        {
            farm = gameObject.AddComponent<Farm>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(farm))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= farm.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= farm.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= farm.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= farm.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= farm.buildFoodCost;

                Farm.wasFarmCreated = true;
                Farm.canIStartProduction = true;
                Farm.buildLevel = 1;
                Farm.refreshFoodProductionRate();
                farm.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + Farm.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir çiftlik varsa, yeni bir nesne yaratmayýn
            if (checkResources(farm))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= farm.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= farm.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= farm.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= farm.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= farm.buildFoodCost;

                Farm.buildLevel++;
                Farm.refreshFoodProductionRate();//Üretim miktarýný güncelliyoruz.
                farm.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (Farm.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildBarracks()
    {
        // Zaten var olan kýþla nesnesini kullanmak için kontrol edin
        Barracks barracks = GetComponent<Barracks>();

        if (!Barracks.wasBarracksCreated)
        {
            barracks = gameObject.AddComponent<Barracks>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(barracks))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= barracks.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= barracks.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= barracks.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= barracks.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= barracks.buildFoodCost;

                Barracks.wasBarracksCreated = true;
                Barracks.buildLevel = 1;
                barracks.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + Barracks.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir kýþla varsa, yeni bir nesne yaratmayýn
            if (checkResources(barracks))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= barracks.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= barracks.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= barracks.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= barracks.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= barracks.buildFoodCost;

                Barracks.buildLevel++;
                barracks.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (Barracks.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
}

    public void BuildHospital()
    {
        // Zaten var olan hastane nesnesini kullanmak için kontrol edin
        Hospital hospital = GetComponent<Hospital>();

        if (!Hospital.wasHospitalCreated)
        {
            hospital = gameObject.AddComponent<Hospital>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(hospital))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= hospital.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= hospital.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= hospital.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= hospital.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= hospital.buildFoodCost;

                Hospital.wasHospitalCreated = true;
                Hospital.buildLevel = 1;
                hospital.UpdateCapasity();
                Debug.Log("Bina Seviyesi : " + Hospital.buildLevel);
                Debug.Log("Hastane Kapasitesi : " + Hospital.capasity);
                hospital.UpdateCosts(); // Maliyetleri güncelle              
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir hastane varsa, yeni bir nesne yaratmayýn
            if (checkResources(hospital))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= hospital.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= hospital.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= hospital.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= hospital.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= hospital.buildFoodCost;

                Hospital.buildLevel++;
                hospital.UpdateCapasity();
                Debug.Log("Bina Seviyesi : " + Hospital.buildLevel);
                Debug.Log("Hastane Kapasitesi : " + Hospital.capasity);
                hospital.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (Hospital.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildLab()
    {
        if (Lab.wasLabCreated == false)
        {
            
            Lab lab = gameObject.AddComponent<Lab>();

            if (checkResources(lab))
            {
                Lab.wasLabCreated = true;

                Kingdom.myKingdom.GoldAmount -= lab.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= lab.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= lab.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= lab.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= lab.buildFoodCost;
                Lab.buildLevel++;
                researchController.OpenResearchUnit(Lab.buildLevel);
            }

            else
            {
                Debug.Log("Yeterli Kaynak Bulunmamaktadýr.");
            }
        }
        else
        {
            Debug.Log("Buraya da girdim");
            if (Lab.wasLabCreated)
            {
                if (Lab.buildLevel < 4)
                {
                    Lab.buildLevel++;
                    if (ResearchButtonEvents.isResearched[3] || ResearchButtonEvents.isResearched[4] || Lab.buildLevel == 2)
                    {
                       
                            Debug.Log("Level 2 Oldum");
                            researchController.controlBuildLevelTwoResearches();
                    
                    }
                    if (ResearchButtonEvents.isResearched[10] || ResearchButtonEvents.isResearched[11] || ResearchButtonEvents.isResearched[12] || Lab.buildLevel == 3)
                    {

                        Debug.Log("Level 3 Oldum");
                        researchController.controlBuildLevelThreeResearches();

                    }
                }
            }
        }
    }

    public void BuildDefenseWorkshop()
    {
        // Zaten var olan savunma atölyesi nesnesini kullanmak için kontrol edin
        DefenseWorkshop defenseWorkshop = GetComponent<DefenseWorkshop>();

        if (!DefenseWorkshop.wasDefenseWorkshopCreated)
        {
            defenseWorkshop = gameObject.AddComponent<DefenseWorkshop>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(defenseWorkshop))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= defenseWorkshop.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= defenseWorkshop.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= defenseWorkshop.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= defenseWorkshop.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= defenseWorkshop.buildFoodCost;

                DefenseWorkshop.wasDefenseWorkshopCreated = true;
                DefenseWorkshop.buildLevel = 1;
                defenseWorkshop.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + DefenseWorkshop.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir savunma atölyesi varsa, yeni bir nesne yaratmayýn
            if (checkResources(defenseWorkshop))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= defenseWorkshop.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= defenseWorkshop.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= defenseWorkshop.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= defenseWorkshop.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= defenseWorkshop.buildFoodCost;

                DefenseWorkshop.buildLevel++;
                Debug.Log("Bina Seviyesi : " + DefenseWorkshop.buildLevel);
                defenseWorkshop.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (DefenseWorkshop.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildSiegeWorkshop()
    {
        // Zaten var olan kuþatma atölyesi nesnesini kullanmak için kontrol edin
        SiegeWorkshop siegeWorkshop = GetComponent<SiegeWorkshop>();

        if (!SiegeWorkshop.wasSiegeWorkshopCreated)
        {
            siegeWorkshop = gameObject.AddComponent<SiegeWorkshop>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(siegeWorkshop))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= siegeWorkshop.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= siegeWorkshop.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= siegeWorkshop.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= siegeWorkshop.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= siegeWorkshop.buildFoodCost;

                SiegeWorkshop.wasSiegeWorkshopCreated = true;
                SiegeWorkshop.buildLevel = 1;
                siegeWorkshop.UpdateCosts(); // Maliyetleri güncelle

                Debug.Log("Bina Seviyesi : " + SiegeWorkshop.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir kuþatma atölyesi varsa, yeni bir nesne yaratmayýn
            if (checkResources(siegeWorkshop))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= siegeWorkshop.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= siegeWorkshop.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= siegeWorkshop.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= siegeWorkshop.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= siegeWorkshop.buildFoodCost;

                SiegeWorkshop.buildLevel++;
                Debug.Log("Bina Seviyesi : " + SiegeWorkshop.buildLevel);
                siegeWorkshop.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (SiegeWorkshop.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }

    }

    public void BuildWarehouse()
    {// Zaten var olan kýþla nesnesini kullanmak için kontrol edin
        Warehouse warehouse = GetComponent<Warehouse>();

        if (!Warehouse.wasWarehouseCreated)
        {
            warehouse = gameObject.AddComponent<Warehouse>();
            TextMeshProUGUI buttonText = buildButton.GetComponentInChildren<TextMeshProUGUI>();

            if (checkResources(warehouse))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= warehouse.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= warehouse.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= warehouse.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= warehouse.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= warehouse.buildFoodCost;

                Warehouse.wasWarehouseCreated = true;
                Warehouse.buildLevel = 1;
                Warehouse.IncreaseCapacity();
                warehouse.UpdateCosts();

                Debug.Log("Bina Seviyesi : " + Warehouse.buildLevel);
                buttonText.text = "Yükselt";
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
        else
        {
            // Zaten bir kýþla varsa, yeni bir nesne yaratmayýn
            if (checkResources(warehouse))
            {
                // Kaynaklarý azaltýn
                Kingdom.myKingdom.GoldAmount -= warehouse.buildGoldCost;
                Kingdom.myKingdom.StoneAmount -= warehouse.buildStoneCost;
                Kingdom.myKingdom.WoodAmount -= warehouse.buildTimberCost;
                Kingdom.myKingdom.IronAmount -= warehouse.buildIronCost;
                Kingdom.myKingdom.FoodAmount -= warehouse.buildFoodCost;

                Warehouse.buildLevel++;
                Debug.Log("Bina Seviyesi : " + Warehouse.buildLevel);
                Warehouse.IncreaseCapacity();
                warehouse.UpdateCosts(); // Maliyetleri güncelle

                // 3. seviyeye ulaþýldýðýnda butonu yok et
                if (Warehouse.buildLevel == 3)
                {
                    Destroy(buildButton.gameObject);
                }
            }
            else
            {
                Debug.Log("Yeterli kaynak bulunmamaktadýr");
            }
        }
    }




}

