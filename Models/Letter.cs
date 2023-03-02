using System.Collections.Generic;

namespace WordPuzzle.Models
{
  public class Letter
  {
    public string LetterValue { get; set; }
    public string Status { get; set; }


    public Letter(string lettervalue)
    {
      LetterValue = lettervalue;
      Status = "Not Guessed"; //"Not Guessed", "Incorrect Spot", "Correct"
    }


    public bool Equals(Letter input) {
      if(this.LetterValue.Equals(input.LetterValue)){
        return true;
      } else {
        return false;
      }
    }
  }
}
