using UnityEngine;
using System.Collections.Generic;
using System.Collections;//�ޥΨt�ζ��X�B�޲zAPI(��P�{��:�D�P�B�B�z)
public class explotion : MonoBehaviour
{ 
    public float damage = 50f;
    public string type;

    public void Start()
    {
        StartCoroutine(keep5sec());
    }

    public IEnumerator keep5sec()
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "�ڤ訤��")//�I��Ǫ����󪱮a
        {
            other.GetComponent<Alliance>().Damage(damage);//�N�ˮ`�ȶǵ����a
        }
        if (other.tag == "�ڤ��a")//�I��Ǫ����󪱮a
        {
            other.GetComponent<AllianceBase>().Damage(damage);//�N�ˮ`�ȶǵ����a
        }
    }
}

