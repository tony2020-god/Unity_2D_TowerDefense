using UnityEngine;
using System.Collections;
public class EnemyMove : MonoBehaviour
{

    public float speed;
    public LayerMask RoleLayer;
    public bool Stop;
    public float damage;
    public float AttackCD;
    private Animator ani;
    public bool CanAttack;
    public RaycastHit2D hit;
    public float AttackDistance;
    public bool dead;
    public void Start()
    {
        ani = GetComponent<Animator>();
        CanAttack = true;
    }
    /// <summary>
    /// 移動方法
    /// </summary>
    /// 
    private void MoveMethod()
    {
        if (dead == false)
        {
            if (Stop == false)
            {
              transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
            }
        }
           
       
    }

    private void Update()
    {
        MoveMethod();
        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
       
            Vector2 position = transform.position;
            Vector2 direction = Vector2.left;
            float distance = AttackDistance;
            Debug.DrawRay(position, direction, Color.green);
            hit = Physics2D.Raycast(position, direction, distance, RoleLayer);
            if (hit.collider != null)
            {
                if (CanAttack == true)
                {
                    CanAttack = false;
                    ani.SetBool("攻擊", true);
                    Stop = true;
                    yield return new WaitForSeconds(AttackCD);
                   if (hit.collider != null)
                   {
                    if (hit.collider.tag == "我方基地")
                    {
                        hit.collider.GetComponent<AllianceBase>().Damage(damage);
                    }
                    else
                    {
                        hit.collider.GetComponent<Alliance>().Damage(damage);
                    }
                        
                   }
                   CanAttack = true;
                }
            }
            else
            {
                Stop = false;
                ani.SetBool("攻擊", false);
            }
        

    }

}