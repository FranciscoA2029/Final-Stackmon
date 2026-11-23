using System.Security.Cryptography;
using UnityEditor.VersionControl;
using UnityEngine;

public class FTA_BerryBase : FTA_CardBaseScript
{
    public enum BerryType {
        Occa,
        Pasho,
        Rindo,
        Chilan
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        
        //randomBerryType.Next(1,4);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
