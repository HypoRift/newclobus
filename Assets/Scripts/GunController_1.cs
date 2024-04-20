using UnityEngine;
using Photon.Pun;
using easyInputs;
public class GunController : MonoBehaviourPunCallbacks
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public bool e;
    public bool spamfirewithlefttrigger;
    bool old;
    bool newe;
    private void Update()
    {
        newe = EasyInputs.GetTriggerButtonDown(EasyHand.RightHand);
        if(old != newe) 
        {
            old = newe;
            if(old == false && newe == false) 
            {
                FireBullet();
            }
           
        }
        if (photonView.IsMine && EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand) && spamfirewithlefttrigger || e)
        {
            e = false;
            FireBullet();
        }
    }


    private void FireBullet()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }

    


}
