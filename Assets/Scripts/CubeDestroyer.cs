using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private CubeDetector _cubeDetector;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private int _degreeExplosionReduction;
    private int _degreeSize;

    private void Start()
    {
        _degreeExplosionReduction = 2;
        _degreeSize = 2;
    }

    private void OnEnable()
    {
        _cubeDetector.CubeDetected += Crush;
    }

    private void OnDisable()
    {
        _cubeDetector.CubeDetected -= Crush;
    }

    public void Crush(Cube cube)
    {
        int minExplosionChance = 0;
        int maxExplosionChance = 100;

        if (Random.Range(minExplosionChance, maxExplosionChance + 1) < cube.ExplosionChancePercent)
        {
            _spawner.CreateCubes(cube.ExplosionChancePercent / _degreeExplosionReduction, cube.transform.position, cube.transform.localScale.x / _degreeSize);
            _exploder.BlowUp(cube.gameObject.transform.position, _spawner.NewCubes);
        }

        Destroy(cube.gameObject);
    }
}
