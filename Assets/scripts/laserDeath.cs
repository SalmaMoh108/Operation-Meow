using UnityEngine;

public class laserDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.greenPaint == false)
            {
                Meters meters=other.GetComponent<Meters>();
                if(meters!=null){
                meters.GameOver("I told you not to touch the red laser!");
                }
            }
            
        }
    }
}
