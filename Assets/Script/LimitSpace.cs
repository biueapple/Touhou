using UnityEngine;

public class LimitSpace : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            ObjectPooling.Instance.DestroyBullet(bullet);
        }
        else if(other.TryGetComponent(out Item item))
        {
            item.gameObject.SetActive(false);   
        }
    }
}
