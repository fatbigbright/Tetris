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
      private const int MAX_LINE = 22;
      private const int MAX_COLUMN = 10;
      private const int BLOCK_WIDTH = 20;
      private const int BLOCK_HEIGHT = 20;
      private int[,] stage = new int[MAX_LINE, MAX_COLUMN];

      public MainWindow()
      {
         InitializeComponent();
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

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         InitializeComponentCustom();
         DrawStage();
      }

      private void InitializeComponentCustom()
      {
         this.myCanvas.Focus();
         this.myCanvas.KeyDown += new KeyEventHandler((obj, e) => {
         });
      }

      private void DrawStage()
      {
         for (int line = 0; line < MAX_LINE; line++)
         {
            for (int column = 0; column < MAX_COLUMN; column++)
            {
               Rectangle rec = new Rectangle();
               rec.Width = BLOCK_WIDTH;
               rec.Height = BLOCK_HEIGHT;
               FillRect(rec, stage[line, column]);
               this.myCanvas.Children.Insert(line * MAX_COLUMN + column, rec);
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
