using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportGenreDTO
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public Game[] Games { get; set; }
    }

    public class ExportGameDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }
    }
}

//{
//    "Id": 1,
//    "Genre": "Violent",
//    "Games": [
//      {
//        "Id": 49,
//        "Title": "Warframe",
//        "Developer": "Digital Extremes",
//        "Tags": "Single-player, Multi-player, Co-op, Steam Trading Cards, In-App Purchases, Partial Controller Support",
//        "Players": 6
//      },
//      {
//        "Id": 22,
//        "Title": "Soul at Stake",
//        "Developer": "Chongming Studio",
//        "Tags": "Multi-player, Online Multi-Player, Co-op, Online Co-op, Steam Cloud",
//        "Players": 2
//      },
//      {
//        "Id": 40,
//        "Title": "Black Desert Online",
//        "Developer": "Pearl Abyss",
//        "Tags": "Online Multi-Player, MMO, Online Co-op, Steam Trading Cards, In-App Purchases, Partial Controller Support",
//        "Players": 1
//      },
//      {
//        "Id": 71,
//        "Title": "Dead by Daylight",
//        "Developer": "Behaviour Digital Inc.",
//        "Tags": "Multi-player, Online Multi-Player, Co-op, Online Co-op, Steam Achievements, Full controller support, Steam Trading Cards, Steam Cloud",
//        "Players": 1
//      }
//    ],
//    "TotalPlayers": 10
//  },
