using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogue : MonoBehaviour
{
    public float charsPerSecond = 0.2f; //打字時間間隔
    public string[] words; //保存需要顯示的文字
    public int strindex = 0; //控制語句
    public static dialogue instance; //對戰管理實體物件
    private bool isActive = false;
    private float timer = 0; //計時器
    public Text myText;
    public GameObject Dia;
    public int currentPos = 0; //當前打字位置
    public bool islongWriting = false;
    public bool gogame = false;
    public bool end = false;
    public static bool startdia = false;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        if(LVsave.lastLV ==1 && startdia == false)
        {
            string[] wordsText = { "選擇4位傭兵即可出征","右下角有魔物圖鑑和遊戲說明可以觀看"};
            words = wordsText;
        }
        if (LVsave.lastLV == 1 && startdia == true && LVsave.exitdeck == true)
        {
            Dia.SetActive(true);
            string[] wordsText = { "哥布林是最弱的魔物，連我都打得贏","你可別漏氣喔!" };
            words = wordsText;
            Startdia();
        }
        if (LVsave.lastLV == 2 && LVsave.exitdeck == true)
        {
            Dia.SetActive(true);
            string[] wordsText = { "這裡是迷矮森林是蘑菇怪的地盤","蘑菇怪的攻擊力和血量都比哥布林高，千萬別小看他們!" };
            words = wordsText;
            Startdia();
        }
        if (LVsave.lastLV == 3 && LVsave.exitdeck == true)
        {
            Dia.SetActive(true);
            string[] wordsText = { "天氣變得很寒冷了", "看來我們到了火靈巫師的左手「冰龍」的領地","似乎只有槍手特製的槍和屠龍武士能對付他身上的鱗片","屠龍武士就在前方，我們快去幫他", "小心冰龍發射的火球會貫穿所有友軍!" };
            words = wordsText;
            Startdia();
        }
        if (LVsave.lastLV == 4 && LVsave.exitdeck == true)
        {
            Dia.SetActive(true);
            string[] wordsText = { "這裡是火靈巫師的右手「夢魘」的領地", "它的特性就是就算死掉也會無限復活", "必須到火靈巫師的城堡摧毀它的核心才能殺死她","他用他的DNA製造殭屍，而殭屍只會復活一次","還有守衛在後方的骷髏戰士","這裡到處充滿絕望...." };
            words = wordsText;
            Startdia();
        }
        if (LVsave.lastLV == 5 && LVsave.exitdeck == true)
        {
            Dia.SetActive(true);
            string[] wordsText = { "終於來到火靈巫師的大本營", "所有怪物都聽他指揮，打敗他一切都結束了!" ,"主堡中有火靈巫師的徒弟在幫他護城","閃電的威力驚人，要先想辦法處理他...","夢魘還在後面追我們，必須趁她參戰之前摧毀主堡","時間緊迫，趕緊行動吧!" };
            words = wordsText;
            Startdia();
        }
        timer = 0;
    }
    
    public void Update()
    {
      if(LVsave.exitdeck == true || startdia == false)
        {
            OnStartWriter();
            if (Input.GetMouseButtonDown(0))
            {
                if (end == false)
                {
                    myText.text = words[strindex];
                    OnFinish();
                }
                else
                {
                    timer = 0;
                    currentPos = 0;
                    strindex++; //下一句
                    isActive = true;
                    end = false;
                    if (strindex >= words.Length) //防止超出字串的長度
                    {
                        strindex = 0;
                        Dia.SetActive(false);
                        startdia = true;
                        gogame = true;
                    }
                }
            }
        }       
    }

    public void StartEffect()
    {
        isActive = true;
    }
    public void Startdia()
    {
        timer = 0;
        currentPos = 0;
        strindex = 0;
        isActive = true;
    }
    /// 打字
    public void OnStartWriter()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            { //判断計時器時間是否到達
                if(end == false)
                {
                    timer = 0;
                    currentPos++;
                    myText.text = words[strindex].Substring(0, currentPos); //刷新文本顯示内容
                    if (currentPos >= words[strindex].Length)
                    {
                        OnFinish();
                    }
                }           
            }
        }
    }
    /// 結束打字，初始化數據
    public void OnFinish()
    {
        isActive = false;
        end = true;
        timer = 0;
        currentPos = 0;
    }
}