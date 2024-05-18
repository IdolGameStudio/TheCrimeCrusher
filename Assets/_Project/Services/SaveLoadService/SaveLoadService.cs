using System.Collections.Generic;
using _Project.Data;
using _Project.Services.PlayerProgressService;
using UnityEngine;

namespace _Project.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private readonly IEnumerable<IProgressSaver> saverServices;
        private readonly IPlayerProgressService playerProgressService;

        public SaveLoadService(IEnumerable<IProgressSaver> saverServices, IPlayerProgressService playerProgressService)
        {
            this.saverServices = saverServices;
            this.playerProgressService = playerProgressService;
        }

        public void SaveProgress()
        {
            foreach (var saver in saverServices) 
                saver.UpdateProgress(playerProgressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, playerProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}