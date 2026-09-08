using UnityEngine;

public class Swap : MonoBehaviour
{
    public GameObject cat;
    public GameObject exit;
    public GameObject prefab;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Human"))
        {
            if(cat!=null)
            {
                cat.SetActive(false);
            }
            Destroy(other.gameObject);
            if(prefab!=null)
            {
                prefab.SetActive(true);
            }
            if(exit!=null)
            {
                exit.SetActive(true);
            }
            
        }
    }
}
