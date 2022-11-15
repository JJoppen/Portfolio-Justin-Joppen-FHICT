using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;


namespace Logic_layer
{
    public class MuziekNummerContainer
    {
        private IMuziekNummer IMuziekNummer;

            public Muzieknummer MaakNummer(MuziekNummerDTO muziekNummerDTO)
            {
                Muzieknummer nummer = new Muzieknummer(muziekNummerDTO);
                return nummer;
            }
            public MuziekNummerDTO MaakNummerDTO(Muzieknummer nummer)
            {
            RatingDTO ratingDTO = new RatingDTO { rating = 0 };
            MuziekNummerDTO nummerDTO = new MuziekNummerDTO()
            {
                    Naam = nummer.Naam,
                    Beschrijving = nummer.Beschrijving,
                    Type = nummer.Type,
                    Tab = nummer.Tab,
                    UserID = nummer.userID,
                    NummerID = nummer.MuziekNummerID,
                    YoutubeLink = nummer.YoutubeLink,
                    rating = ratingDTO
                    
                };

                return nummerDTO;
            }
            public Muzieknummer SelectNummer(int ID)
            {
                MuziekNummerDTO muzieknummerDTO = IMuziekNummer.SelectNummer(ID);


                return MaakNummer(muzieknummerDTO);
            }
            public bool UpdateNummer(Muzieknummer nummer)
            {

                return IMuziekNummer.UpdateNummer(MaakNummerDTO(nummer));
            }
            
            public bool InsertNummer(Muzieknummer nummer)
            {
                
                return IMuziekNummer.InsertNummer(MaakNummerDTO(nummer));
            }
            public List<Muzieknummer> Selectnummers()
            {
                List<MuziekNummerDTO> muziekNummerDTOs;
                muziekNummerDTOs = IMuziekNummer.SelectNummerList();
                List<Muzieknummer> muzieknummers = new List<Muzieknummer>();

                foreach(MuziekNummerDTO muziekNummerDTO in muziekNummerDTOs)
                    {
                        Muzieknummer nummer = MaakNummer(muziekNummerDTO);
                        muzieknummers.Add(nummer);
                    }
                return muzieknummers;
            }
            public List<Muzieknummer> SelectNummersWithQuery(string Query)
            {
                List<MuziekNummerDTO> muziekNummerDTOs;
                muziekNummerDTOs = IMuziekNummer.SelectNummersWithQuery(Query);
                List<Muzieknummer> muzieknummers = new List<Muzieknummer>();
                foreach(MuziekNummerDTO muziekNummerDTO in muziekNummerDTOs)
                {
                    Muzieknummer nummer = MaakNummer(muziekNummerDTO);
                    muzieknummers.Add(nummer);
                }
                return muzieknummers;
            }
            public List<Muzieknummer> SelectNummersWithUserID(int id)
            {
            List<MuziekNummerDTO> muziekNummerDTOs;
            muziekNummerDTOs = IMuziekNummer.SelectNummersWithUserID(id);
            List<Muzieknummer> muzieknummers = new List<Muzieknummer>();
            foreach (MuziekNummerDTO muziekNummerDTO in muziekNummerDTOs)
            {
                Muzieknummer nummer = MaakNummer(muziekNummerDTO);
                muzieknummers.Add(nummer);
            }
            return muzieknummers;
        }
            
            public MuziekNummerContainer(IMuziekNummer nummer)
            {
                IMuziekNummer = nummer;
            }

    }
}
