using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO;

namespace TestMVC.HelperClass
{
   
    public class Dogs
    {
        public IQueryable<SuperDogs> dogs { get; set; }
        public List<SuperDogs> GetHardCodedValues()
        {
            var returnModel = new List<SuperDogs>();

            var firstDog = new SuperDogs
            {
                BreedName = "Labrador",
                DogAge = 1,
                DogName = "HACHIKO",
                DogOwner = "SURAJ SAHOO",

            };

            var secondDog = new SuperDogs
            {
                BreedName = "Labrador",
                DogAge = 2,
                DogName = "STEFFY",
                DogOwner = "XYZ",
            };
            var thirdDog = new SuperDogs
            {
                BreedName = "Golden Retriever",
                DogAge = 3,
                DogName = "LOVELY",
                DogOwner = "PQrS",
            };
            var forthDog = new SuperDogs
            {
                BreedName = "German Spitz",
                DogAge = 5,
                DogName = "CANDY",
                DogOwner = "ABCD",
            };
            var fifthDog = new SuperDogs
            {
                BreedName = "German Sheperd",
                DogAge = 10,
                DogName = "CAPTAIN",
                DogOwner = "Mota",
            };
            var sixthDog = new SuperDogs
            {
                BreedName = "British BullDog",
                DogAge = 10,
                DogName = "BILL",
                DogOwner = "AUTA",
            };
            for (var i = 0; i < 10; i++)
            {
                returnModel.Add(firstDog);
                returnModel.Add(secondDog);
                returnModel.Add(thirdDog);
                returnModel.Add(forthDog);
                returnModel.Add(fifthDog);
                returnModel.Add(sixthDog);
            }
            return returnModel;
        }

        //public IQueryable<SuperDogs> GetHardCodedValues1()
        //{
        //    var returnModel = new List<SuperDogs>();
           

        //var firstDog = new SuperDogs
        //    {
        //        BreedName = "Labrador",
        //        DogAge = 1,
        //        DogName = "HACHIKO",
        //        DogOwner = "SURAJ SAHOO",

        //    };

        //    var secondDog = new SuperDogs
        //    {
        //        BreedName = "Labrador",
        //        DogAge = 2,
        //        DogName = "STEFFY",
        //        DogOwner = "XYZ",
        //    };
        //    var thirdDog = new SuperDogs
        //    {
        //        BreedName = "Golden Retriever",
        //        DogAge = 3,
        //        DogName = "LOVELY",
        //        DogOwner = "PQrS",
        //    };
        //    var forthDog = new SuperDogs
        //    {
        //        BreedName = "German Spitz",
        //        DogAge = 5,
        //        DogName = "CANDY",
        //        DogOwner = "ABCD",
        //    };
        //    var fifthDog = new SuperDogs
        //    {
        //        BreedName = "German Sheperd",
        //        DogAge = 10,
        //        DogName = "CAPTAIN",
        //        DogOwner = "Mota",
        //    };
        //    var sixthDog = new SuperDogs
        //    {
        //        BreedName = "British BullDog",
        //        DogAge = 10,
        //        DogName = "BILL",
        //        DogOwner = "AUTA",
        //    };
        //    for (var i = 0; i < 10; i++)
        //    {
        //        returnModel.Add(firstDog);
        //        returnModel.Add(secondDog);
        //        returnModel.Add(thirdDog);
        //        returnModel.Add(forthDog);
        //        returnModel.Add(fifthDog);
        //        returnModel.Add(sixthDog);
                
        //    }

            
        //    return dogs.All<returnm>
        //}
    }
}
