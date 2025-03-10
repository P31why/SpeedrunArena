using Assets.Scripts;
using UnityEngine;

public class AK74 : MonoBehaviour, IEquipbleItem, IGun
{
    [SerializeField]
    private GameObject _playerHand;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _shootpoint;
    [SerializeField]
    private float _shootForce;
    [SerializeField]
    private float _fireRate;

    [SerializeField]
    private float _timeToShoot=0;

    public void Equip()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic=true;
        gameObject.transform.parent = _playerHand.transform;
        gameObject.transform.position=_playerHand.transform.position;
        gameObject.transform.rotation = _playerHand.transform.rotation;
    }
    public void Drop()
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().AddForce(-_playerHand.transform.forward * 5, ForceMode.Impulse);
    }
    public void Shoot()
    {

        if (Time.time >= _timeToShoot)
        {
            _timeToShoot = Time.time + 1f / _fireRate;
            GameObject bulletObj = Instantiate(_bullet, _shootpoint.position, Quaternion.identity);
            bulletObj.GetComponent<Rigidbody>().AddForce(_shootpoint.forward * _shootForce, ForceMode.Force);
        }
    }
}
