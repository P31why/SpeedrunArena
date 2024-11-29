using UnityEngine;
using UnityEngine.UI;

public class PlayerInterect : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _distance;
    [SerializeField] private Camera _camera;
    public Image crosshair;
    public LayerMask layerMask;
    private void Update()
    {
        RaycastInterect();
    }
    private void RaycastInterect()
    {
        _ray = _camera.ScreenPointToRay(crosshair.transform.position);
        if (Physics.Raycast(_ray,out _hit,_distance,layerMask))
        {
            Debug.Log(_hit.collider.gameObject.name);
            if (_hit.collider != null)
            {
                GameObject obj = _hit.collider.gameObject;
                if (obj.GetComponent<Outline>() != null)
                {
                    obj.GetComponent<Outline>().enabled = true;
                }
                else obj.GetComponent<Outline>().enabled = false;
            }
            else
            {
                Debug.Log("no");
            }
        }
    }
}
