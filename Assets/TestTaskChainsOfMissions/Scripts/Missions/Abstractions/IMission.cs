using System;

public interface IMission 
{
    public event Action OnStarted;
    public event Action OnMissionPointReached;
    public event Action OnFinished;

    public void Start();
    public void MissionPointReach();
    public void Finish();
}
