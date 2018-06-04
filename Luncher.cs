using System;

namespace App
{
    class Luncher
    {
        static void Main(string[] args)
        {
            // 任意のずんどこの設定
            Kakegoe[] arrayKakegoe = new Kakegoe[]
            {
             Kakegoe.ずん
             , Kakegoe.どこ
             , Kakegoe.ずん
             , Kakegoe.どこ
             , Kakegoe.ずん
             , Kakegoe.どこ
             , Kakegoe.ずん
             , Kakegoe.どこ
             , Kakegoe.ずん
            };

            while (true)
            {
                Console.WriteLine("以下キーを選んで入力してください");
                Console.WriteLine("[ 1 ] <<< 既定値でずんどこ");
                Console.WriteLine("[ 2 ] <<< 任意値でずんどこ");
                Console.WriteLine("[ 3 ] <<< 終了");

                // キー入力待機
                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine("");

                switch (input.Key.ToString())
                {
                    // 既定値でずんどこ
                    case "D1":
                        Zundoko zundoko1 = new Zundoko();
                        zundoko1.CallKiyoshi();
                        break;
                    // 指定値でずんどこ
                    case "D2":
                        Zundoko zundoko2 = new Zundoko(arrayKakegoe);
                        zundoko2.CallKiyoshi();
                        break;
                    // 終了
                    case "D3":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("");
            }
        }
    }
}
