using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawmill : Building
{
    // Ekstra özellikler
    public static int timberProductionRate;
    public static bool canIStartProduction = false;

    public static int buildLevel = 0;
    public static bool wasSawmillCreated = false;
    // Kurucu yöntem
    public Sawmill()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Sawmill";
        buildingType = BuildingType.ResourceProduction;
        health = 100;
        buildGoldCost = 1;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
        timberProductionRate = 5;
        numberOfBuild = 0;
    }


    public override void CompleteConstruction()
    {
        numberOfBuild++;
    }

    public override void UpdateCosts()
    {
        // Bina seviyesine göre maliyet güncelleme
        if (buildLevel == 1)
        {
            buildGoldCost = 1000;
        }
        else if (buildLevel == 2)
        {
            buildGoldCost = 2500;
        }
    }

    public static void refreshTimberProductionRate()
    {
        if (buildLevel == 1)
        {
            timberProductionRate = 20;
        }
        else if (buildLevel == 2)
        {
            timberProductionRate = 25;
        }
        else if (buildLevel == 3)
        {
            timberProductionRate = 30;
        }
    }

}
