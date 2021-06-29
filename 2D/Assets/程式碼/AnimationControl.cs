using UnityEngine;

public class AnimationControl : MonoBehaviour
{
   
    void Update()
    {
        if (LVsave.magiciandead == true && gameObject.layer == LayerMask.NameToLayer("¹k¥Û"))
        {
            Destroy(gameObject);
        }

        if (LVsave.icedead == true && gameObject.layer == LayerMask.NameToLayer("¤õ²y"))
        {
            Destroy(gameObject);
        }
        if (LVsave.dragonkillerdead == true && gameObject.layer == LayerMask.NameToLayer("¼C®ð"))
        {
            Destroy(gameObject);
        }
    }
}
