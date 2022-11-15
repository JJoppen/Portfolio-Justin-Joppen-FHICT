using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public interface IRating
    {
        public bool InsertUserRating(RatingDTO ratingDTO);
        public bool UpdateUserRating(RatingDTO ratingDTO);
        public bool InsertNummerRating(RatingDTO ratingDTO);
        public bool UpdateNummerRating(RatingDTO ratingDTO);
        public bool HasUserRatedUserYet(int loggedInUser, int selectedUser);
        public bool HasUserRatedNummerYet(int userid, int nummerid);
        public List<RatingDTO> UserRatings(int userID);
        public List<RatingDTO> NummerRatings(int nummerID);
        public List<RatingDTO> AllNummerRatings(int userID);
    }
}
