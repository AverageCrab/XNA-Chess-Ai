using System;
using Microsoft.Xna.Framework;

namespace ChessGame
{
    public static class Helpers
    {
        public static Vector2 TileToPixel(int x, int y)
        {
            return new Vector2((x*132) + 132/4,(y*132) + 132/4);
        }

        public static Vector2 PixelToTile(int x, int y)
        {
            return new Vector2(x / 132, y / 132);
        }

        public static BoardCoord TileToBoardCoord(int x, int y)
        {
            var boardCoord = new BoardCoord();
            switch (y)
            {
                case 0:
                    boardCoord.YRank = "8";
                    break;
                case 1:
                    boardCoord.YRank = "7";
                    break;
                case 2:
                    boardCoord.YRank = "6";
                    break;
                case 3:
                    boardCoord.YRank = "5";
                    break;
                case 4:
                    boardCoord.YRank = "4";
                    break;
                case 5:
                    boardCoord.YRank = "3";
                    break;
                case 6:
                    boardCoord.YRank = "2";
                    break;
                case 7:
                    boardCoord.YRank = "1";
                    break;
            }
            switch (x)
            {
                case 0:
                    boardCoord.XRank = "a";
                    break;
                case 1:
                    boardCoord.XRank = "b";
                    break;
                case 2:
                    boardCoord.XRank = "c";
                    break;
                case 3:
                    boardCoord.XRank = "d";
                    break;
                case 4:
                    boardCoord.XRank = "e";
                    break;
                case 5:
                    boardCoord.XRank = "f";
                    break;
                case 6:
                    boardCoord.XRank = "g";
                    break;
                case 7:
                    boardCoord.XRank = "h";
                    break;
            }
            return boardCoord;
        }

        public static TilePosition BoardCoordToTile(BoardCoord boardCoord)
        {
            var tilePosition = new TilePosition();
            switch (boardCoord.YRank)
            {
                case "8":
                    tilePosition.X = 0;
                    break;
                case "7":
                    tilePosition.X = 1;
                    break;
                case "6":
                    tilePosition.X = 2;
                    break;
                case "5":
                    tilePosition.X = 3;
                    break;
                case "4":
                    tilePosition.X = 4;
                    break;
                case "3":
                    tilePosition.X = 5;
                    break;
                case "2":
                    tilePosition.X = 6;
                    break;
                case "1":
                    tilePosition.X = 7;
                    break;
            }
            switch (boardCoord.XRank)
            {
                case "a":
                    tilePosition.Y = 0;
                    break;
                case "b":
                    tilePosition.Y = 1;
                    break;
                case "c":
                    tilePosition.Y = 2;
                    break;
                case "d":
                    tilePosition.Y = 3;
                    break;
                case "e":
                    tilePosition.Y = 4;
                    break;
                case "f":
                    tilePosition.Y = 5;
                    break;
                case "g":
                    tilePosition.Y = 6;
                    break;
                case "h":
                    tilePosition.Y = 7;
                    break;
            }
            return tilePosition;
        }

        public static PieceType GetPieceType(string stringType)
        {
            if (stringType.Contains("pawn"))
            {
                return PieceType.Pawn;
            }
            if (stringType.Contains("knight"))
            {
                return PieceType.Knight;
            }
            if (stringType.Contains("bishop"))
            {
                return PieceType.Bishop;
            }
            if (stringType.Contains("rook"))
            {
                return PieceType.Rook;
            }
            if (stringType.Contains("king"))
            {
                return PieceType.King;
            }
            if (stringType.Contains("queen"))
            {
                return PieceType.Queen;
            }
            return PieceType.None;
        }

        public static string DecrementYRank(string YRank,int quantity)
        {
            var rank = Convert.ToInt32(YRank);
            rank = rank - quantity;
            return rank.ToString();
        }

        public static string IncrementYRank(string YRank, int quantity)
        {
            var rank = Convert.ToInt32(YRank);
            rank = rank + quantity;
            return rank.ToString();
        }
    }
}
