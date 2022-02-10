using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(int x, int y)> player1Markers = new List<(int x, int y)>
            {
                (x: 2, y: 2),
                (x: 1, y: 1),
                (x: 0, y: 2),
                (x: 2, y: 0),
                //(x: 0, y: 2),
                //(x: 1, y: 1),
                //(x: 0, y: 0),
                //(x: 0, y: 1),
            };


            List<(int x, int y)> player2Markers = new List<(int x, int y)>
            {
                (x: 1, y: 3),
                (x: 0, y: 0),
                (x: 1, y: 2),
            };
            Tictactoe(player1Markers, player2Markers);
            Console.ReadLine();
        }

        public static void Tictactoe(List<(int x, int y)> player1Markers, List<(int x, int y)> player2Markers)
        {
            

            var val= CheckWin(player1Markers);
            
            foreach(var value in val)
                Console.WriteLine(value);

        }

        


        private static List<(int x, int y)> CheckWin(List<(int x, int y)> playerMove)
        {
            int val=-1;
            Dictionary<int,(int x, int y)> playerResult = new Dictionary<int, (int x, int y)>();
            //bool returnMove= 
            if (playerMove.Where(m => m.x == 0 && m.y == 0).Count() > 0 && playerMove.Where(m => m.x == 0 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 0 && m.y == 2).Count() > 0)
                val = 1;
            else if (playerMove.Where(m => m.x == 1 && m.y == 0).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 2).Count() > 0)
                val = 2;
            else if (playerMove.Where(m => m.x == 2 && m.y == 0).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 2).Count() > 0)
                val = 3;
           

            else if (playerMove.Where(m => m.x == 0 && m.y == 0).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 0).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 0).Count() > 0)
                val = 4;
            else if (playerMove.Where(m => m.x == 0 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 1).Count() > 0)
                val = 5;
            else if (playerMove.Where(m => m.x == 0 && m.y == 2).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 2).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 2).Count() > 0)
                val = 6;

            else if (playerMove.Where(m => m.x == 0 && m.y == 0).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 2).Count() > 0)
                val = 7;
            else if (playerMove.Where(m => m.x == 0 && m.y == 2).Count() > 0 && playerMove.Where(m => m.x == 1 && m.y == 1).Count() > 0 && playerMove.Where(m => m.x == 2 && m.y == 0).Count() > 0)
                val = 8;


            if (val>0)
            {
                switch(val)
                {
                    case 1:
                        playerResult.Add(playerMove.IndexOf((0, 0)), (0, 0));
                        playerResult.Add(playerMove.IndexOf((0, 1)), (0, 1));
                        playerResult.Add(playerMove.IndexOf((0, 2)), (0, 2));
                        break;
                    case 2:
                        playerResult.Add(playerMove.IndexOf((0, 0)), (0, 0));
                        playerResult.Add(playerMove.IndexOf((1, 1)), (1, 1));
                        playerResult.Add(playerMove.IndexOf((1, 2)), (1, 2));
                        break ;
                    case 3:
                        playerResult.Add(playerMove.IndexOf((2, 0)), (2, 0));
                        playerResult.Add(playerMove.IndexOf((2, 1)), (0, 1));
                        playerResult.Add(playerMove.IndexOf((2, 2)), (2, 2));
                        break;
                    case 4:
                        playerResult.Add(playerMove.IndexOf((0, 0)), (0, 0));
                        playerResult.Add(playerMove.IndexOf((1, 0)), (1, 0));
                        playerResult.Add(playerMove.IndexOf((2, 0)), (2, 0));
                        break;
                    case 5:
                        playerResult.Add(playerMove.IndexOf((0, 1)), (0, 1));
                        playerResult.Add(playerMove.IndexOf((1, 1)), (1, 1));
                        playerResult.Add(playerMove.IndexOf((2, 1)), (2, 1));
                        break;
                    
                    case 6:
                        playerResult.Add(playerMove.IndexOf((0, 2)), (0, 2));
                        playerResult.Add(playerMove.IndexOf((1, 2)), (1, 2));
                        playerResult.Add(playerMove.IndexOf((2, 2)), (2, 2));
                        break;
                    case 7:
                        playerResult.Add(playerMove.IndexOf((0, 0)), (0, 0));
                        playerResult.Add(playerMove.IndexOf((1, 1)), (1, 1));
                        playerResult.Add(playerMove.IndexOf((2, 2)), (2, 2));
                        break;
                    case 8:
                        playerResult.Add(playerMove.IndexOf((0, 2)), (0, 2));
                        playerResult.Add(playerMove.IndexOf((1, 1)), (1, 1));
                        playerResult.Add(playerMove.IndexOf((2, 0)), (2, 0));
                        break;
                }
            }


            var values = playerResult.OrderBy(key => key.Key).Select(x => x.Value).ToList();
            return values;


        }

        private static bool CheckWin(List<int> moves)
        {
            return
            (moves.Contains(1) && moves.Contains(2) && moves.Contains(3)) ||
            (moves.Contains(4) && moves.Contains(5) && moves.Contains(6)) ||
            (moves.Contains(7) && moves.Contains(8) && moves.Contains(9)) ||

            (moves.Contains(1) && moves.Contains(4) && moves.Contains(7)) ||
            (moves.Contains(2) && moves.Contains(5) && moves.Contains(8)) ||
            (moves.Contains(3) && moves.Contains(6) && moves.Contains(9)) ||

            (moves.Contains(1) && moves.Contains(5) && moves.Contains(9)) ||
            (moves.Contains(3) && moves.Contains(5) && moves.Contains(7));
        }

        //case 1:
        //    int pos1 = playerMove.IndexOf((0, 0));
        //    playerResult.Add((0,0));
        //    int pos2 = playerMove.IndexOf((0, 1));
        //    if (pos2 > pos1)
        //    {
        //        playerResult.Add((0, 1));                           
        //    }
        //    else
        //    {
        //        playerResult.Insert(1, (0, 1));
        //    }
        //    int pos3 = playerMove.IndexOf((0, 2));
        //    if((pos3 > pos1) && (pos3>pos2))
        //        playerResult.Add((0, 2));
        //    else if((pos3 < pos2) && (pos3>pos1) || (pos3 < pos1) && (pos3 > pos2))
        //        playerResult.Insert(1,(0, 2));
        //    else 
        //        playerResult.Insert(0, (0, 2));
        //    break;
        //case 2:
        //    playerResult.Insert(playerMove.IndexOf((1, 0)), (1, 0));
        //    playerResult.Insert(playerMove.IndexOf((1, 1)), (1, 1));
        //    playerResult.Insert(playerMove.IndexOf((1, 2)), (1, 2));
        //    break;
        //case 3:
        //    playerResult.Insert(playerMove.IndexOf((2, 0)), (2, 0));
        //    playerResult.Insert(playerMove.IndexOf((2, 1)), (1, 1));
        //    playerResult.Insert(playerMove.IndexOf((2, 2)), (2, 2));
        //    break;
    }
}
