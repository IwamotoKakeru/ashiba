using System;
using System.Runtime.InteropServices;
using UnityEngine;

/// 実装:岩本
namespace Utility
{
    /// <summary>
    /// ゲームオブジェクト用タグ
    /// </summary>
    public static class Tags
    {
        /// <summary>
        /// ゲーム内のキャラクタに用いる
        /// </summary>
        public const string Player = "Player";

        /// <summary>
        /// ゲーム内カーソル
        /// </summary>
        public const string Cursor = "GameController";

        /// <summary>
        /// ホバーのために用いる
        /// </summary>
        [Obsolete("現在ホバーはEventTrigger経由で使用されるため非推奨")] public const string Hover = "Hover";

        /// <summary>
        /// キャラクタが歩く地面や壁等に用いる
        /// </summary>
        public const string Block = "Block";

        /// <summary>
        /// FadeManagerコンポーネントを持つオブジェクトにのみに用いる
        /// </summary>
        public const string Fader = "Fader";
    }

    /// <summary>
    /// シーンのIndex番号
    /// </summary>
    public enum SceneIndex
    {
        Title,
        Turtorial,
        FirstStage,

        // TODO: EndingシーンのインデックスをTurtorialの前に移動させる
        // 今後シーンが増えるとエンディングのIndexもずれてしまうため
        Ending = 10
    }

    public static class Stage
    {
        public static float standardVal = 0.5f;
        /// <summary>
        /// ステージに合うように小数を丸める
        /// </summary>
        /// <param name="value">丸めたい数値</param>
        /// <returns> 小数点以下をstandardValにして返す  </returns>
        public static float RoundNumeric(float value)
        {
            //小数点以下を取り除き、standardValにする
            return Mathf.Floor(value) + standardVal;
        }

        /// <summary>
        /// ステージと揃うようにx,y座標を丸める
        /// </summary>
        /// <param name="originalPos">丸めたい座標</param>
        /// <returns>丸めた座標</returns>
        public static Vector3 GetRoundedPos(Vector3 originalPos)
        {
            Vector3 roundedPos = new Vector3
            {
                x = RoundNumeric(originalPos.x),
                y = RoundNumeric(originalPos.y),
                z = originalPos.z
            };
            return roundedPos;
        }
    }

#if UNITY_WEBGL && !UNITY_EDITOR
    /// <summary>
    /// WebGLビルド向けのUtility
    /// </summary>
    /// <remarks>
    /// ビルドしたものでしか動かないため、使用する際には条件付きコンパイルを使用してエディター上での実行を回避してください
    /// </remarks>
    public static class WebGL
    {
        /// <summary>
        /// タッチできるデバイスかどうかを確認します
        /// </summary>
        /// <returns>真ならタッチ可能</returns>
        [DllImport("__Internal")] public static extern bool CheckTouchDevice();

        /// <summary>
        /// デバイス種別を確認します
        /// </summary>
        /// <returns>デバイス種別の文字列</returns>
        [DllImport("__Internal")] public static extern string GetDeviceType();


        /// <summary>
        /// cookieにクリア回数を書き込みます
        /// </summary>
        [DllImport("__Internal")] public static extern void SetClearTimes(int clearTimes);

        /// <summary>
        /// cookieからクリア回数を読み込みます
        /// </summary>
        /// <returns>クリア回数</returns>
        [DllImport("__Internal")] public static extern int GetClearTimes();
    }
#endif
}
