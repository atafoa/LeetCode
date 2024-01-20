using System;
using System.Text;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
public class RotationalCipher {
  static void Main(String[] args) {
    // Call rotationalCipher with test cases here
    string input = "abcdefghijklmNOPQRSTUVWXYZ0123456789";
    int rotationFactor = 39;
    string output = rotationalCipher(input, rotationFactor);
    Console.WriteLine(output);
  }
  
  private static string rotationalCipher(String input, int rotationFactor) {
    // Write your code here
    // if the character isn't a letter or digit no work needed skip
    // if the character is a letter we mod 26 for 26 letters and ensure wrap around ascii numbers
    // if character is a number mod 10 for single digits
    
    if (rotationFactor == 0)
    {
      return input;
    }
    
    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < input.Length; i++)
    {
      char c = input[i];
    
    if(!Char.IsLetterOrDigit(c))
    {
      sb.Append(c);
    }
    else if (Char.IsLetter(c))
    {
      int c_ascii = (rotationFactor % 26) + c;
      if((Char.IsUpper(c) && (char)c_ascii > 'Z') || (Char.IsLower(c) && (char)c_ascii > 'z'))
      {
        c_ascii -= 26;
      }
      sb.Append((char)c_ascii); 
    }
    else if (Char.IsDigit(c))
    {
      int n_ascii = (rotationFactor % 10) + c;
      if ((char)(n_ascii) > '9')
      {
        n_ascii -= 10;
      }
      sb.Append((char)n_ascii);
    }
    }
     
    return sb.ToString();
  }
}
