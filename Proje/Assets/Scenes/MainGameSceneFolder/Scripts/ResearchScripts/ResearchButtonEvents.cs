 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButtonEvents : MonoBehaviour
{
    public static bool[] isResearched = new bool[18];
    public Image[] researchItems = new Image[18];
    public Button[] button = new Button[18];

    public void level1Research()
    {
        if (Lab.wasLabCreated == true)
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            Farm.foodProductionRate += 1;
            Sawmill.timberProductionRate += 1;
            StonePit.stoneProductionRate += 1;
            Blacksmith.ironProductionRate += 1;

            isResearched[0] = true;
            researchItems[0].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[0].gameObject);
        }
        else
        {
            Debug.Log("Labaratuvar Ýnþa Etmelisin");
        }
        
    }

    public void level2Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[1] = true;
        researchItems[1].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[1].gameObject);
    }

    public void level3Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[2] = true;
        researchItems[2].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[2].gameObject);
    }

    public void level4Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[3] = true;
        researchItems[3].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[3].gameObject);

    }

    public void level5Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[4] = true;
        researchItems[4].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[4].gameObject);
    }

    public void level6Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[5] = true;
        researchItems[5].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[5].gameObject);
    }

    public void level7Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[6] = true;
        researchItems[6].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[6].gameObject);
    }

    public void level8Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[7] = true;
        researchItems[7].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[7].gameObject);
    }
    public void level9Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[8] = true;
        researchItems[8].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[8].gameObject);
    }
    public void level10Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[9] = true;
        researchItems[9].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[9].gameObject);
    }
    public void level11Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[10] = true;
        researchItems[10].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[10].gameObject);
    }
    public void level12Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[11] = true;
        researchItems[11].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[11].gameObject);
    }
    public void level13Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[12] = true;
        researchItems[12].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[12].gameObject);
    }
    public void level14Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[13] = true;
        researchItems[13].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[13].gameObject);
    }
    public void level15Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[14] = true;
        researchItems[14].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[14].gameObject);
    }
    public void level16Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[15] = true;
        researchItems[15].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[15].gameObject);
    }
    public void level17Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[16] = true;
        researchItems[16].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[16].gameObject);
    }
    public void level18Research()
    {
        Kingdom.myKingdom.FoodAmount -= 1;
        Kingdom.myKingdom.IronAmount -= 1;
        Kingdom.myKingdom.WoodAmount -= 1;
        Kingdom.myKingdom.StoneAmount -= 1;

        isResearched[17] = true;
        researchItems[17].color = new Color(255f, 255f, 255f, 255f);
        Destroy(button[17].gameObject);
    }
}
    
