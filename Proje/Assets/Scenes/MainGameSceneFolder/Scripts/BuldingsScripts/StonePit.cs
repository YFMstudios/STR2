using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// StonePit s�n�f�, Building s�n�f�ndan kal�t�m al�r
public class StonePit : Building
{
    // Ekstra �zellikler

    public static int stoneProductionRate;
    public static bool canIStartProduction = false;

    public static int buildLevel = 0;
    public static bool wasStonePitCreated = false;

    // Kurucu y�ntem
    public StonePit()
    {
        // �zelliklerin ba�lang�� de�erlerini atama
        buildingName = "Stone Pit";
        buildingType = BuildingType.ResourceProduction;
        health = 100;
        buildGoldCost = 50;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
        stoneProductionRate = 3;
        numberOfBuild = 0;
    }



    public override void CompleteConstruction()
    {
        numberOfBuild++;
    }

    public static void refreshStoneProductionRate()
    {
        if (buildLevel == 1)
        {
            stoneProductionRate = 20;
        }
        else if (buildLevel == 2)
        {
            stoneProductionRate = 25;
        }
        else if (buildLevel == 3)
        {
            stoneProductionRate = 30;
        }
    }

    public override void UpdateCosts()
    {
        // Bina seviyesine g�re maliyet g�ncelleme
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