# ashiba

## アシバ

[![FchdptgaUAA1l_0](https://github.com/IwamotoKakeru/IwamotoKakeru/assets/34148721/9afd7be7-41c9-455d-8e80-bb27a1d99ff4)](https://unityroom.com/games/asiba)

## 概要

キャラクターをアシバにしてゴールに"ためる"ゲームです

対応デバイス：PC、スマートフォン

この作品は Unity1 週間ゲームジャムお題「ためる」へ投稿された作品を現在進行形で改良しているものです

[このイベントでの結果: 27/338 位, 楽しさ 14/338 位, 斬新さ 27/338 位](https://unityroom.com/unity1weeks/56/top)

## リンク

### UnityRoom ゲームリンク

https://unityroom.com/games/asiba

- 動作確認が取れたものはこちらへ挙げていきます

- クリア時間を競えるランキング機能があります

### 開発段階ゲームリンク(GitHub Pages)

https://iwamotokakeru.github.io/ashiba/WebGL/WebGL/

- 開発段階のビルドであるため、正常に動作しない可能性があります

### レポジトリ URL

https://github.com/IwamotoKakeru/ashiba

### 説明動画

https://youtu.be/tmGpFDHXRWc

## 使用技術

Unity 2022.3.6f1 (2024/2/9 より)

Plastic SCM(2022/2 まで), GitHub(2022/2 から), GitHub Actions

Plastic SCM のレポジトリと GitHub レポジトリを同期させているため、双方のコミット履歴を保持しています。

## 環境構築

### Unity

- UnityHub をダウンロード
  https://unity.com/ja/download

- unity 2022.3.6f1 と WebGL Support をダウンロード
  https://unity.com/releases/editor/whats-new/2022.3.6

- このレポジトリをクローンし、UnityHub から開く

- Game 画面の解像度を 960x540 に設定

## 開発方針

### 開発フロー

1. issue 作成（無しでも可）
2. develop からブランチを切る
3. 実装・プッシュ
4. プルリクエスト作成
5. CI によるビルドチェック
6. デプロイ先での動作確認
7. コードレビュー
8. マージ

### 留意事項

- コミットメッセージは可能な限り Angular Commit Format に従ってください
- develop ブランチ向けの PR を出した際に Actions でビルドが走り、完了次第デプロイされます
- develop にマージされた際に unityroom 向けのビルドファイルが生成されます
