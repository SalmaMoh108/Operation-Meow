using UnityEngine;

public class memory : MonoBehaviour
{
    private static bool startedBefore=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(startedBefore){
            gameObject.SetActive(false);
        }
        else{
            startedBefore=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
