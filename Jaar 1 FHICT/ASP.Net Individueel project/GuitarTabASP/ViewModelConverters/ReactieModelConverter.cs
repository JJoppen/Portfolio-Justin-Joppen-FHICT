using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarTabASP.Models;
using Logic_layer;
using Microsoft.AspNetCore.Http;

namespace GuitarTabASP.ViewModelConverters
{
    public class ReactieModelConverter
    {
        public List<ReactieViewModel> ListModelNaarViewModel(List<Reactie> reacties)
        {
            List<ReactieViewModel> reactieViewModels = new List<ReactieViewModel>();
            foreach(Reactie reactie in reacties)
            {
                UserModelConverter converter = new UserModelConverter();

                ReactieViewModel reactieViewModel = new ReactieViewModel
                {
                    Comment = reactie.Comment,
                    NummerID = reactie.NummerID,
                    PlaatsTijd = reactie.PlaatsTijd,
                    ReactieID = reactie.ReactieID,
                    UserViewmodel = converter.ModelNaarViewModel(reactie.user)
                };
                reactieViewModels.Add(reactieViewModel);
            }
            return reactieViewModels;
        }
        public Reactie ViewModelNaarModel(ReactieViewModel reactieViewModel)
        {
            User user= new User(1);
            Reactie reactie = new Reactie(user,reactieViewModel.ReactieID,reactieViewModel.NummerID,reactieViewModel.Comment,reactieViewModel.PlaatsTijd);

            return reactie;
        }
    }
}
