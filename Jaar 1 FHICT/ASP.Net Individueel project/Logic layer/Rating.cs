using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace Logic_layer
{
    public class Rating
    {
        public int rating { get; set; }
        public int id { get; set; }
        public int userID { get; set; }
        public int nummerID { get; set; }
        public IRating irating { get; set; }

        public Rating(int rating, int id, int userID,int nummerID, IRating irating)
        {
            this.nummerID = nummerID;
            this.rating = rating;
            this.id = id;
            this.userID = userID;
        }
        public Rating(int rating, int id,int userid,IRating irating)
        {
            this.rating = rating;
            this.id = id;
            this.userID = userid;
            this.irating = irating;
        }

        public Rating(int rating, int id)
        {
            this.rating = rating;
            this.id = id;
        }
        public Rating(RatingDTO ratingDTO)
        {
            this.rating = ratingDTO.rating;
            this.id = ratingDTO.id;
            this.userID = ratingDTO.userID;
        }
        public RatingDTO RatingToDTO()
        {
            RatingDTO dto = new RatingDTO
            {
                id = this.id,
                userID = this.userID,
                rating = this.rating,
            };

            return dto;
        }

        public bool InsertUserRating(IRating Irating)
        {
            return Irating.InsertUserRating(RatingToDTO());
        }
        public bool UpdateUserRating( IRating Irating)
        {
            return Irating.UpdateUserRating(RatingToDTO());
        }
        public bool InsertNummerRating( IRating Irating)
        {
            return Irating.InsertNummerRating(RatingToDTO());
        }
        public bool UpdateNummerRating(IRating Irating)
        {
            return Irating.UpdateNummerRating(RatingToDTO());
        }
    }
}
