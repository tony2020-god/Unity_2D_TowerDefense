using UnityEngine;

public class FireStone : MonoBehaviour
{
    public float damage = 5f;
    public string type;

    public void Update()
    {
        transform.Translate(-5 * Time.deltaTime, 0, 0, Space.World);
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
    public void Start()
    {
        Invoke("destoryob", 10);
    }
    public void destoryob()
    {
        Destroy(gameObject);
    }
}