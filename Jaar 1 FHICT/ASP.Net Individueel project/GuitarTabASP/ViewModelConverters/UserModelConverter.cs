using GuitarTabASP.Models;
using Logic_layer;
using System.Collections.Generic;

namespace GuitarTabASP.ViewModelConverters
{
    public class UserModelConverter
    {
        public User ViewModelNaarModel(UserViewModel model)
        {
            User user = new User(model.Gebruikersnaam, model.email, model.wachtwoord);
            return user;
        }
        public UserViewModel ModelNaarViewModel(User user)
        {
            UserViewModel userViewModel = new UserViewModel
            {
                email = user.email,
                wachtwoord = user.wachtwoord,
                Gebruikersnaam = user.gebruikersnaam,
                userID = user.userID,
                rating = new UserRatingViewModel
                {
                    rating = user.rating.rating
                }
            };
            return userViewModel;

        }
        public List<UserViewModel> AllUserModelsToViewModels(List<User> users)
        {
            List<UserViewModel> viewModels = new List<UserViewModel>();
            foreach(User user in users)
            {
                UserViewModel userViewModel = ModelNaarViewModel(user);
                viewModels.Add(userViewModel);
            }
            return viewModels;
        }
    }
}
