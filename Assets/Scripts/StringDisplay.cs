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
    /// 整数を1桁で表示する
    /// </summary>
    /// <param name="displayNum">表示する整数</param>
    public void DisplayInt(int displayNum)
    {
        num = displayNum;
        displayString = num.ToString("0");
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
        //Updateに記述しないと表示されない時があるため保留
        textMesh.text = this.displayString;
    }
}
