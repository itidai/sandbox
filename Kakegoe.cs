using System;
namespace App
{
    /// <summary>
    /// 掛け声の定義(掛け声名, 順通番)
    /// </summary>
    public enum Kakegoe
    {
        ずん = 0,
        どこ = 1
    } 

    /// <summary>
    /// Enum 掛け声 の拡張クラス
    /// </summary>
    public static class KakegoeExtension
    {
        public static Kakegoe GetKakegoeForNum(int num)
        {
            Kakegoe result = new Kakegoe();
            foreach(Kakegoe koe in Enum.GetValues(typeof(Kakegoe)))
            {
                if(num.Equals((int)koe))
                {
                    result = koe;
                    break;
                }
            }
            return result;
        }
    }
}
