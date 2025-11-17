using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Destroyer : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _explosionChancePercent = 100f;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private float _explosionRadius = 3f;

    private int _minCubeNumber;
    private int _maxCubeNumber;
    private int _degreeSizeReduction;
    private int _degreeReductionChanceExplosion;

    private void Awake()
    {
        _minCubeNumber = 2;
        _maxCubeNumber = 6;
        _degreeSizeReduction = 2;
        _degreeReductionChanceExplosion = 2;
    }

    public void Explode()
    {
        int minExplosionChance = 0;
        int maxExplosionChance = 100;

        if (Random.Range(minExplosionChance, maxExplosionChance + 1) <= _explosionChancePercent)
        {
            SpawnCubes();
        }

        Destroy(gameObject);
    }

    public void Initialize(float explosionChance, Vector3 scale)
    {
        _explosionChancePercent = explosionChance;
        transform.localScale = scale;
    }

    private void SpawnCubes()
    {
        int cubesNumber = Random.Range(_minCubeNumber, _maxCubeNumber + 1);
        float newExplosionChance = _explosionChancePercent / _degreeReductionChanceExplosion;
        Vector3 newScale = transform.localScale / _degreeSizeReduction;

        for (int i = 0; i < cubesNumber; i++)
        {
            Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            cube.transform.localScale = newScale;

            if (cube.TryGetComponent(out Destroyer destroyer))
            {
                destroyer.Initialize(newExplosionChance, newScale);
            } 
        }

        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        for (int j = 0; j < overlappedColliders.Length; j++)
        {
            Rigidbody rigidbody = overlappedColliders[j].attachedRigidbody;

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
