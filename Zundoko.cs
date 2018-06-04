using System;
using System.Linq;
using System.Collections.Generic;

namespace App
{
    /// <summary>
    /// Zundokoクラス
    /// </summary>
    public class Zundoko
    {
        readonly List<Kakegoe> Anser;
        readonly String CallK = "キヨシ！";

        /// <summary>
        /// 既定値の"ずんどこ"を正解とする場合のコンストラクタ
        /// </summary>
        public Zundoko()
        {
            List<Kakegoe> tempList = new List<Kakegoe>
            {
                Kakegoe.ずん,
                Kakegoe.ずん,
                Kakegoe.ずん,
                Kakegoe.ずん,
                Kakegoe.どこ
            };
            Anser = new List<Kakegoe>(tempList);
            Anser.AsReadOnly();
        }

        /// <summary>
        /// 指定した"ずんどこ"を正解とする場合のコンストラクタ
        /// </summary>
        /// <param name="arrayKakegoe">任意の正解の掛け声</param>
        public Zundoko(Kakegoe[] arrayKakegoe)
        {
            Anser = new List<Kakegoe>(arrayKakegoe);
            Anser.AsReadOnly();
        }

        /// <summary>
        /// 正しい"ずんどこ"の時にキヨシをコールする
        /// </summary>
        public void CallKiyoshi()
        {
            List<Kakegoe> targetList = new List<Kakegoe>();

            while (true)
            {
                // 定義された掛け声の中からランダムで掛け声を発声
                Random random = new System.Random();
                int randomInt = random.Next(Enum.GetValues(typeof(Kakegoe)).Length);
                Kakegoe koe = KakegoeExtension.GetKakegoeForNum(randomInt);
                targetList.Add(koe);
                System.Console.WriteLine(Enum.GetName(typeof(Kakegoe), koe));

                // 掛け声チェック
                if (CheckSize(targetList))
                {
                    if (CheckFullMatched(targetList))
                    {
                        System.Console.WriteLine(CallK);
                        break;
                    }
                    else
                    {
                        // 掛け声のリセット
                        targetList = new List<Kakegoe>();
                        System.Console.WriteLine("");
                    }
                }
                else
                {
                    if (!CheckCurrentMatched(targetList))
                    {
                        // 掛け声のリセット
                        targetList = new List<Kakegoe>();
                        System.Console.WriteLine("");
                    }
                }
            }
        }

        /// <summary>
        /// 現在の"ずんどこ"が正解と一致しているかをチェックする
        /// </summary>
        /// <returns><c>true</c>, 一致 <c>false</c> 不一致.</returns>
        /// <param name="targetList">Target list.</param>
        private bool CheckCurrentMatched(List<Kakegoe> targetList)
        {
            bool result = false;
            int currentPosition = targetList.Count - 1;

            if (Anser[currentPosition].Equals(targetList[currentPosition]))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 現在の"ずんどこ"が正解と完全一致しているかをチェック
        /// </summary>
        /// <returns><c>true</c>, 内容が完全一致 matched was checked, <c>false</c> 内容が不一致.</returns>
        /// <param name="target">Target.</param>
        private bool CheckFullMatched(List<Kakegoe> target)
        {
            bool result = false;

            if (CheckSize(target))
            {
                result = Anser.SequenceEqual(target);
            }

            return result;
        }

        /// <summary>
        /// 正解の"ずんどこ"との回数一致チェック
        /// </summary>
        /// <returns><c>true</c>, 正解と回数が一致, <c>false</c> 正解と回数が不一致.</returns>
        /// <param name="target">Target.</param>
        private bool CheckSize(List<Kakegoe> target)
        {
            bool result = false;

            if (Anser.Count == target.Count)
            {
                result = true;
            }
            return result;
        }
    }
}