using UnityEngine;

public class MeteoriteBall : MonoBehaviour
{
    
    public float damage = 20f;
    public string type;

    public void Update()
    {
        transform.Translate(0, -4 * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "�Ǫ�")//�I��Ǫ����󪱮a
        {
            print("�k�ۯ{��H�F");
            other.GetComponent<Enemy>().Damage(damage);//�N�ˮ`�ȶǵ����a

        }
        if (other.tag == "�Ĥ��a")//�I��Ǫ����󪱮a
        {
            other.GetComponent<EnemyBase>().Damage(damage);//�N�ˮ`�ȶǵ����a
        }
    }
}
