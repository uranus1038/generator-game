using UnityEngine;
public class girlPlayer : MonoBehaviour
{
    AnimationControl anim;

    private void Awake()
    {
        this.anim = (AnimationControl)this.GetComponent(typeof(AnimationControl));
    }
    private void Start()
    {
        this.anim.setGenderAnimation("girl");
    }
}