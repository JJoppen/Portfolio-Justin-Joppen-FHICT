using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic_layer;
using GuitarTabASP.Models;

namespace GuitarTabASP.ViewModelConverters
{
    public class MuziekNummerModelConverter
    {
        public Muzieknummer ViewmodelToModel(MuziekNummerViewModel muziek)
        {
            Muzieknummer muzieknummer = new Muzieknummer(muziek.Naam, muziek.Beschrijving, muziek.Type, muziek.Tab, muziek.userid,muziek.NummerID,muziek.youtubelink);
            return muzieknummer;
        }
        public MuziekNummerViewModel ModelToViewModel(Muzieknummer nummer)
        {
            MuziekNummerViewModel muziekNummerViewModel = new MuziekNummerViewModel();
            muziekNummerViewModel.Beschrijving = nummer.Beschrijving;
            muziekNummerViewModel.Naam = nummer.Naam;
            muziekNummerViewModel.Tab = nummer.Tab;
            muziekNummerViewModel.Type = nummer.Type;
            muziekNummerViewModel.NummerID = nummer.MuziekNummerID;
            muziekNummerViewModel.userid = nummer.userID;
            muziekNummerViewModel.youtubelink = nummer.YoutubeLink;
            NummerRatingViewModel nummerRatingViewModel = new NummerRatingViewModel
            {
                rating = nummer.rating.rating,
                executerID = nummer.rating.id
                
            };
            muziekNummerViewModel.rating = nummerRatingViewModel;

            return muziekNummerViewModel;
        }
        public List<MuziekNummerViewModel> ModelListToViewModelList(List<Muzieknummer> nummerlist)
        {
            List<MuziekNummerViewModel> viewModels = new List<MuziekNummerViewModel>();
            foreach(Muzieknummer nummer in nummerlist)
            {
                MuziekNummerViewModel muziekNummerViewModel = ModelToViewModel(nummer);
                viewModels.Add(muziekNummerViewModel);
            }
            return viewModels;
        }
    }
}
