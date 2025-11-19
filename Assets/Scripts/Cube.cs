using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _explosionChancePercent = 100;

    public int ExplosionChancePercent => _explosionChancePercent;

    public void Initialized(int explosionChance, float size)
    {
        _explosionChancePercent = explosionChance;
        transform.localScale = new Vector3(size, size, size);
    }
}
