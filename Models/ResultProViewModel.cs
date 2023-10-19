﻿using YourProfessionWebApp.Domain.Entities;
using YourProfessionWebApp.Domain.Repositories.Interfaces;

namespace YourProfessionWebApp.Models {
    public class ResultProViewModel {
        private readonly IProfessionItemRepository professionItemRepository;
        private readonly List<ProfessionItem> professions;

        public ResultProViewModel(IProfessionItemRepository professionItemRepository, List<Interest> interests) {
            this.professionItemRepository = professionItemRepository;
            professions = professionItemRepository.GetAllProfessionItems().ToList();
        }

        /*public ProfessionItem GetBestProfession(List<Interest> interests) {

        }*/
    }
}