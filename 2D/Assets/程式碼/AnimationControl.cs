using UnityEngine;

public class AnimationControl : MonoBehaviour
{
   
    void Update()
    {
        if (LVsave.magiciandead == true && gameObject.layer == LayerMask.NameToLayer("�k��"))
        {
            Destroy(gameObject);
        }

        if (LVsave.icedead == true && gameObject.layer == LayerMask.NameToLayer("���y"))
        {
            Destroy(gameObject);
        }
        if (LVsave.dragonkillerdead == true && gameObject.layer == LayerMask.NameToLayer("�C��"))
        {
            Destroy(gameObject);
        }
    }
}
