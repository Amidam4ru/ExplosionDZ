using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _explosionChancePercent = 100;
    [SerializeField] private float _explotionRadius = 100;
    [SerializeField] private float _explosionForce = 500;

    public int ExplosionChancePercent => _explosionChancePercent;
    public float ExplosionForce => _explosionForce;
    public float ExplotionRadius => _explotionRadius;

    public void Initialized(int explosionChance, float size, float explosionForce, float explotionRadius)
    {
        _explosionChancePercent = explosionChance;
        _explosionForce = explosionForce;
        _explotionRadius = explotionRadius;
        transform.localScale = new Vector3(size, size, size);
    }
}
