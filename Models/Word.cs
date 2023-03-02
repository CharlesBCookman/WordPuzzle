using System.Collections.Generic;
using System;

namespace WordPuzzle.Models
{
  public class Word
  {
    public List<Letter> FailedArray = new List<Letter> { };
    public List<Letter> CorrectAnswer = new List<Letter> { };

    public bool Complete { get; set; }


    public Word(string correctWord)
    {
      Complete = false;
      PopulateCorrectAnswer(correctWord);
    }

    public List<Letter> ConvertStringToLetterList(string input){
      List<Letter> returnList = new List<Letter> {};
      foreach(char aLetter in input)
      {
        Letter letterToAdd = new Letter(aLetter.ToString());
        returnList.Add(letterToAdd);
      }
      return returnList;
    }

    public void PopulateCorrectAnswer(string inputWord)
    {
      List<Letter> returnList = ConvertStringToLetterList(inputWord);
      CorrectAnswer = returnList;
    }

    public bool CheckLetter(Letter inputLetter, int position)
    {
      if (CorrectAnswer[position].LetterValue.Equals(inputLetter.LetterValue)){
        CorrectAnswer[position].SetStatus("Correct"); //check this
        return true;
      } else {
        return false;
      }
    }

    public bool CheckLetterInWord(Letter inputletter)
    {
      bool returnbool = false;
      foreach(Letter check in CorrectAnswer)
      {
        if( check.LetterValue.Equals(inputletter.LetterValue))
        {
          check.Status = "Incorrect Spot";
          returnbool = true;
        }
      }
      return returnbool;
    }

    public void AddToFailed(Letter inputletter)
    {
      FailedArray.Add(inputletter);
    }

    public bool IsValidGuess(List<Letter> wordGuess)
    {
      for (int i = 0; i < wordGuess.Count; i++){
        if(CorrectAnswer[i].Status.Equals("Correct")){
          if(!(wordGuess[i].Equals(CorrectAnswer[i]))){
            return false;
          }
        }
        foreach(Letter failedGuess in FailedArray)
        {
          if(failedGuess.Equals(letterGuess)){
            return false;  
          }
        }
      }
      return true;
    }

    public bool WordGuess(string guess)
    {
      List<Letter> guessedWord = ConvertStringToLetterList(guess);

      if(!(IsValidGuess(guessedWord))){
        return false;
      }

      bool returnGuessBool = true;

      for(int i = 0 ; i <guessedWord.Count ; i ++)
      {
        if (CheckLetterInWord(guessedWord[i])){
          if(!CheckLetter(guessedWord[i]))
          {
            //letter is in wrong spot
            returnGuessBool = false;
          }
          //letter is in right spot
        } else {
          returnGuessBool = false;
          AddToFailed(guessedWord[i]);

        }
      }
      Complete = true;
      return returnGuessBool;
    }
  }
}