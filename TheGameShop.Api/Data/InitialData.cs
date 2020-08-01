using System;
using System.Collections.Generic;
using System.Linq;
using TheGameShop.Api.Data.Entities;

namespace TheGameShop.Api.Data
{
    public static class InitialData
    {
        public static void Seed(this TheGameShopDbContext dbContext)
        {
            if (dbContext.Games.Any()) return;

            dbContext.Games.Add(new Game
            {
                Name = "Batman: Arkham Knight",
                Description = "Batman: Arkham Knight is a 2015 action-adventure game developed by Rocksteady Studios and published by Warner Bros. Interactive Entertainment. Based on the DC Comics superhero Batman, it is the successor to the 2013 video game Batman: Arkham Origins, and the fourth main installment in the Batman: Arkham series.",
                Price = 19.5m,
                Rating = 10,
                Type = GameTypeEnum.PlayStation,
                Stock = 48,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview
                    {
                        Title = "My favorite Batman game",
                        Review = "Overall, the game, while flawed, is a superb game, and an even better Batman game. Maybe not the best in Arkham series, but definitely the one I play the most, and the one I will without a doubt, call my favorite. "
                    },
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "God of War",
                Description = "Living as a man outside the shadow of the gods, Kratos must adapt to unfamiliar lands, unexpected threats and a second chance at being a father. Together with his son Atreus, the pair will venture into the brutal realm of Midgard and fight to fulfil a deeply personal quest.",
                Price = 21.9m,
                Rating = 10,
                Type = GameTypeEnum.PlayStation,
                Stock = 75,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview
                    {
                        Title = "Top game",
                        Review = "One of the top 5 best exclusive title to have! If you have a Playstation 4 console you already made the first step in making the best decision, secondly if you still haven't experienced the exclusive titles on offer for PlayStation 4 then you way behind and of course God of war is among the best top 5."
                    },
                    new GameReview
                    {
                        Title = "The best",
                        Review = "One of the best video games I've ever played, if not THE best. It has an engaging combat, it's fast, it's challenging but never to the point of it being unfair, it took a different approach from the overly repetitive combat of the previous games."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "The Elder Scrolls V: Skyrim",
                Description = "The Elder Scrolls V: Skyrim is an action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks. ",
                Price = 28.99m,
                Rating = 0,
                Type = GameTypeEnum.Nintendo,
                Stock = 66,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview
                    {
                        Title = "The game is absolutely outstanding!",
                        Review = "The graphics are amazing and spectacular. I love the interactions with characters in the game, but i still do feel that there should be a greater variety of communication between the townspeople and the dragonborn. The quest lines are great and definitely interesting to the point where you're just absolutely hooked! The combat, weapons, and armor are astounding and amazingly magnificent, great work on the entire game."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "LEGO Star Wars: The Skywalker Saga",
                Description = "Lego Star Wars: The Skywalker Saga will be the biggest Lego Star Wars adventure yet when it launches later this year, spanning all nine Skywalker saga films--including The Rise of Skywalker.",
                Price = 19.5m,
                Rating = 7,
                Type = GameTypeEnum.Nintendo,
                Stock = 34,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
            });

            dbContext.Games.Add(new Game
            {
                Name = "Assassin's Creed Valhalla",
                Description = "Become Eivor, a mighty Viking raider and lead your clan from the harsh shores of Norway to a new home amid the lush farmlands of ninth-century England. Explore a beautiful, mysterious open world where you'll face brutal enemies, raid fortresses, build your clan's new settlement, and forge alliances to win glory and earn a place in Valhalla.",
                Price = 20m,
                Rating = 8,
                Type = GameTypeEnum.Xbox,
                Stock = 81,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview
                    {
                        Title = "So this is my 1st ever...",
                        Review = "An amazing, albeit at times annoying- yet fun, game, love the tie ins, first time I ever played the game I was so hyped, the story is a little rushed, but if you’re a busy body, and if you take your time, you can seriously fall in love with this game, eventually you’ll become a badass."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Cyberpunk 2077",
                Description = "Cyberpunk 2077 is a RPG set in the corrupt and tech-advanced world of the year 2077..",
                Price = 40m,
                Rating = 9,
                Type = GameTypeEnum.Xbox,
                Stock = 68,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = " I highly recommend this game",
                        Review = "Pretty decent game overall I’d like to just point out that the gun sounds are absolutely amazing. The graphics are magnificent and the new design of the game is really astounding."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Ghost of Tsushima",
                Description = "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions and published by Sony Interactive Entertainment for PlayStation 4. Featuring an open world for players to explore, it revolves around Jin Sakai, one of the last samurai on Tsushima Island during the first Mongol invasion of Japan.",
                Price = 23m,
                Rating = 8,
                Type = GameTypeEnum.PlayStation,
                Stock = 35,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "The combat is challenging but fair.",
                        Review = "OMG what an incredible game!!!! I'm about fifteen hours in and GoS is an epic of an adventure. It's the feudal Japan game we've been begging for for years!"
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Uncharted 4: A Thief's End",
                Description = "Uncharted 4: A Thief's End is a 2016 action-adventure game developed by Naughty Dog and published by Sony Computer Entertainment. It is the fourth main entry in the Uncharted series.",
                Price = 18m,
                Rating = 10,
                Type = GameTypeEnum.PlayStation,
                Stock = 39,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "Completely new",
                        Review = "I have to say this was the nearest to a perfect gaming experience I have ever had.The game is amazing in every way.Recently finished my odyssey into the exotic and exquisite world of uncharted 4. Continuing the legacy of uncharted games, uncharted 4 delivers even impressively. "
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Resident Evil 7: Biohazard",
                Description = "Resident Evil 7: Biohazard is a survival horror video game developed and published by Capcom, released in January 2017 for Microsoft Windows, PlayStation 4, Xbox One and in May 2018 for the Nintendo Switch in Japan.",
                Price = 22m,
                Rating = 8,
                Type = GameTypeEnum.PlayStation,
                Stock = 61,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "Resident Evil 7 is the best in the series",
                        Review = "I can't describe how much this game is nice and entertaining.. everybody must try it !...when i have heard about Resident Evil Games, i have got a wrong idea about the series and i didn't tried any episode else Resident Evil 1.. but after many promotions of the series especially when capcom unveiled the cover about Resident Evil 7"
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Monster Hunter World",
                Description = "Monster Hunter: World is an action role-playing game developed and published by Capcom. A part of the Monster Hunter series, it was released worldwide for PlayStation 4 and Xbox One in January 2018, with a Microsoft Windows version following in August 2018.",
                Price = 20m,
                Rating = 7,
                Type = GameTypeEnum.PlayStation,
                Stock = 34,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "It's a great game",
                        Review = "When I first played MHW I thought it would be the same as Dauntless because of players asking me have you played this game and saying it's similar or exact same as Dauntless, But because of the stamina problem and bugs in Dauntless I though it wasn't worth me buying. "
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "The Legend of Zelda: Link's Awakening",
                Description = "The Legend of Zelda: Link's Awakening is an action-adventure game developed by Grezzo and published by Nintendo for the Nintendo Switch. It was released on September 20, 2019. As of March 2020, the game has sold over 4 million copies worldwide, making it one of the best-selling Nintendo Switch games.",
                Price = 50m,
                Rating = 3,
                Type = GameTypeEnum.Nintendo,
                Stock = 66,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "Perfect game ever",
                        Review = "It's overpriced, but if you love Zelda, and you loved Link's Awakening, you have to play this faithful, lovingly adapted remake. It's not perfect, but it gets the job done."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Super Mario Maker 2",
                Description = "Super Mario Maker 2 is a side-scrolling platform game and game creation system developed and published by Nintendo for the Nintendo Switch. It is the sequel to Super Mario Maker, and it was released worldwide on June 28, 2019.",
                Price = 43m,
                Rating = 8,
                Type = GameTypeEnum.Nintendo,
                Stock = 53,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "1000 times better",
                        Review = "I've owned Mario maker 1, and wow, Mario maker 2 is 100 times better, there is even an additional story mode in the game that allows you to unlock special power ups! the new world maker is awesome, you can even make our own game IN a game! it is a thrilling game, that allows you to create, play, and share YOUR levels."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Assassin's Creed Odyssey",
                Description = "Assassin's Creed Odyssey is the most recent addition to the epic Assassin's Creed RPG franchise. Odyssey is set during the Peloponnesian War and sees you stepping into the sandals of either Alexios or Kassandra as they try to uncover the truth about their history while navigating the turbulent world of Ancient Greece as a mercenary. ",
                Price = 19.9m,
                Rating = 3,
                Type = GameTypeEnum.Xbox,
                Stock = 8,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "Positives are that it’s huge",
                        Review = "When I first started playing this game I was convinced it was one of my favourite games of all time and it still is. However once the excitement of entering this massive Greek world wore off, I could start to see some things that I wish they would of done better. "
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Apex Legends",
                Description = "Apex Legends is another contender vying for the battle royale crown. Developed by Respawn Entertainment and set in the Titanfall universe, Apex Legends is a squad-based battle royale shooter where teams of three go up against 57 other players to try to gather loot and be the last person (or squad) standing.",
                Price = 20.5m,
                Rating = 7,
                Type = GameTypeEnum.Xbox,
                Stock = 40,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "The gameplay is the same as Titanfall 2",
                        Review = "An unexpected battle royale that improves the formula of its cake and brings a fresh start to the genre. People were disappointed this isn't Titanfall 3, I think Respawn didn't want its follow up to suffer the same fate as TF2 due to low sales and popularity and it is a pretty bold move to make a spinoff of their IP"
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Tom Clancy's Rainbow Six Siege",
                Description = "Tom Clancy's Rainbow Six Siege is an online tactical shooter video game developed by Ubisoft Montreal and published by Ubisoft. It was released worldwide for Microsoft Windows, PlayStation 4, and Xbox One on December 1, 2015; the game is also set to be released for PlayStation 5 and Xbox Series X in 2020.",
                Price = 24.5m,
                Rating = 7,
                Type = GameTypeEnum.PC,
                Stock = 12,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "The first person teamwork based shooter",
                        Review = "this game is just such an experience, from the tactical gameplay and unique operators based on real life events and actual tactical units like 707th smb or the GIGN. they put time into minute details which is just astonishing."
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Desperados 3",
                Description = "ApexDesperados III is a real-time tactics video game developed by Mimimi Games and published by THQ Nordic. The first installment in the Desperados series since the 2007 spin-off title Helldorado, it was released for Microsoft Windows, PlayStation 4 and Xbox One.",
                Price = 20.5m,
                Rating = 7,
                Type = GameTypeEnum.PC,
                Stock = 40,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "The gameplay is the same as Titanfall 2",
                        Review = "Clearly they are very good at their job and no doubt they put all their hearts to this game just like Shadow Tactics. Dialogues are enjoyable and voice acting is also good. "
                    }
                }
            });

            dbContext.Games.Add(new Game
            {
                Name = "Call of Duty: Modern Warfare",
                Description = "Call of Duty: Modern Warfare is a 2019 first-person shooter video game developed by Infinity Ward and published by Activision.",
                Price = 20.5m,
                Rating = 7,
                Type = GameTypeEnum.PC,
                Stock = 40,
                PhotoFileName = "https://picsum.photos/600/400/?blur",
                IntroducedAt = DateTimeOffset.Now.AddMonths(-1),
                GameReviews = new List<GameReview>
                {
                    new GameReview {
                        Title = "One of the best so far since BO3",
                        Review = "For people who started playing call of duty from one of the Black ops series I would suggest to change the way you used to play on this one cuz its less fast paced and you require more attention than the black ops series as there are more campers."
                    }
                }
            });

            dbContext.SaveChanges();
        }
    }
}