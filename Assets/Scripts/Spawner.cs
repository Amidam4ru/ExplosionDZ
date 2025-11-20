using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int minCubeNumber = 2;
    [SerializeField] private int maxCubeNumber = 6;

    private List<Cube> _newCubes;

    public List<Cube> NewCubes => _newCubes;

    private void Start()
    {
        _newCubes = new List<Cube>();
    }

    public void CreateCubes(int explosionChance, Vector3 position, float size, float explosionForce, float explotionRadius)
    {
        _newCubes.Clear();
        int cubesNumber = Random.Range(minCubeNumber, maxCubeNumber + 1);

        for (int i = 0; i < cubesNumber; i++)
        {
            Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity);
            cube.Initialized(explosionChance, size, explosionForce, explotionRadius);
            _newCubes.Add(cube);
        }
    }
}
