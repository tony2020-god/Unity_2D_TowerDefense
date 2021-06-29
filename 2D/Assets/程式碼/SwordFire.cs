using UnityEngine;

public class SwordFire : MonoBehaviour
{

    public float damage = 3f;
    public string type;

    public void Update()
    {
        transform.Translate(5 * Time.deltaTime, 0, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "�Ǫ�")//�I��Ǫ����󪱮a
        {
            other.GetComponent<Enemy>().Damage(damage);//�N�ˮ`�ȶǵ����a

        }
        if (other.tag == "�Ĥ��a")//�I��Ǫ����󪱮a
        {
            other.GetComponent<EnemyBase>().Damage(damage);//�N�ˮ`�ȶǵ����a
        }
        if (other.tag == "�B�s")//�I��Ǫ����󪱮a
        {
            other.GetComponent<Enemy>().Damage(damage);//�N�ˮ`�ȶǵ����a

        }
    }
    public void Start()
    {
        Invoke("destoryob", 10);
    }
    public void destoryob()
    {
        Destroy(gameObject);
    }

}