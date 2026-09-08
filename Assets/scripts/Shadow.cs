using UnityEngine;
using TMPro;    

public class Shadow : MonoBehaviour
{
    public GameObject door;
    public TextMeshPro no;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Box"))
        {
            if(no!=null)
            {
                no.gameObject.SetActive(false);
            }
            if(door!=null)
            {
                door.SetActive(true);
            }
            
        }
        }
        private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Box"))
        {
            if(no!=null)
            {
                no.gameObject.SetActive(true);
            }
            if(door!=null)
            {
                door.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    
}
