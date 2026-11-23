using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class FTA_StackmonBase : FTA_CardBaseScript
{
    public enum StackType {
        Normal,
        Fire,
        Water,
        Grass
    }

    int nextStackmonType;
    StackType stackmonType;
    private bool ally;
    
    float hitPoints;
    float attack;
    int exp;
    
    protected override void Start()
    {
        base.Start();

        DetermineStackmonTypeID();
        //If Hungry Feeding()
        //If collide with NOT-ally Combat()
        //if CheckExp() yes, Evolve()

    }

    void DetermineStackmonTypeID()
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
    void Combat()
    {
        
    }

    void Feeding()
    {
        
    }

    void CheckExp()
    {
        
    }
    
    void Evolve()
    {
        
    }

    public bool CheckAlly()
    {
        return ally;
    }
}
