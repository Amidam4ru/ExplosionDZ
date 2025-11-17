using UnityEngine;
using UnityEngine.InputSystem;

public class CubeDetector : MonoBehaviour
{

    [SerializeField] private float _rayLength = 10f;

    private Ray _ray;
    private int _leftMouseId;
    private RaycastHit[] _hits;

    private void Start()
    {
        _leftMouseId = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseId))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            _hits = Physics.RaycastAll(_ray, _rayLength);

            foreach (RaycastHit hit in _hits)
            {
                if (hit.collider.TryGetComponent<Destroyer>(out Destroyer destroyer))
                {
                    destroyer.Explode();

                    break;
                }
            }
        }
    }
}
