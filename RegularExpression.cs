public class Solution {
    public bool IsMatch(string s, string p) {
        bool isMatch = true;
        String[] tokens = getTokens(p);
        int currentTokenIndex = 0;
        int lastMatchedIndex = 0;
        int newLastMatchedIndex = 0;
        
        while(isMatch)
        {
          String currentToken = tokens[currentTokenIndex];
          
          if(IsLiteralToken(currentToken))
          {
            isMatch = isMatch && getMatch(s, lastMatchedIndex, currentToken, out newLastMatchedIndex);
          }
          else
          {
            isMatch = isMatch && getMatch('.', p.Length > 1 ? int.MaxValue : 1, out newLastMatchedIndex);
          }
          
          currentTokenIndex ++;
          lastMatchedIndex = newLastMatchedIndex + 1;
        }
        
        return lastMatchedIndex == s.Length;
    }
    
    bool IsLiteralToken(string token)
    {
        for(int i = 0 ; i < token.Length; i++)
        {
            if(IsSpecialCharacter(token[i]))
            {
                return false;
            }
        }
        
        return true;
    }
    
    bool IsSpecialCharacter(char c)
    {
        return  c == '*' || c == '.';
    }
    
    bool IsMatch(string s, int lastMatchedIndex, char toMatch, int count, out int lastMatchedIndex)
    {
        while(lastMatchedIndex < s.Length && count > 0)
        {
            if (s [lastMatchedIndex] == toMatch || s[lastMatchedIndex] == '.')
            {
                lastMatchedIndex ++;
                count --;
            }
            }
            else
            {
                return false;
            }
        }
    }
}
