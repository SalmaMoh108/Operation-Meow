using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio instance;
    private void Awake() {
        //avoid duplicates overlapping
        if(instance!=null && instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        //set the instance to this object and make it persist across scenes
        instance=this;
        DontDestroyOnLoad(gameObject);
    }
}
