using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using NUnit.Framework;

namespace LINQTraining.SolutionExample
{
    [TestFixture]
    public class Solutions : Exercises
    {
        [Test]
        public override void NumberOfAdults()
        {
        }

        [Test]
        public override void DisplayRedHairedAdultsBetween37And53()
        {
        }

        [Test]
        public override void HowManyFamiliesLiveAt()
        {
            List<Family> families = ctx.Families.Where(f => f.StreetName.Equals("Abby Park Street")).ToList();
            Console.WriteLine(families.Count); 
        }

        [Test]
        public override void HowManyFamiliesHaveOneParent()
        {
            var result = ctx.Families.
                Where(family => family.Adults.Count == 1).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyFamiliesLiveInNumberThreeOrFive()
        {
            var result = ctx.Families.
                Where(family => family.HouseNumber == 3 || family.HouseNumber == 5).ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyFamiliesHaveADog()
        {
            var result = ctx.Families.
                Where(family => family.Pets.Any(pet => pet.Species.Equals("Dog"))).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyFamiliesHaveCatAndDog()
        {
            var result = ctx.Families.
                Where(family => 
                    family.Pets.Any(petDog => petDog.Species.Equals("Dog") &&
                                              family.Pets.Any(petCat => petCat.Species.Equals("Cat"))                                           
                    )).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyFamiliesHave3Children()
        {
            List<Family> families = ctx.Families.Where(family => family.Children.Count == 3).ToList();
            Console.WriteLine(families.Count); 
        }

        [Test]
        public override void How_Many_Families_Have_Gay_Parents()
        {
            var families = ctx.Families.
                Where(family => family.Adults.Count == 2).
                Where(family => 
                    family.Adults.Count(adult => 
                        adult.Sex.Equals(family.Adults.First().Sex)) == 2).
                ToList();
            Console.WriteLine(families.Count); 
        }

        [Test]
        public override void How_Many_Families_Have_An_Adult_With_Red_Hair()
        {
            var result = ctx.Families.
                Where(family => family.Adults.Any(adult => adult.HairColor.Equals("Red"))).
                ToList();

            Console.WriteLine(result.Count);
        }

        [Test]
        public override void How_Many_Families_Have_2_Pets()
        {
            var result = ctx.Families.Where(family => family.Pets.Count == 2).ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void How_Many_Families_Have_A_Child_Playing_Soccer()
        {
            var result = ctx.Families.Where(family => family.Children.Any(
                child => child.Interests.Any(
                    childInterest => childInterest.Type.Equals("Soccer")))).ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void How_Many_Families_Have_Adult_And_Child_With_Black_Hair()
        {
            var result = ctx.Families.
                Where(family => 
                    family.Adults.Any(adult => 
                        adult.HairColor.Equals("Black")) && 
                    family.Children.Any(child => 
                        child.HairColor.Equals("Black"))).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void How_Many_Families_Have_A_Child_With_Black_Hair_Playing_Ultimate()
        {
            var result = ctx.Families.
                Where(family => 
                    family.Children.Any(
                        child => child.HairColor.Equals("Black")
                                 && 
                                 child.Interests.Any(
                                     childInterest => childInterest.Type.Equals("Ultimate")))).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyFamiliesHaveTwoAdultsWithSameHairColor()
        {
            var result = ctx.Families.
                Where(family => family.Adults.Count == 2 &&
                                family.Adults.Count(adult => 
                                    adult.HairColor.Equals(family.Adults.First().HairColor)) == 2).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyFamiliesHaveAChildWithAHamster()
        {
            var result = ctx.Families.
                Where(family =>
                    family.Children.Any(child => 
                        child.Pets.Any(pet => pet.Species.Equals("Hamster")))).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyChildrenAreInterestedInBothSoccerAndBarbies()
        {
            var result = ctx.Families.
                SelectMany(family => family.Children).
                Where(child => 
                    child.Interests.Any(interest => interest.Type.Equals("Soccer")) && 
                    child.Interests.Any(interest => interest.Type.Equals("Barbie"))).
                ToList();
            Console.WriteLine(result.Count);
        }

        [Test]
        public override void HowManyChildrenAreOfHeightBetween95And112()
        {
            int count = ctx.Families.
                SelectMany(family => family.Children)
                .Count(child => child.Height >= 95 && child.Height <= 112);
            Console.WriteLine(count);
        }
    }
}