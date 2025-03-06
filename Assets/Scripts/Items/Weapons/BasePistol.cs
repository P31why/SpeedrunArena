using UnityEngine;
using Assets.Scripts;

public class BasePistol : MonoBehaviour,IInteractableItem
{
    [SerializeField]
    private GameObject _playerHand;
    private bool inInventory;
    public void Interact()
    {
        inInventory = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.transform.parent = _playerHand.transform;
        gameObject.transform.position = _playerHand.transform.position;
       // gameObject.transform.rotation = _playerHand.transform.rotation;
        gameObject.transform.localRotation =  Quaternion.Euler(Vector3.forward);
    }
    private void Update()
    {
        if(inInventory && Input.GetKeyDown(KeyCode.Q))
        {
            inInventory = false;
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);
        }
    }
}
