using UnityEngine;
using System.Collections.Generic;
using System;

public class ChainsOfMissionsManager : MonoBehaviour
{
    [SerializeField] private ChainOfMissions[] _chainsOfMissions;
    [SerializeField] private ChainOfMissionsView _chainOfMissionsViewPrefab;
    private GameObject _rootForChainOfMissionsViews;
    private List<IDisposable> _activeChainRunners = new List<IDisposable>(); 

    public void Initialize(GameObject rootForChainOfMissionsViews) 
    {
        _rootForChainOfMissionsViews = rootForChainOfMissionsViews;

        StartChainsOfMissions();
    }

    private void StartChainsOfMissions()
    {
        for (int i = 0; i < _chainsOfMissions.Length; i++) 
        {
            ChainOfMissions chain = _chainsOfMissions[i];

            ChainOfMissionsView chainView = Instantiate(_chainOfMissionsViewPrefab, _rootForChainOfMissionsViews.transform);
            chainView.Initialize(i.ToString());

            ChainRunner runner = new ChainRunner(chain, chainView);
            _activeChainRunners.Add(runner);
            runner.StartChain();
        }
    }

    private void OnDestroy()
    {
        foreach(IDisposable chainRunner in _activeChainRunners)
        {
            chainRunner.Dispose();
        }
    }
}
