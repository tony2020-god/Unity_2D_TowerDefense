using UnityEngine;

public class amo : MonoBehaviour
{
    public float damage = 3f;
    public void Update()
    {
        transform.Translate(10 * Time.deltaTime, 0, 0, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "�Ǫ�")//�I��Ǫ����󪱮a
        {
            other.GetComponent<Enemy>().Damage(damage);//�N�ˮ`�ȶǵ����a
            Destroy(gameObject);
        }
        if (other.tag == "�Ĥ��a")//�I��Ǫ����󪱮a
        {
            other.GetComponent<EnemyBase>().Damage(damage);//�N�ˮ`�ȶǵ����a
            Destroy(gameObject);
        }
    }
}
