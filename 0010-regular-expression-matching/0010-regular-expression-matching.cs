public class Solution 
{
    public bool IsMatch(string s, string p) 
    {
        int sLength = s.Length;
        int pLength = p.Length;

        // isMatch[i, j]는 문자열 s의 처음 i 문자와 패턴 p의 처음 j 문자가 매치되는지 여부를 나타냅니다.
        bool[,] isMatch = new bool[sLength + 1, pLength + 1];

        // 초기 상태: 빈 문자열과 빈 패턴은 매치됨
        isMatch[0, 0] = true;

        for (int i = 0; i <= sLength; i++)
        {
            for (int j = 1; j <= pLength; j++)
            {
                char currentPatternChar = p[j - 1];

                if (currentPatternChar == '*')
                {
                    // '*'을 만나면 두 가지 옵션이 있음:
                    // 1. 바로 앞의 문자가 0번으로 처리됨 (isMatch[i, j - 2])
                    // 2. 바로 앞의 문자가 1번 이상 반복됨 (s[i - 1] == p[j - 2] 또는 p[j - 2] == '.')
                    isMatch[i, j] = isMatch[i, j - 2] || (i > 0 && (s[i - 1] == p[j - 2] || p[j - 2] == '.') && isMatch[i - 1, j]);
                }
                else
                {
                    // 일반 문자 또는 '.' 문자인 경우, 이전 상태의 결과를 참조하여 갱신
                    if (i > 0)
                    {
                        char currentStringChar = s[i - 1];
                        isMatch[i, j] = isMatch[i - 1, j - 1] && (currentStringChar == currentPatternChar || currentPatternChar == '.');
                    }
                }
            }
        }

        // isMatch[sLength, pLength]에는 최종 결과가 저장됨
        return isMatch[sLength, pLength];
    }
}
