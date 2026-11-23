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
        //CardType = CardType.Berry;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
