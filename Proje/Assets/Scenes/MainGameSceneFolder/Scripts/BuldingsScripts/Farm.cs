using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Farm : Building
{
    public static int foodProductionRate;
    public static bool canIStartProduction = false;
    public static int buildLevel = 0;
    public static bool wasFarmCreated = false;
    public Farm()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Farm";
        buildingType = BuildingType.ResourceProduction;
        health = 100;
        buildGoldCost = 1;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
        foodProductionRate = 15;
        numberOfBuild = 0;
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
    public override void CompleteConstruction()
    {
        numberOfBuild++;
    }

    public static void refreshFoodProductionRate()
    {
        if(buildLevel == 1)
        {
            foodProductionRate = 20;
        }
        else if(buildLevel == 2)
        {
            foodProductionRate = 25;
        }
        else if(buildLevel == 3) 
        {
            foodProductionRate = 30;
        }
    }
}
