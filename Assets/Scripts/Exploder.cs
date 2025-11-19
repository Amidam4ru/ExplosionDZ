using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 100f;
    [SerializeField] private float _radius = 50f;

    public void BlowUp(Vector3 position, List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_force, position, _radius);
            }
        }
    }
}
