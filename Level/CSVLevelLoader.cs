using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace $safeprojectname$
{
    public class CSVLevelLoader : MarioGameLevelLoader
    {
        protected const int tileSize = 16;

        protected const int levelTileHeight = 14;

        protected Dictionary<string, Action<Point, string[]>> tokenMap;

        public CSVLevelLoader() : base()
        {
            tokenMap = new Dictionary<string, Action<Point, string[]>>();

            tokenMap["bb"] = HandleBrickBlock;
            tokenMap["cb"] = AddCrackedBlock;
            tokenMap["hb"] = HandleHiddenBlock;
            tokenMap["sb"] = AddStoneBlock;
            tokenMap["ubb"] = HandleUndergroundBrickBlock;
            tokenMap["ucb"] = AddUndergroundCrackedBlock;
            tokenMap["uhb"] = HandleUndergroundHiddenBlock;
            tokenMap["usb"] = AddUndergroundStoneBlock;
            tokenMap["cbb"] = AddCastleBrickBlock;
            tokenMap["ib"] = HandleItemBlock;
            tokenMap["lp"] = HandleLeftPipe;
            tokenMap["up"] = HandleUpPipe;
            tokenMap["lvp"] = AddLeftVerticalPipeBlock;
            tokenMap["rvp"] = AddRightVerticalPipeBlock;
            tokenMap["thp"] = AddTopHorizontalPipeBlock;
            tokenMap["bhp"] = AddBottomHorizontalPipeBlock;
            tokenMap["lav"] = AddLava;
            tokenMap["lavt"] = AddLavaTop;
            tokenMap["sfb"] = AddSpinnyFireBlock;
            tokenMap["g"] = AddGoomba;
            tokenMap["gk"] = AddGreenKoopa;
            tokenMap["rk"] = AddRedKoopa;
            tokenMap["vpk"] = AddVerticalParakoopa;
            tokenMap["hpk"] = AddHorizontalParakoopa;
            tokenMap["bpk"] = AddBouncingParakoopa;
            tokenMap["bow"] = AddBowser;
            tokenMap["c"] = AddCoin;
            tokenMap["ff"] = AddFireFlower;
            tokenMap["rm"] = AddRedMushroom;
            tokenMap["gm"] = AddGreenMushroom;
            tokenMap["s"] = AddStar;
            tokenMap["bh"] = AddBigHill;
            tokenMap["2bush"] = AddDoubleBush;
            tokenMap["2cloud"] = AddDoubleCloud;
            tokenMap["1bush"] = AddSingleBush;
            tokenMap["1cloud"] = AddSingleCloud;
            tokenMap["3bush"] = AddTripleBush;
            tokenMap["3cloud"] = AddTripleCloud;
            tokenMap["mp"] = HandleMovingPlatform;
            tokenMap["br"] = AddBridge;
            tokenMap["ca"] = AddCastle;
            tokenMap["t"] = AddToad;
            tokenMap["fp"] = AddFlagpole;
            tokenMap["tb"] = AddTitleBlock;
            tokenMap["*background"] = HandleBackgroundColor;
            tokenMap["*music"] = HandleBackgroundMusic;
            tokenMap["*next"] = HandleNextLevel;
            tokenMap["*start"] = HandleStartLocation;
            tokenMap["*name"] = HandleLevelName;
        }

        override public Level LoadLevel(string levelname)
        {
            this.level = new Level();
            LoadFromCSV(levelname);
            return this.level;
        }

        protected void LoadFromCSV(string path)
        {
            if (!File.Exists(path))
                return;

            using (StreamReader reader = new StreamReader(path))
            {
                int line = 0;
                while(!reader.EndOfStream)
                {
                    ParseTokens(reader.ReadLine().Split(','), line++);
                }
            }
        }

        protected void ParseTokens(string[] tokens, int line)
        {
            Point point = new Point(line * tileSize, levelTileHeight * tileSize); ;
            Action<Point, string[]> action;

            foreach (string token in tokens)
            {
                string[] args = token.Split('+');
                if(tokenMap.TryGetValue(args[0], out action))
                {
                    action(point, args);
                }
                point.Y -= tileSize;
            }
        }

        protected Queue<Item> ParseItems(Point point, string[] args)
        {
            Queue<Item> items = new Queue<Item>();
            Item item;
            if (args.Length > 1)
            {
                string itemString = args[1];
                for (int i = 0; i < itemString.Length; i++)
                {
                    switch (itemString[i])
                    {
                        case 'f': item = new FireFlower(point, true); break;
                        case 'r': item = new RedMushroom(point, true); break;
                        case 'g': item = new GreenMushroom(point, true); break;
                        case 's': item = new Star(point, true); break;
                        default: item = new SpinningCoin(point, true); break;
                    }
                    items.Enqueue(item);
                    level.AddItem(item);
                }
            }
            return items;
        }

        protected void HandleItemBlock(Point point, string[] args) {
            level.AddBlock(Block.CreateItemBlock(point, ParseItems(point, args)));
        }
        protected void HandleBrickBlock(Point point, string[] args) {
            level.AddBlock(Block.CreateBrickBlock(point, ParseItems(point, args)));
        }
        protected void HandleHiddenBlock(Point point, string[] args) {
            level.AddBlock(Block.CreateHiddenBlock(point, ParseItems(point, args)));
        }
        protected void HandleUndergroundBrickBlock(Point point, string[] args)
        {
            level.AddBlock(Block.CreateUndergroundBrickBlock(point, ParseItems(point, args)));
        }
        protected void HandleUndergroundHiddenBlock(Point point, string[] args)
        {
            level.AddBlock(Block.CreateUndergroundHiddenBlock(point, ParseItems(point, args)));
        }

        protected void HandleBackgroundColor(Point point, string[] args)
        {
            if (args.Length < 4)
                return;

            level.BackgroundColor = Color.FromNonPremultiplied(int.Parse(args[1]),
                int.Parse(args[2]),
                int.Parse(args[3]),
                255);
        }

        protected void ParsePipeDestination(Pipe pipe, string[] args)
        {
            if (args.Length < 4)
                return;

            pipe.DestinationLevel = args[1];
            pipe.DestinationPoint = new Point(int.Parse(args[2]), int.Parse(args[3]));
        }
        protected void HandleUpPipe(Point point, string[] args)
        {
            ParsePipeDestination(level.AddPipe(Pipe.CreateUpPipe(point)), args);
        }
        protected void HandleLeftPipe(Point point, string[] args)
        {
            ParsePipeDestination(level.AddPipe(Pipe.CreateLeftPipe(point)), args);
        }

        protected void HandleMovingPlatform(Point point, string[] args)
        {
            if (args.Length < 4)
                return;

            float speed = int.Parse(args[1]);
            Point end = new Point(int.Parse(args[2]), int.Parse(args[3])) + point;
            level.AddPlatform(Platform.CreateMovingPlatform(point, end, speed));
        }

        protected void HandleBackgroundMusic(Point point, string[] args)
        {
            if (args.Length < 2)
                return;

            switch (args[1])
            {
                case "main":
                    level.BackgroundMusic = MusicFactory.Instance.CreateMainMusic();
                    break;
                case "underground":
                    level.BackgroundMusic = MusicFactory.Instance.CreateUndergroundMusic();
                    break;
                case "castle":
                    level.BackgroundMusic = MusicFactory.Instance.CreateCastleMusic();
                    break;
            }
        }

        protected void HandleNextLevel(Point point, string[] args)
        {
            if (args.Length < 2)
                return;

            level.NextLevel = args[1];
        }

        protected void HandleStartLocation(Point point, string[] args)
        {
            level.StartLocation = point;
        }

        protected void HandleLevelName(Point point, string[] args)
        {
            if (args.Length < 2)
                return;

            level.Name = args[1];
        }
    }
}
