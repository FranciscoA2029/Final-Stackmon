using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;

public class FTA_StackmonBase : FTA_CardBaseScript
{
    public enum StackType {
        Normal, Fire, Water, Grass
    }

    int levelUpMargin1 = 100;
    
    int nextStackmonType;
    StackType stackmonType;
    [SerializeField] bool ally;
    
    int hitPoints;
    int attack;
    [SerializeField] int exp;
    [SerializeField] int stage = 0;
    
    protected override void Start()
    {
        base.Start();

        DetermineStackmonTypeID();
        DetermineStackmonStats();

        exp = 0;
        //If Hungry Feeding()

    }

    protected override void Update()
    {
        
        CheckExp(); // CHANGE INTO ONLY WHEN GAINING EXP
        base.Update();
    }

    protected virtual void DetermineStackmonTypeID()
    {
        nextStackmonType = Random.Range(0, 3);
        switch (nextStackmonType)
        {
            case 0:
                stackmonType = StackType.Normal;
                break;
            case 1:
                stackmonType = StackType.Fire;
                break;
            case 2:
                stackmonType = StackType.Water;
                break;
            case 3:
                stackmonType = StackType.Grass;
                break;
            default:
                break;
        }
    }

    protected virtual void DetermineStackmonStats()
    {
        // Enemies are just made weaker :p
        if (!ally)
        {
            hitPoints = 4;
            attack = 1;
            return;
        }
        
        // Upon being called, does all the stuff to change Stackmon's stats
        switch (stage)
        {
            case 0:
                hitPoints = Random.Range(4, 6);
                attack = Random.Range(2, 3);
                break;
            case 1:
                hitPoints = Random.Range(8, 13);
                attack = Random.Range(4, 5);
                break;
            case 2:
                hitPoints = Random.Range(15, 22);
                attack = Random.Range(6, 8);
                break;
            default:
                break;
        }
    }

    protected virtual void CheckExp()
    {
        if (exp >= levelUpMargin1 && stage == 0)
        {
            stage++;
            exp -= levelUpMargin1;
            DetermineStackmonStats();
            
            // CHANGE SPRITE INTO NEXT STAGE
        }

        if (exp >= 3 * levelUpMargin1 && stage == 1)
        {
            stage++;
            exp -= 3 * levelUpMargin1;
            DetermineStackmonStats();
            
            // CHANGE SPRITE INTO NEXT STAGE
        }

    }

    protected override void checkInteraction(FTA_CardBaseScript otherCard, bool drop)
    {
        switch (otherCard)
        {
            case FTA_StackmonBase stackmon:
                if (stackmon.CheckAlly())
                {
                    stackmon.GetComponent<SpriteRenderer>().color = Color.green;
                    //do ally stuff
                }
                else
                {
                    stackmon.GetComponent<SpriteRenderer>().color = Color.red;
                    if (drop)
                    {
                        Combat(stackmon);
                    }
                    //do enemy battle stuff
                }

                break;
        }

    }
    
    void Combat(FTA_StackmonBase enemy)
    {
        assumeCombatPosition(enemy);
    }

    void assumeCombatPosition(FTA_StackmonBase enemy)
    {
        float averagePosX = (this.transform.position.x +enemy.transform.position.x)/2;
        float averagePosY =(this.transform.position.y +enemy.transform.position.y)/2;
        enemy.GetComponent<SpriteRenderer>().flipY = true;
        this.transform.position = new Vector3(averagePosX, averagePosY - 1, 0);
        enemy.transform.position = new Vector3(averagePosX, averagePosY + 1, 0);
            
    }

    public void Feeding(int xp)
    {
        this.exp += xp;
        //Debug.Log(this.exp);
    }

    public bool CheckAlly()
    {
        return ally;
    }
}
