# JSON変換ライブラリ

## はじめに
C#でJSON変換を簡単に実装できる簡易ライブラリです。

## 実行環境
* .NET 6  

## 利用方法
拡張メソッドとして実装しています。  
[実装サンプル](src/Example/Program.cs)を例に説明します。

1. [Libディレクトリ](src/Lib)以下を利用したいプロジェクトの直下にコピーします。

1. 利用するプログラムに下記を追記します。
   1. [プロジェクトファイル](src/Example/Example.csproj)に参照を追加します。  
      ※今回は同列のディレクトリ「src/Lib」を利用  
      ```xml
      <ItemGroup>
        <ProjectReference Include="../Lib/JsonExtention/JsonExtention.csproj" />
      </ItemGroup>
      ```

   1. ソースファイルの追記します。

      1. usingの追加します。  
          ```csharp
          using JsonExtention;
          using JsonExtention.Extentions;
          ```

      1. JSON変換したいクラスの定義します。  
         ※JSON継承用インターフェイス「IJsonClass」を継承します。    
          ```csharp
          /// <summary>
          /// サンプルクラス
          /// </summary>
          public class WeatherForecast : IJsonClass
          {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; } = string.Empty;
            public List<string> List { set; get; } = new List<string>();
          }
          ```

      1. シリアライズやデシアライズ処理を実装します。
          * シリアライズ例  
            ```csharp
            // サンプルクラスインスタンス作成
            var weatherForecast = new WeatherForecast
            {
              Date = DateTime.Parse("2019-08-01"),
              TemperatureCelsius = 25,
              Summary = "Hot"
            };
            weatherForecast.List.Add("A");
            weatherForecast.List.Add("B");

            // シリアライズ
            var json = weatherForecast.Serialize();
            ```

          * デシアライズ例  
            ```csharp
            // シリアライズしたJSON文字列「json」をデシアライズ
            var classInstance = json.Deserialize<WeatherForecast>() ?? new WeatherForecast();
            ```

## サンプル実装の実行方法
* ローカル実行  
    dotnet runで実行する。  
    ```sh
    dotnet run --project ./src/Example/Example.csproj
    ```  

* Dockerコンテナでの実行  
    Dockerコンテナ上で開発環境を構築する。  
   * 前提  
     * Docker EngineやDocker Desktopがインストール済みであること。

   * 実行手順  
     dotnetコンテナを起動する。
      1. docker_devに移動  
          ```sh
          cd docker_dev
          ```

      1. (**初回のみ**)ビルド  
          ```sh
          docker-compose build
          ```

      1. コンテナ起動  
          ```sh
          docker-compose up -d
          ```

      1. コンテナに入る  
          ```sh
          docker exec -it docker_dev_dotnet_1 /bin/bash
          ```

      1. コンテナ内で実行 
          1. dotnet runで実行する。
              ```sh
              dotnet run --project ./src/Example/Example.csproj
              ```

          1. コンテナから離脱する。
              ```sh
              exit
              ```

      1. コンテナ停止・削除  
          ```sh
          docker-compose down
          ```

## テスト
* ローカル実行  
    dotnet testで実行する。  
    ```sh
    dotnet test ./src/JsonExtentionTest/JsonExtentionTest.csproj
    ```  

* Dockerコンテナでの実行  
    Dockerコンテナ上で開発環境を構築する。  
   * 前提  
     * Docker EngineやDocker Desktopがインストール済みであること。

   * 実行手順  
     dotnetコンテナを起動する。
      1. docker_devに移動  
          ```sh
          cd docker_dev
          ```

      1. (**初回のみ**)ビルド  
          ```sh
          docker-compose build
          ```

      1. コンテナ起動  
          ```sh
          docker-compose up -d
          ```

      1. コンテナに入る  
          ```sh
          docker exec -it docker_dev_dotnet_1 /bin/bash
          ```

      1. コンテナ内で実行 
          1. dotnet testで実行する。
              ```sh
              dotnet test ./src/JsonExtentionTest/JsonExtentionTest.csproj
              ```

          1. コンテナから離脱する。
              ```sh
              exit
              ```

      1. コンテナ停止・削除  
          ```sh
          docker-compose down
          ```
