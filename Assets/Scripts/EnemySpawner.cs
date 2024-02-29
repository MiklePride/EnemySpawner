using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private Transform _parentTargetPoint;

    private Transform _enemySpawner;
    private Transform[] _enemySpawnPoints;
    private Transform[] _targetPoints;
    private Vector3 _spawnPosition;
    private float _pauseDuration = 2f;

    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _enemySpawner = GetComponent<Transform>();
    }

    private void Start()
    {
        GetListChildrenPositions(_parentTargetPoint, out _targetPoints);
        GetListChildrenPositions(_enemySpawner, out _enemySpawnPoints);

        _spawnCoroutine = StartCoroutine(InitializeSpawn());
    }

    private IEnumerator InitializeSpawn()
    {
        var twoSeconds = new WaitForSeconds(_pauseDuration);

        while (true)
        {
            _spawnPosition = _enemySpawnPoints[GetRandomIndex(_enemySpawnPoints)].position + Vector3.up;
            Enemy enemy = Instantiate(_enemyTemplate, _spawnPosition, Quaternion.identity);
            SetTargetPoint(enemy);

            yield return twoSeconds;
        }
    }

    private void SetTargetPoint(Enemy Enemy)
    {
        Enemy.GetTargetPoint(_targetPoints[GetRandomIndex(_targetPoints)]);
    }

    private void GetListChildrenPositions(Transform parentObject, out Transform[] childrenPositions)
    {
        childrenPositions = new Transform[parentObject.childCount];

        for (int i = 0; i < childrenPositions.Length; i++)
        {
            childrenPositions[i] = parentObject.GetChild(i);
        }
    }

    private int GetRandomIndex(Transform[] transforms)
    {
        int index = Random.RandomRange(0, transforms.Length);

        return index;
    }
}
