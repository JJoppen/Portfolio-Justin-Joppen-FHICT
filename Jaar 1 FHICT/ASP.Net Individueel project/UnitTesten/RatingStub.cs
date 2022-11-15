using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;


namespace UnitTesten
{
    public class RatingStub : IRating
    {
        public List<RatingDTO> retlist { get; set; }
        public RatingDTO retdto { get; set; }
        public int retid1 { get; set; }
        public int retid2 { get; set; }
        public bool retbool { get; set; }
        public List<RatingDTO> AllNummerRatings(int userID)
        {
            retid1 = userID;
            return retlist;
        }

        public bool HasUserRatedNummerYet(int userid, int nummerid)
        {
            retid1 = userid;
            retid2 = nummerid;
            return retbool;
        }

        public bool HasUserRatedUserYet(int loggedInUser, int selectedUser)
        {
            retid1 = loggedInUser;
            retid2 = selectedUser;
            return retbool;
        }

        public bool InsertNummerRating(RatingDTO ratingDTO)
        {
            retdto = ratingDTO;
            return retbool;
        }

        public bool InsertUserRating(RatingDTO ratingDTO)
        {
            retdto = ratingDTO;
            return retbool;
        }

        public List<RatingDTO> NummerRatings(int nummerID)
        {
            retid1 = nummerID;
            return retlist;
        }

        public bool UpdateNummerRating(RatingDTO ratingDTO)
        {
            retdto = ratingDTO;
            return retbool;
        }

        public bool UpdateUserRating(RatingDTO ratingDTO)
        {
            retdto = ratingDTO;
            return retbool;
        }

        public List<RatingDTO> UserRatings(int userID)
        {
            retid1 = userID;
            return retlist;
        }
    }
}
