using UnityEngine;

public class FTA_BerryBushBehavior : FTA_CardBaseScript
{
    int berryBushHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        berryBushHealth = 3;
        base.Start();
    }
    
}
