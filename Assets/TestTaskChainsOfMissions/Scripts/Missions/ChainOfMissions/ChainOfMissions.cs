using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Missions/ChainOfMissions")]
public class ChainOfMissions : ScriptableObject
{
    [SerializeField] private List<MissionWithStartDelay> _missionsWithStartDelays; 
    public IReadOnlyList<MissionWithStartDelay> MissionsWithStartDelays => _missionsWithStartDelays;

    private void OnValidate() 
    {
        HashSet<Type> seenTypes = new HashSet<Type>();
        for (int i = 0; i < MissionsWithStartDelays.Count; i++)
        {
            BaseMission mission = MissionsWithStartDelays[i].Mission;
            if (mission == null) continue;

            Type type = mission.GetType();
            if (seenTypes.Contains(type))
            {
                Debug.LogWarning($"В цепочке {name} миссия типа {type.Name} добавлена более одного раза. Удалите дубликат.");
                throw new InvalidOperationException();
            }
            else
            {
                seenTypes.Add(type);
            }
        }
    }
}
