using Inter.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_layer
{
    public class RatingContainer
    {
        public IRating irating { get; set; }

        public RatingContainer(IRating irating)
        {
            this.irating = irating;
        }

        public Rating DtoToRating(RatingDTO ratingDTO)
        {
            Rating rating = new Rating(ratingDTO);
            return rating;
        }
        public bool HasUserRatedUserYet(int loggedInUser, int selectedUser)
        {
            return irating.HasUserRatedUserYet(loggedInUser, selectedUser);
        }
        public bool HasUserRatedNummerYet(int userid, int nummerid)
        {
            return irating.HasUserRatedNummerYet(userid, nummerid);
        }
        public List<Rating> UserRatings(int userID)
        {
            List<RatingDTO> DTOs = irating.UserRatings(userID);

            List<Rating> ratings = new List<Rating>();

            foreach(RatingDTO ratingDTO in DTOs)
            {
                ratings.Add(DtoToRating(ratingDTO));
            }
            return ratings;
        }
        public List<Rating> NummerRatings(int nummerID)
        {
            List<RatingDTO> DTOs = irating.NummerRatings(nummerID);

            List<Rating> ratings = new List<Rating>();

            foreach (RatingDTO ratingDTO in DTOs)
            {
                ratings.Add(DtoToRating(ratingDTO));
            }
            return ratings;
        }
        public List<Rating> AllNummerRatings(int userID)
        {
            List<RatingDTO> DTOs = irating.AllNummerRatings(userID);

            List<Rating> ratings = new List<Rating>();

            foreach (RatingDTO ratingDTO in DTOs)
            {
                ratings.Add(DtoToRating(ratingDTO));
            }
            return ratings;
        }

    }
}
