using Assets.Scripts;
using UnityEngine;

public class AK74 : MonoBehaviour, IInteractableItem
{
    [SerializeField]
    private GameObject _playerHand;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shootpoint;
    [SerializeField]
    private float _shootForce;
    private bool inInventory;
    public void Awake()
    {
        inInventory = false;
    }
    public void Interact()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic=true;
        gameObject.transform.parent = _playerHand.transform;
        gameObject.transform.position=_playerHand.transform.position;
        gameObject.transform.rotation = _playerHand.transform.rotation;
        inInventory = true;
    }
    private void Update()
    {
        if (inInventory && Input.GetKeyDown(KeyCode.Q))
        {
            inInventory = false;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().AddForce(-_playerHand.transform.forward*5,ForceMode.Impulse);
        }
        else if (inInventory && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bulletObj=Instantiate(_bullet, _shootpoint.position,Quaternion.identity);
        bulletObj.GetComponent<Rigidbody>().AddForce(_shootpoint.forward*_shootForce,ForceMode.Impulse);
        
    }
}
