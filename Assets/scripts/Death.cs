using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            Meters meter= FindFirstObjectByType<Meters>();
            if(meter!=null)
            {
                
                meter.GameOver("You should't wander around in the dark");
            }
        }
    }
}
