using UnityEngine;

public class เหรียญ : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip pickupSound;
    public GameObject pickupEffectPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.AddScore(coinValue);
            }

            // เล่นเสียง
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // สร้างเอฟเฟกต์
            if (pickupEffectPrefab != null)
            {
                Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // ลบเหรียญ
        }
    }
    
    
}
