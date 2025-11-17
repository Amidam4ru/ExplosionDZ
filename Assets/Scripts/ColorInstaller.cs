using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class ColorInstaller : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = new Material(_renderer.material);
        _renderer.material.color = Random.ColorHSV();
    }
}
