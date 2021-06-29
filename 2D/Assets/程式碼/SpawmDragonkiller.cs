
using UnityEngine;

public class SpawmDragonkiller : MonoBehaviour
{
    public GameObject dragonkiller;
    public bool dragonkillerspawn = false;

     public void Update()
    {
       if( dialogue.instance.gogame == true && dragonkillerspawn == false)
        {
            spawndragonkill();
        }    
    }
    public void spawndragonkill()
    {
        dragonkillerspawn = true;
        Vector3 pos = new Vector2(-60f, -2.3f); //�y��
        Quaternion qua = Quaternion.Euler(0, 0, 0); //����
        GameObject temp = Instantiate(dragonkiller, pos, qua); //�ͦ�
        temp.gameObject.GetComponent<RoleMove>().speed = 2; //�K�[����<���Ͳ���> �t�� = �d�P.�t��
        temp.gameObject.GetComponent<RoleMove>().damage = 3; //�K�[����<���Ͳ���>.�ˮ` = �d�P.����
        temp.gameObject.GetComponent<RoleMove>().AttackCD = 3; //�K�[����<���Ͳ���>.�����t�� = �d��.�����t��
        temp.gameObject.GetComponent<RoleMove>().AttackDistance = 1; //�K�[����<���Ͳ���>.�����Z�� = �d��.�����Z��
        temp.gameObject.GetComponent<Alliance>().hp = 30; //�K�[����<����>.��q = �d��.��q
    }
}
