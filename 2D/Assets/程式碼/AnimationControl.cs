using UnityEngine;
using UnityEngine.UI;
using System.Collections;//�ޥΨt�ζ��X�B�޲zAPI(��P�{��:�D�P�B�B�z)

public class AnimationControl : MonoBehaviour
{

    public void Start()
    {
        if (gameObject.layer == LayerMask.NameToLayer("�k���z��"))
        {
            StartCoroutine(DESOB());
        }
    }
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
    public IEnumerator DESOB()
    {
       yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
