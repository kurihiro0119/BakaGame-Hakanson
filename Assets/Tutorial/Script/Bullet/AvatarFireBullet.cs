using Photon.Pun;
using UnityEngine;

public class AvatarFireBullet : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Bullet bulletPrefab = default;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                var direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);

                photonView.RPC(nameof(FireBullet), RpcTarget.All, angle);
            }
        }
    }

    [PunRPC]
    private void FireBullet(float angle)
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.Init(transform.position, angle);
    }
}
