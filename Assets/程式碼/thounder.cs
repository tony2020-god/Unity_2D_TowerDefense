using UnityEngine;
using System.Collections.Generic;
using System.Collections;//�ޥΨt�ζ��X�B�޲zAPI(��P�{��:�D�P�B�B�z)

public class thounder : MonoBehaviour
{
    public float damage = 5f;
    public string type;

    public void Start()
    {
        StartCoroutine(keep1sec());
    }
    public IEnumerator keep1sec()
    {
        yield return new WaitForSeconds(1f);
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