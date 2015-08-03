using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private const int BLOCK_WIDTH = 20;
      private const int BLOCK_HEIGHT = 20;

      private TetrisController controller = new TetrisController();

      public MainWindow()
      {
         InitializeComponent();
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         InitializeComponentCustom();
      }

      private void InitializeComponentCustom()
      {
         this.myCanvas.Focus();
         this.myCanvas.KeyDown += new KeyEventHandler((obj, e) => {
            PlayOperation operation = PlayOperation.None;
            switch (e.Key)
            {
               case Key.Up:
                  operation = PlayOperation.Change;
                  break;
               case Key.Down:
                  operation = PlayOperation.Down;
                  break;
               case Key.Left:
                  operation = PlayOperation.Left;
                  break;
               case Key.Right:
                  operation = PlayOperation.Right;
                  break;
               default:
                  break;
            }
            controller.GetOperation(operation);
         });

         //rendering for every frame
         CompositionTarget.Rendering += (sender, args) =>
         {
            DrawStage();
         };
      }

      private void DrawStage()
      {
         for (int line = 0; line < TetrisController.MAX_LINE; line++)
         {
            for (int column = 0; column < TetrisController.MAX_COLUMN; column++)
            {
               Rectangle rec = null;

               //whether the rectangle(tile) is already existing
               if(this.myCanvas.Children.Count > line * TetrisController.MAX_COLUMN + column)
               {
                  rec = this.myCanvas.Children[line * TetrisController.MAX_COLUMN + column] as Rectangle;
               }
               else
               {
                  rec = new Rectangle();
                  this.myCanvas.Children.Insert(line * TetrisController.MAX_COLUMN + column, rec);
               }
               rec.Width = BLOCK_WIDTH;
               rec.Height = BLOCK_HEIGHT;
               FillRect(rec, controller.ReturnStageValue(line, column));
               Canvas.SetLeft(rec, column * rec.Width);
               Canvas.SetTop(rec, line * rec.Height);
            }
         }
      }

      private void FillRect(Rectangle rec, int existence)
      {
         if(existence == 1)
         {
            rec.Fill = new SolidColorBrush(Colors.Blue);
            rec.Stroke = new SolidColorBrush(Colors.DarkGreen);
         }
         else
         {
            rec.Fill = new SolidColorBrush(Colors.Transparent);
            rec.Stroke = new SolidColorBrush(Colors.Transparent);
         }
      }
   }
}
