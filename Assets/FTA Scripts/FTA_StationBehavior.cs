using UnityEngine;

public class FTA_StationBehavior : FTA_CardBaseScript
{
    public enum stationType
    {
        BerryBush,
        Trap
    }

    stationType stationID;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        stationID = stationType.BerryBush;
        base.Start();
        
        //IF INTERACTED WITH!!!
        DoStationFunction();
    }

    void DoStationFunction()
    {
        switch (stationID)
        {
            case stationType.BerryBush:
                // CREATE A BERRY AND RUN ITS DETERMINE ID FUNCTION!
                break;
            case stationType.Trap:
                // Wait X time, then summon !ally stackmon.
                break;
            default:
                break;
        }
    }
}
