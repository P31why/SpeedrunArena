using UnityEngine;
using UnityEngine.UI;

public class PlayerInterect : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] private float _distance;
    [SerializeField] private Camera _camera;
    public Transform crosshair;
    public LayerMask layerMask;
    private GameObject currentItem;
    private void Update()
    {
        RaycastHover();
    }
    public void RaycastHover()
    {
        _ray = _camera.ScreenPointToRay(crosshair.position);
        if (Physics.Raycast(_ray,out _hit,_distance,layerMask))
        {
            Debug.Log(_hit.collider.gameObject.name);
            if (_hit.collider != null)
            {
                GameObject obj = _hit.collider.gameObject;
                if (obj.GetComponent<Outline>() != null)
                {
                    obj.GetComponent<Outline>().enabled = true;
                    currentItem = obj;
                }
            }
        }
        else
        {
            if(currentItem != null)
                currentItem.GetComponent<Outline>().enabled = false;
        }
    }
}
