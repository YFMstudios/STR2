using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Lab : Building
{

    public static bool wasLabCreated = false;
    public static int buildLevel = 0;
    public Lab()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Lab";
        buildingType = BuildingType.Research;
        health = 100;
        buildGoldCost = 1;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
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
}
