using UnityEngine;

/// <summary>
/// ゲーム内で文字列を表示するオブジェクト
/// </summary>
public class StringDisplay : MonoBehaviour
{
    private TextMesh textMesh;
    private int num;
    private string displayString;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    /// <summary>
    /// 数字を1桁で表示
    /// </summary>
    /// <param name="displayNum">表示する数字</param>
    /// <param name="colorString">数字の色、デフォルトでは白</param>
    public void DisplayInt(int displayNum, string colorString = "FFFFFF")///Color型を初期値にできないため暫定措置
    {
        num = displayNum;
        displayString = $"<color=#{colorString}>{num:0}</color>";
    }

    /// <summary>
    /// 文字列を表示する
    /// </summary>
    /// <param name="displayNum">表示する文字列</param>
    public void DisplayString(string displayString)
    {
        this.displayString = displayString;
    }

    void Update()
    {
        //TODO: Updateだと負荷がかかるので修正
        //Updateに記述しないと正常に表示されない時があるが負荷が深刻でないため保留
        textMesh.text = this.displayString;
    }
}
