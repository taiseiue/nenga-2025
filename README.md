# 年賀状2025 おみくじサイト

## これは何
2025年のお正月に年賀状に貼っておいたQRコードを読み取るとこのサイトに繋がるよ。あらかじめ出した年賀状を登録して、くじも登録しておくと年賀状を受け取った人が抽選番号を入力することでくじ引きできるよ。

## 使っているもの

- ASP.NET Core 8.0
- Bootstrap
- Docker Compose
- Cloudflare Tunnel

## どうやって動かすの

Docker composeで動きます。

```sh
$ docker compose build
```

### 1. DBの準備
データベースを自分で作ってくれる機能はないので、先にdbを建ててデータベースとテーブルを作る必要があります。

```sh
$ docker compose up db
```

データベースには`1434`ポートで接続できます。

**年賀状テーブル**

```sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Lot] [int] NULL,
	[OpenedAt] [datetime2](7) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PostCards] ADD  CONSTRAINT [PK_PostCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
```

**おみくじテーブル**

```sql
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lots](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[GiftUrl] [nvarchar](max) NULL,
	[OpenedAt] [datetime2](7) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Lots] ADD  CONSTRAINT [PK_Lots] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
```

#### 2. サーバーを建てる
後はサーバーを立ててやりましょう。

```sh
$ docker compose up
```

#### Opt. CF Tunnelで公開する

公開にCloudflare Tunnelを使っています。これを使う場合は適当にトークンを取ってきて、以下の内容で.envファイルを書きましょう。

```txt
CF_TUNNEL_TOKEN=<CF TUnnelのトークン>
```

後は、`public`プロファイルでdocker compose upします。

```txt
$ docker compose --profile up
```

## ライセンス
MITライセンスで公開します。詳しくは[LICENSE](./LICENSE)を参照のこと。
何かあれば[@taiseiue](https://x.com/taiseiue)まで。
