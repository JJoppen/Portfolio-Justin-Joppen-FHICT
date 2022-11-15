using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace Logic_layer
{
    public class Reactie
    {
        public User user { get; set; }
        public int NummerID { get; set; }
        public int ReactieID { get; set; }
        public string Comment { get; set; }
        public DateTime PlaatsTijd { get; set; }

        public Reactie(User user,int ReactieID, int nummerID, string comment, DateTime PlaatsTijd)
        {
            this.user = user;
            this.NummerID = nummerID;
            this.ReactieID = ReactieID;
            this.Comment = comment;
            this.PlaatsTijd = PlaatsTijd;

        }
        public Reactie(ReactieDTO dto)
        {
            User userconvert = new User(dto.userDTO);
            user = userconvert;
            NummerID = dto.NummerID;
            Comment = dto.Comment;
            ReactieID = dto.ReactieID;
            PlaatsTijd = dto.PlaatsTijd;
               
        }
        public ReactieDTO ReactieNaarDTO()
        {
            UserDTO userdto = new UserDTO
            {
                gebruikersnaam = this.user.gebruikersnaam,
                userID = this.user.userID
            };
            ReactieDTO reactieDTO = new ReactieDTO
            {
                userDTO = userdto,
                NummerID = this.NummerID,
                Comment = this.Comment,
                PlaatsTijd = this.PlaatsTijd,
                ReactieID = this.ReactieID
            };
            return reactieDTO;
        }

        public bool InsertReactie(IReactie Ireactie)
        {
            return Ireactie.InsertReactie(ReactieNaarDTO());
        }
        public bool UpdateReactie(IReactie Ireactie)
        {
            return Ireactie.UpdateReactie(ReactieNaarDTO());
        }
    }
}
