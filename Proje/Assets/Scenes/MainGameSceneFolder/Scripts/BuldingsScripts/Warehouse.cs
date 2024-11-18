using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;



public class Warehouse : Building
{

    public static int buildLevel = 0;
    public static bool wasWarehouseCreated = false;

    public static int foodCapacity = 101000;
    public static int ironCapacity = 101000;
    public static int timberCapacity = 101000;
    public static int stoneCapacity = 100100;



    public Warehouse()
    {
        // Özelliklerin baþlangýç deðerlerini atama
        buildingName = "Warehouse";
        buildingType = BuildingType.ResourceProduction;
        health = 100;
        buildGoldCost = 1;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
    }

    public static void IncreaseCapacity()
    {
        if (buildLevel == 1)
        {
            Warehouse.foodCapacity += 10;
            Warehouse.stoneCapacity += 10;
            Warehouse.timberCapacity += 10;
            Warehouse.ironCapacity += 10;
        }
        if (buildLevel == 2)
        {
            Warehouse.foodCapacity += 10;
            Warehouse.stoneCapacity += 10;
            Warehouse.timberCapacity += 10;
            Warehouse.ironCapacity += 10;
        }
        if (buildLevel == 3)
        {
            Warehouse.foodCapacity += 10;
            Warehouse.stoneCapacity += 10;
            Warehouse.timberCapacity += 10;
            Warehouse.ironCapacity += 10;
        }
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
            buildGoldCost = 25000;
        }
    }
}
