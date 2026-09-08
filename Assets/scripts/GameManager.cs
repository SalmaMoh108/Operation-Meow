using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool doubleJump=false;   //tutorial
    public bool greenPaint=false;   //puzzle B
    private void Awake() 
    {
        if(instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UnlockDoubleJump()
    {
        doubleJump=true;
    }
    public void RevokeDoubleJump()
    {
        doubleJump=false;
    }
    public void LaserHack()
    {
        greenPaint=true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
