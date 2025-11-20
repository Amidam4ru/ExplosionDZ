using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private CubeDetector _cubeDetector;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    

    private int _degreeExplosionReduction;
    private int _degreeSize;
    private int _degreeExplosionRadius;
    private int _degreeExplosionForce;

    private void Start()
    {
        _degreeExplosionReduction = 2;
        _degreeSize = 2;
        _degreeExplosionRadius = 2;
        _degreeExplosionForce = 2;
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
            _spawner.CreateCubes(cube.ExplosionChancePercent / _degreeExplosionReduction, cube.transform.position, cube.transform.localScale.x / _degreeSize, cube.ExplosionForce / _degreeExplosionForce, cube.ExplotionRadius / _degreeExplosionRadius);
            _exploder.BlowUp(cube.gameObject.transform.position, _spawner.NewCubes);
        }
        else
        {
            _exploder.BlowUpEnvironment(cube.transform.position, cube.ExplotionRadius, cube.ExplosionForce);
        }

        Destroy(cube.gameObject);
    }
}
