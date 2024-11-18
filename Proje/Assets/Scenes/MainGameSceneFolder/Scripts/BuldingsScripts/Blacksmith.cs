using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : Building
{
    public static int ironProductionRate;
    public static bool canIStartProduction = false;
    public static int buildLevel = 0;
    public static bool wasBlacksmithCreated = false;

    public Blacksmith()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Blacksmith";
        buildingType = BuildingType.ResourceProduction;
        health = 100;
        buildGoldCost = 500;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
        ironProductionRate = 5;
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

    public static void refreshIronProductionRate()
    {
        if (buildLevel == 1)
        {
            ironProductionRate = 20;
        }
        else if (buildLevel == 2)
        {
            ironProductionRate = 25;
        }
        else if (buildLevel == 3)
        {
            ironProductionRate = 30;
        }
    }

}
