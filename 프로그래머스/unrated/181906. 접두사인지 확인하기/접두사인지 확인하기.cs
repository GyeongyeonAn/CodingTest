using System;

public class Solution {
    public int solution(string my_string, string is_prefix) {
        int answer = 0;
        string check = "";
        for(int i=0; i<my_string.Length; i++)
        {
            check += my_string[i];
            if(check == is_prefix)
            {
                answer = 1;
                break;
            }
        }
        return answer;
    }
}