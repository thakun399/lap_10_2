using UnityEngine;

public class เหรียญ : MonoBehaviour
{
    public int coinValue = 1;
    public AudioClip pickupSound;           // ใส่เสียงตรงนี้
    public GameObject pickupEffectPrefab;   // ใส่พาร์ติเคิลตรงนี้

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.AddScore(coinValue);
                if (player != null)
                {
                    player.AddScore(coinValue);

                    // เพิ่มคะแนนใน UI
                    ScoreManager.instance.AddScore(coinValue);
                }
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
        
        if (other.CompareTag("Player"))
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.AddScore(coinValue);
            }

            // เล่นเสียง (คุณมีอยู่แล้ว)

            // ✨ สร้างเอฟเฟกต์
            if (pickupEffectPrefab != null)
            {
                Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);
            }

            Destroy(gameObject); // เหรียญหาย
        }
      
    }
    
}
