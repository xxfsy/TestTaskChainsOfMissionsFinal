using System;
using UnityEngine;

public class ChainRunner : IDisposable
{
    private readonly ChainOfMissions _chain;
    private readonly ChainOfMissionsView _chainView;

    private BaseMission _currentMission;
    private int _currentIndex = 0;
    private bool _hasCurrentMissionStarted, _hasCurrentMissionFinished;

    private Timer _timer;

    public ChainRunner(ChainOfMissions chain, ChainOfMissionsView chainView)
    {
        _chain = chain;

        _chainView = chainView;
        _chainView.EndMissionButton.onClick.AddListener(FinishMission);

        _timer = new Timer();
    }

    public void StartChain()
    {
        StartMission(_chain.MissionsWithStartDelays[_currentIndex]);
    }

    private void FinishMission() 
    {
        if (_hasCurrentMissionStarted && !_hasCurrentMissionFinished)
            _currentMission.Finish();
    }

    private void StartMission(MissionWithStartDelay missionWithDelay)
    {
        _currentMission = missionWithDelay.Mission;
        _currentMission.OnFinished += () => OnMissionFinished();

        if (missionWithDelay.StartDelay != 0)
        {
            _timer.StartAsync((int)(missionWithDelay.StartDelay * 1000), () => _currentMission.Start());
        }
        else
        {
            _currentMission.Start();
        }

        _hasCurrentMissionStarted = true; // для того чтобы правильно работало завершение миссии по кнопке
        _hasCurrentMissionFinished = false;

        _currentIndex++;
    }

    private void OnMissionFinished()
    {
        _hasCurrentMissionFinished = true; // для того чтобы правильно работало завершение миссии по кнопке
        _hasCurrentMissionStarted = false;

        if (_currentIndex < _chain.MissionsWithStartDelays.Count)
        {
            StartMission(_chain.MissionsWithStartDelays[_currentIndex]);
        }
    }

    public void Dispose()
    {
        _chainView.EndMissionButton.onClick.RemoveListener(FinishMission);
    }
}
