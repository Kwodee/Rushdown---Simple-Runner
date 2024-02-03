using UnityEngine;

public class ObstacleAnime : MonoBehaviour
{
    public Animator anim;
    private float stopcode;
    
    void Update()
    {
        stopcode = GameControl.stopcode;

        if (stopcode == 1)
        {
            anim.SetBool("ded", true);
        }
        else
            anim.SetBool("ded", false);
    }
}
