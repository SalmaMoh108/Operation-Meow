using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed=3f;
    int currentIndex=0;
    private Animator animator;
    private void Start()
    {
        animator=GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("cat run");
        }
    }

    void Update()
    {
       if(waypoints.Length==0) return;
       Transform target=waypoints[currentIndex];

       //move it little by little every frame
       transform.position=Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);

        //flip cat
        if (target.position.x > transform.position.x)
        {   //move right
            transform.localScale=new Vector3(-Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }

        //move left
        else if (target.position.x < transform.position.x)
        {
            transform.localScale=new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
        if (Mathf.Abs(transform.position.x - target.position.x) < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex=0;
            }
        }
    }
}
