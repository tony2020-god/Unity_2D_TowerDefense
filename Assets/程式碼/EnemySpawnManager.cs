using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("生成資料")]
    public EnemySpawnData data;

    private BattleManager bm;
    public bool pass;
    private void Start()
    {
        bm = FindObjectOfType<BattleManager>();
        StartCoroutine(StartSpawn());
    }
    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);
          for (int j = 0; j < data.spawn[i].monsters.Length; j++)
            {
               Vector3 pos = new Vector3(data.spawn[i].monsters[j].x, data.spawn[i].monsters[j].y, 0); //座標
                Quaternion qua = Quaternion.Euler(0, 180, 0); //角度
                GameObject temp = Instantiate(data.spawn[i].monsters[j].monster, pos, qua); //生成
            }
        }
    }
}