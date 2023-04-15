using _Application.Sources.App.Data;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.Missions;

namespace _Application.Sources.App.Core.Missions
{
    public static class Mission1
    {
        public static Mission GetMission(IMission1Context context) => new Mission("Уход из дома",
            new SubMissionBase[]
            {
                new SpawnNpc(PlayerType.Grandma, context.MumSpawnPoint),
                new SpawnNpc(PlayerType.Grandpa, context.DadSpawnPoint),
                new SpawnNpc(PlayerType.Jock, context.UncleSpawnPoint),
                new SpawnCar(CarType.Sedan, context.SedanSpawnPoint),
                new SpawnCar(CarType.Taxi, context.TaxiSpawnPoint),
                new DialogueScene(new DialogueCamera(context.HouseCameraPoint), new[]
                {
                    new DialogueCue(PlayerType.Grandpa, ""),
                    new DialogueCue(PlayerType.Grandma, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                    new DialogueCue(PlayerType.Grandpa, ""),
                    new DialogueCue(PlayerType.Grandma, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                }),
                new WalkDistanceQuest(10f),
                new PhoneDialogue(new PhoneDialogueCue[]
                {
                    new MyPhoneCue(""),
                    new CallerCue(PlayerType.Jock, ""),
                    new MyPhoneCue(""),
                    new CallerCue(PlayerType.Jock, ""),
                    new MyPhoneCue(""),
                    new CallerCue(PlayerType.Jock, ""),
                    new MyPhoneCue(""),
                    new CallerCue(PlayerType.Jock, ""),
                }),
                new EnterCarQuest(CarType.Sedan),
                new MoveToPointByCarQuest(context.MumSpawnPoint),
                new MoveToPointWithoutCarQuest(context.MumSpawnPoint),
                new DialogueScene(new DialogueCamera(context.UncleCameraPoint), new[]
                {
                    new DialogueCue(PlayerType.Jock, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                    new DialogueCue(PlayerType.Jock, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                    new DialogueCue(PlayerType.Jock, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                }),
                new EnterCarQuest(CarType.Taxi),
                new BringPeopleQuest(3),
                new MoveToPointByCarQuest(context.MumSpawnPoint),
                new MoveToPointWithoutCarQuest(context.MumSpawnPoint),
                new DialogueScene(new DialogueCamera(context.UncleCameraPoint), new[]
                {
                    new DialogueCue(PlayerType.Jock, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                    new DialogueCue(PlayerType.Jock, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                    new DialogueCue(PlayerType.Jock, ""),
                    new DialogueCue(PlayerType.Biker, ""),
                }),
            });
    }
}