﻿using System;

namespace Constants
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
        [ObsoleteAttribute("現在ホバーはEventTrigger経由で使用されるため非推奨")] public const string Hover = "Hover";

        /// <summary>
        /// キャラクタが歩く地面や壁等に用いる
        /// </summary>
        public const string Block = "Block";
    }
}