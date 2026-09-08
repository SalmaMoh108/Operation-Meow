using UnityEngine;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Meters meters=other.GetComponent<Meters>();
            if(meters!=null)
            {
                meters.danger=true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Meters meters=other.GetComponent<Meters>();
            if(meters!=null)
            {
                meters.danger=false;
            }
        }
    }
}
