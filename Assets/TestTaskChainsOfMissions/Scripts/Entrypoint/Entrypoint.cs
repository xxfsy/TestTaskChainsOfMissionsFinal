using UnityEngine;

public class Entrypoint : MonoBehaviour
{
    [SerializeField] private ChainsOfMissionsManager _chainsOfMissionsManagerPrefab;
    [SerializeField] private GameObject _rootForChainOfMissionsViews;

    private void Awake()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        ChainsOfMissionsManager chainsOfMissionsManager = Instantiate(_chainsOfMissionsManagerPrefab);
        chainsOfMissionsManager.Initialize(_rootForChainOfMissionsViews);
    }
}
