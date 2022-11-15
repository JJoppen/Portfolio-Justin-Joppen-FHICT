using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_layer;
using Inter.Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTesten
{
    [TestClass]

    public class RatingTests
    {
        public static RatingDTO ratingDTO1 = new RatingDTO
        {
            id = 1,
            userID = 1,
            rating = 1
        };
        public static RatingDTO ratingDTO2 = new RatingDTO
        {
            id = 2,
            userID = 2,
            rating = 2
        };
        public static RatingDTO ratingDTO3 = new RatingDTO
        {
            id = 3,
            userID = 3,
            rating = 3
        };
        public static Rating rating1 = new Rating(ratingDTO1);
        public static Rating rating2 = new Rating(ratingDTO2);
        public static Rating rating3 = new Rating(ratingDTO3);
        public static List<Rating> ratings = new List<Rating> { rating1, rating2, rating3 };
        public static List<RatingDTO> ratingDTOs = new List<RatingDTO> {ratingDTO1,ratingDTO2,ratingDTO3 };
        public RatingStub stub = new RatingStub();



        [TestMethod]
        public void TestAllNummerRatings()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int id = 1;
            stub.retlist = ratingDTOs;
            //act
            var retlist = container.AllNummerRatings(id);
            var retid = stub.retid1;

            //assert
            Assert.AreEqual(retid, id);
            for (int i = 0; i > retlist.Count; i++)
            {
                Assert.AreEqual(retlist[i].id, ratingDTOs[i].id);
                Assert.AreEqual(retlist[i].rating, ratingDTOs[i].rating);
                Assert.AreEqual(retlist[i].userID, ratingDTOs[i].userID);
            }
        }
        [TestMethod]
        public void TestHasUserRatedNummerYetTrue()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int nummerid = 1;
            int userid = 1;
            stub.retbool = true;
            //act
            var retbool = container.HasUserRatedNummerYet(userid, nummerid);
            var retid1 = stub.retid1;
            var retid2 = stub.retid2;

            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(retid1, userid);
            Assert.AreEqual(retid2, nummerid);
        }
        [TestMethod]
        public void TestHasUserRatedNummerYetFalse()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int nummerid = 1;
            int userid = 1;
            stub.retbool = false;
            //act
            var retbool = container.HasUserRatedNummerYet(userid, nummerid);
            var retid1 = stub.retid1;
            var retid2 = stub.retid2;

            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(retid1, userid);
            Assert.AreEqual(retid2, nummerid);
        }
        [TestMethod]
        public void TestHasUserRatedUserYetTrue()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int TargetID = 1;
            int ExecuterID = 1;
            stub.retbool = true;
            //act
            var retbool = container.HasUserRatedUserYet(TargetID, ExecuterID);
            var retid1 = stub.retid1;
            var retid2 = stub.retid2;

            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(retid1, TargetID);
            Assert.AreEqual(retid2, ExecuterID);
        }
        [TestMethod]
        public void TestHasUserRatedUserYetFalse()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int TargetID = 1;
            int ExecuterID = 1;
            stub.retbool = false;
            //act
            var retbool = container.HasUserRatedUserYet(TargetID, ExecuterID);
            var retid1 = stub.retid1;
            var retid2 = stub.retid2;

            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(retid1, TargetID);
            Assert.AreEqual(retid2, ExecuterID);
        }
        [TestMethod]
        public void TestInsertNummerRatingTrue()
        {
            //arrange
            stub.retbool = true;

            //act
            var retbool = rating1.InsertNummerRating(stub);
            var retdto = stub.retdto;


            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);

        }
        [TestMethod]
        public void TestInsertNummerRatingFalse()
        {
            //arrange
            stub.retbool = false;
            //act
            var retbool = rating1.InsertNummerRating(stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);

        }
        [TestMethod]
        public void TestInsertUserRatingTrue()
        {
            //arrange
            stub.retbool = true;
            //act
            var retbool = rating1.InsertUserRating(stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);

        }
        [TestMethod]
        public void TestInsertUserRatingFalse()
        {
            //arrange
            stub.retbool = false;
            //act
            var retbool = rating1.InsertNummerRating(stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);

        }
        [TestMethod]
        public void TestNummerRatings()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int id = 1;
            stub.retlist = ratingDTOs;
            //act
            var retlist = container.NummerRatings(id);
            var retid = stub.retid1;

            //assert
            Assert.AreEqual(retid, id);
            for (int i = 0; i > retlist.Count; i++)
            {
                Assert.AreEqual(retlist[i].id, ratingDTOs[i].id);
                Assert.AreEqual(retlist[i].rating, ratingDTOs[i].rating);
                Assert.AreEqual(retlist[i].userID, ratingDTOs[i].userID);
            }
        }
        [TestMethod]
        public void TestUpdateNummerRatingTrue()
        {
            //arrange
            stub.retbool = true;

            //act
            var retbool = rating1.UpdateNummerRating(stub);
            var retdto = stub.retdto;


            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);
        }
        [TestMethod]
        public void TestUpdateNummerRatingFalse()
        {
            //arrange
            stub.retbool = false;

            //act
            var retbool = rating1.UpdateNummerRating(stub);
            var retdto = stub.retdto;


            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);
        }
        [TestMethod]
        public void TestUpdateUserRatingTrue()
        {
            //arrange
            stub.retbool = true;
            //act
            var retbool = rating1.UpdateUserRating(stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsTrue(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);
        }
        [TestMethod]
        public void TestUpdateUserRatingFalse()
        {
            //arrange
            stub.retbool = false;
            //act
            var retbool = rating1.UpdateUserRating(stub);
            var retdto = stub.retdto;
            //assert
            Assert.IsFalse(retbool);
            Assert.AreEqual(retdto.id, rating1.id);
            Assert.AreEqual(retdto.userID, rating1.userID);
            Assert.AreEqual(retdto.rating, rating1.rating);
        }
        [TestMethod]
        public void TestUserRatings()
        {
            //arrange
            RatingContainer container = new RatingContainer(stub);
            int id = 1;
            stub.retlist = ratingDTOs;
            //act
            var retlist = container.UserRatings(id);
            var retid = stub.retid1;

            //assert
            Assert.AreEqual(retid, id);
            for (int i = 0; i > retlist.Count; i++)
            {
                Assert.AreEqual(retlist[i].id, ratingDTOs[i].id);
                Assert.AreEqual(retlist[i].rating, ratingDTOs[i].rating);
                Assert.AreEqual(retlist[i].userID, ratingDTOs[i].userID);
            }
        }

    }
}
