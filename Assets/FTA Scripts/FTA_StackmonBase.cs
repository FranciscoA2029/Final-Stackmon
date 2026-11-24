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
    private bool ally;
    
    int hitPoints;
    int attack;
    int exp;
    int stage = 0;
    
    protected override void Start()
    {
        base.Start();

        DetermineStackmonTypeID();
        DetermineStackmonStats();
        CheckExp(); // CHANGE INTO ONLY WHEN GAINING EXP
        //If Hungry Feeding()
        //If collide with NOT-ally Combat()
        //if CheckExp() yes, Evolve()

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
            exp = 0;
            DetermineStackmonStats();
            
            // CHANGE SPRITE INTO NEXT STAGE
        }

        if (exp >= 3 * levelUpMargin1 && stage == 1)
        {
            stage++;
            exp = 0;
            DetermineStackmonStats();
            
            // CHANGE SPRITE INTO NEXT STAGE
        }

    }
    
    void Combat()
    {
        
    }

    void Feeding()
    {
        // If overlap berry
        // exp += berry value
    }

    public bool CheckAlly()
    {
        return ally;
    }
}
