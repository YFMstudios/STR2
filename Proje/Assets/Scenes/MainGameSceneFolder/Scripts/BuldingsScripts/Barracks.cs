using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Barracks : Building
{
    public static int buildLevel = 0;
    public static bool wasBarracksCreated = false;

    public Barracks()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Barracks";
        buildingType = BuildingType.UnitProduction;
        health = 100;
        buildGoldCost = 100;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
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
}
