using System;
using UnityEngine;

public abstract class BaseMission : ScriptableObject, IMission
{
    protected const string basePath = "ScriptableObject/Missions/MissionsConfigs/";

    [SerializeField] private string _missionName;

    public event Action OnStarted;
    public event Action OnMissionPointReached;
    public event Action OnFinished;

    public virtual void Start()
    {
        Debug.Log(_missionName + " has started");

        OnStarted?.Invoke();
    }

    public virtual void MissionPointReach()
    {
        Debug.Log(_missionName + " Mission Point has reached");

        OnMissionPointReached?.Invoke();
    }

    public virtual void Finish()
    {
        Debug.Log(_missionName + " has finished");

        OnFinished?.Invoke();
    }
}