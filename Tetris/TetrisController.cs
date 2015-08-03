using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
   public enum PlayOperation
   {
      None = 0,
      Change = 1,
      Left = 2, 
      Right = 3,
      Down = 4
   }

   public class TetrisController
   {
      public const int MAX_LINE = 22;
      public const int MAX_COLUMN = 10;
      private int[,] stage = new int[MAX_LINE, MAX_COLUMN];
      private int[,] activeBlock = new int[4, 4];
      public TetrisController()
      {
         InitializeStage();
      }

      private void InitializeStage()
      {
         for (int line = 0; line < MAX_LINE; line++)
         {
            for (int column = 0; column < MAX_COLUMN; column++)
            {
               stage[line, column] = 1;
            }
         }
      }

      public int ReturnStageValue(int line, int column)
      {
         return stage[line, column];
      }

      public void GetOperation(PlayOperation operation)
      {
      }
   }
}
