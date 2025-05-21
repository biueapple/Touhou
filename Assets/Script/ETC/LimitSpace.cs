using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LimitSpace : MonoBehaviour
{
    private BoxCollider box;
    private Player_Ship ship;

    private void Start()
    {
        box = GetComponent<BoxCollider>();
        ship = Player.Instance.Ship;
    }

    private void Update()
    {
        if (box == null)
            return;
        ship.transform.position = new Vector3(Mathf.Clamp(ship.transform.position.x, box.center.x - box.size.x * 0.5f, box.center.x + box.size.x * 0.5f),
                                                   Mathf.Clamp(ship.transform.position.y, box.center.y - box.size.y * 0.5f, box.center.y + box.size.y * 0.5f));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            ObjectPooling.Instance.DestroyBullet(bullet);
        }
        else if (other.TryGetComponent(out Item item))
        {
            item.gameObject.SetActive(false);
        }
    }
}
