using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : Building
{

    public static int buildLevel = 0;
    public static bool wasHospitalCreated = false;
    public static int capasity = 0;
    public Hospital()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Hospital";
        buildingType = BuildingType.Medical;
        health = 100;
        buildGoldCost = 500;
        buildFoodCost = 500;
        buildIronCost = 500;
        buildStoneCost = 500;
        buildTimberCost = 500;
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

    public void UpdateCapasity()
    {
        if (buildLevel == 1)
        {
            capasity = 1000;
        }
        else if (buildLevel == 2)
        {
            capasity = 2500;
        }
        else if(buildLevel == 3)
        {
            capasity = 3000;
        }
    }
}
