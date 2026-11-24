using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.VersionControl;
using UnityEngine;

public class FTA_BerryBase : FTA_CardBaseScript
{
    public enum BerryType
    {
        Occa, Pasho, Rindo, Chilan
    }

    int randomBerry;
    BerryType myID;
    int berryValue;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        DetermineBerryID();
        DetermineBerryValue();
    }
    
    protected override void Update()
    {
        base.Update();
    }

    void DetermineBerryID()
    {
        randomBerry = Random.Range(0, 3);
        switch (randomBerry)
        {
            case 0:
                myID = BerryType.Occa;
                break;
            case 1:
                myID = BerryType.Pasho;
                break;
            case 2:
                myID = BerryType.Rindo;
                break;
            case 3:
                myID = BerryType.Chilan;
                break;
            default:
                break;
        }
        
    }

    void DetermineBerryValue()
    {
        berryValue = Random.Range(15, 25);
    }
    protected override void checkInteraction(FTA_CardBaseScript otherCard, bool drop)
    {
        switch (otherCard)
        {
            case FTA_StackmonBase stackmon:
            {

                if (stackmon.CheckAlly())
                {
                    stackmon.GetComponent<SpriteRenderer>().color = Color.green;
                    if (drop)
                    {
                        stackmon.Feeding(berryValue);
                    }
                }

                break;
            }

        }
    }
}
