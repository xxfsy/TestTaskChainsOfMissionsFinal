using UnityEngine;

[System.Serializable] 
public class MissionWithStartDelay 
{
    [field: SerializeField] public BaseMission Mission { get; private set; }

    [field: SerializeField, Min(0)] 
    public float StartDelay { get; private set; }
}
