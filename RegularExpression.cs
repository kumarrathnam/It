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
            else
            {
                return false;
            }
        }
    }
    
    String [] getTokens(string p)
    {
        List<String> tokens = new List<String>();
        String currentToken = "";
        
        for(int i = 0; i < p.Length; i++)
        {
            if(p[i] != '*')
            {
                if(i + 1 < p.Length && p[i + 1] == "*")
                {
                    if (currentToken != "")
                    {
                        tokens.Add(currentToken);
                        currentToken = "";
                    }
                    
                    tokens.Add(p[i] + "*");
                }
                else
                {
                    currentToken = currentToken + p[i];
                }
            }
            else if(p[i] == '.')
            {
                if (currentToken != "")
                {
                    tokens.Add(currentToken);
                    currentToken = "";
                }
                
                tokens.Add(".");
            }
        }
    }
    
    bool IsLiteralMatch(String s, String p, int lastMatchedIndex, out int newLastMatchedIndex)
    {
        for(int i =0;i < p.Length; i++)
        {
            if(i + lastMatchedIndex < s.Length && s[i + lastMatchedIndex != p[i]])
            {
                newLastMatchedIndex = i + lastMatchedIndex;
            }
            else
            {
                return false;
            }
        }
    }
}

