 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButtonEvents : MonoBehaviour
{
    public static bool[] isResearched = new bool[18];
    public Image[] researchItems = new Image[18];
    public Button[] button = new Button[18];

    public ImageColorTransition imageColorTransition;
    public void level1Research()
    {
        if (Lab.wasLabCreated == true)
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;


            imageColorTransition.StartColorTransitionSeviye1();

            //isResearched[0] = true;            
            Destroy(button[0].gameObject);
        }
        else
        {
            Debug.Log("Labaratuvar Ýnþa Etmelisin");
        }
        
    }

    public void level2Research()
    {
        if(Lab.buildLevel >= 1 && isResearched[0]) 
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;


            imageColorTransition.StartColorTransitionSeviye2();
            //isResearched[1] = true;
            //researchItems[1].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[1].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az seviye 1 olduðundan ve Level 1 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
       
    }

    public void level3Research()
    {

        if (Lab.buildLevel >=1 && isResearched[0])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;


            imageColorTransition.StartColorTransitionSeviye3();
            //isResearched[2] = true;
            //researchItems[2].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[2].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az seviye 1 olduðundan ve Level 1 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }

    public void level4Research()
    {
        if (Lab.buildLevel >= 1 && isResearched[1])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;


            imageColorTransition.StartColorTransitionSeviye4();
            //isResearched[3] = true;
            //researchItems[3].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[3].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az seviye 1 olduðundan ve Level 2 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
    }

    public void level5Research()
    {

        if (Lab.buildLevel >= 1 && isResearched[2])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            imageColorTransition.StartColorTransitionSeviye5();
            //isResearched[4] = true;
            //researchItems[4].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[4].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az seviye 1 olduðundan ve Level 3 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
       
    }

    public void level6Research()
    {
        if (Lab.buildLevel >= 2 && isResearched[3] && isResearched[4])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            imageColorTransition.StartColorTransitionSeviye6();
            //isResearched[5] = true;
            //researchItems[5].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[5].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 4,5 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }

    public void level7Research()
    {

        if (Lab.buildLevel >= 2 && isResearched[3] && isResearched[4])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;


            imageColorTransition.StartColorTransitionSeviye7();
            //isResearched[6] = true;
            //researchItems[6].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[6].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 4,5 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }

    public void level8Research()
    {
        if(Lab.buildLevel >= 2 && isResearched[3] && isResearched[4])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            imageColorTransition.StartColorTransitionSeviye8();
            //isResearched[7] = true;
            //researchItems[7].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[7].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 4,5 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }
    public void level9Research()
    {
        if (Lab.buildLevel >= 2 && isResearched[5] && isResearched[6])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            imageColorTransition.StartColorTransitionSeviye9();
            //isResearched[8] = true;
            //researchItems[8].color = new Color(255f, 255f, 255f, 255f);
            Destroy(button[8].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 6,7 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }

        
    }
    public void level10Research()
    {
        if (Lab.buildLevel >= 2 && isResearched[6] && isResearched[7])
        {

            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[9] = true;
            //researchItems[9].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye10();
            Destroy(button[9].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 7,8  Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }

    }
    public void level11Research()
    {
        if (Lab.buildLevel >= 2 && isResearched[8])
        {

            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[10] = true;
            //researchItems[10].color = new Color(255f, 255f, 255f, 255f);

            imageColorTransition.StartColorTransitionSeviye11();
            Destroy(button[10].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 9 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        } 

    }
    public void level12Research()
    {
        if (Lab.buildLevel >= 2 && isResearched[8] && isResearched[9])
        {

            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[11] = true;
            //researchItems[11].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye12();
            Destroy(button[11].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 9,10 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }

        
    }
    public void level13Research()
    {
        if (Lab.buildLevel >= 2 && isResearched[9])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[12] = true;
            //researchItems[12].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye13();
            Destroy(button[12].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 2.seviye olduðundan ve Level 10 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }
    public void level14Research()
    {
        if (Lab.buildLevel >= 3 && isResearched[10] && isResearched[11])
        {

            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[13] = true;
            //researchItems[13].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye14();
            Destroy(button[13].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 3.seviye olduðundan ve Level 11,12 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }

    }
    public void level15Research()
    {
        if (Lab.buildLevel >= 3 && isResearched[11] && isResearched[12])
        {

            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[14] = true;
            //researchItems[14].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye15();
            Destroy(button[14].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 3.seviye olduðundan ve Level 12,13 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }
    public void level16Research()
    {
        if (Lab.buildLevel >= 3 && isResearched[13])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[15] = true;
            //researchItems[15].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye16();
            Destroy(button[15].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 3.seviye olduðundan ve Level 14 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }
    public void level17Research()
    {
        if (Lab.buildLevel >= 3 && isResearched[14])
        {
            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[16] = true;
            //researchItems[16].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye17();
            Destroy(button[16].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 3.seviye olduðundan ve Level 15 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }
    public void level18Research()
    {
        if (Lab.buildLevel >= 3 && isResearched[15] && isResearched[16])
        {

            Kingdom.myKingdom.FoodAmount -= 1;
            Kingdom.myKingdom.IronAmount -= 1;
            Kingdom.myKingdom.WoodAmount -= 1;
            Kingdom.myKingdom.StoneAmount -= 1;

            //isResearched[17] = true;
            //researchItems[17].color = new Color(255f, 255f, 255f, 255f);
            imageColorTransition.StartColorTransitionSeviye18();
            Destroy(button[17].gameObject);
        }
        else
        {
            Debug.Log("Laboratuvarýn en az 3.seviye olduðundan ve Level 16,17 Araþtýrmasýný yaptýðýnýzdan emin olun!");
        }
        
    }
}
    
