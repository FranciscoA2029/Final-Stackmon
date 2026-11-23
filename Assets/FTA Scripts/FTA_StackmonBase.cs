using UnityEngine;

public class FTA_StackmonBase : FTA_CardBaseScript
{
    public enum StackType {
        Normal,
        Fire,
        Water,
        Grass
    }

    private bool ally;
    
    float hitPoints;
    float attack;
    int exp;
    
    
    
    protected override void Start()
    {
        base.Start();
        //If Hungry Feeding()
        //If collide with NOT-ally Combat()
        //if CheckExp() yes, Evolve()

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
