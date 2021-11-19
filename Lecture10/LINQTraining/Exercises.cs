using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DataGenerator.Generator;
using LINQTraining.DataAccess;
using LINQTraining.Generator;
using Microsoft.EntityFrameworkCore;
using Models;
using NUnit.Framework;
using static LINQTraining.PrintUtil.Printer;

namespace LINQTraining
{
    [TestFixture]
    public class Exercises
    {
        /**
         * Intro text
         * In this exercise you are supposed to solve all questions using only the ctx.Families entry point to the database.
         * That means if you use e.g. ctx.Set<Child>()... you are taking an unintended shortcut.
         *
         * All questions can be answered with one statement. Though, if you're stuck you may find it easier to break it down
         * into multiple consecutive statements.
         *
         * Again, you have access to the PrettyPrint method. In this case however, it's a bit limited, because it cannot print
         * out nested objects. E.g. a Family have Adults, but that will not be printed out in a neat way.
         *
         * All questions have the correct answer above them in a comment
         */
        protected FamilyContext ctx;

        [SetUp]
        public virtual void Setup()
        {
            ctx = new FamilyContext();
        }

      /*
       [Test]
        public virtual void CreateAndSeed()
        {
            IList<Family> families = new FamilyGenerator().GenerateFamilies(500);
            string famSerialized = JsonSerializer.Serialize(families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            DBSeeder.Seed(families);
        }*/

        // example
        [Test]
        public virtual void NumberOfAdults()
        {
            List<Adult> adults = ctx.Families.SelectMany(family => family.Adults).ToList();
            PrettyPrint(adults);
            int numOfAdults = adults.Count();
            Console.WriteLine(numOfAdults);
        }

        // example
        [Test]
        public virtual void DisplayRedHairedAdultsBetween37And53()
        {
            List<Adult> adults = ctx.Families.SelectMany(family => family.Adults).Where(adult =>
                adult.HairColor.Equals("Red") &&
                adult.Age >= 37 &&
                adult.Age <= 53
            ).ToList();
            PrettyPrint(adults);
        }
        // answer: 5
        [Test]
        public virtual void HowManyFamiliesLiveAt()
        {
            // street "Abby Park Street"
            List<Family> families = ctx.Families.Where(fam => fam.StreetName.Equals("Abby Park Street")).ToList();
            Console.WriteLine(families.Count);
        }
        // answer 151
        [Test]
        public virtual void HowManyFamiliesHaveOneParent()
        {
            // we are looking for the number families, which have exactly one parent.
            List<Family> families = ctx.Families.Where(f => f.Adults.Count == 1).ToList();
            Console.WriteLine(families.Count);
        }
        // answer: 123
        [Test]
        public virtual void HowManyFamiliesLiveInNumberThreeOrFive()
        {
            // no matter which street, just focus on house number
            List<Family> families = ctx.Families.Where(f => f.HouseNumber == 3 || f.HouseNumber == 5).ToList();
            Console.WriteLine(families.Count);
        }

        // answer: 94
        [Test]
        public virtual void HowManyFamiliesHaveADog()
        {
            // one or more dogs>
            List<Family> families = ctx.Families.Where(f => f.Pets.Any(p => p.Species == "dog")).ToList();
            Console.WriteLine(families.Count);
        }

        // answer: 18
        [Test]
        public virtual void HowManyFamiliesHaveCatAndDog()
        {
            // one or more of either. But at least one dog, and at least one cat
            List<Family> families = ctx.Families.Where(f => f.Pets.Any(p => p.Species == "dog" && p.Species == "cat")).ToList();
            Console.WriteLine(families.Count);
        }


        // answer 125
        [Test]
        public virtual void HowManyFamiliesHave3Children()
        {
            // exactly 3 children
            List<Family> families = ctx.Families.Where(f => f.Children.Count == 3).ToList();
            Console.WriteLine(families.Count);
        }

        // answer: 175
        [Test]
        public virtual void How_Many_Families_Have_Gay_Parents()
        {
            // looking for families with two parents of the same sex
            // this one is pretty tough in one query, if you don't all ToList() before the end.
            List<Family> families = ctx.Families.Include(f => f.Adults).Where(family => family.Adults.Count == 2)
                .ToList().FindAll(family => family.Adults[0].Sex.Equals(family.Adults[1].Sex));
            Console.WriteLine(families.Count);
        }


        // answer 21
        [Test]
        public virtual void How_Many_Families_Have_An_Adult_With_Red_Hair()
        {
            // count the number of families with at least one adult with red hair.
            List<Family> families = ctx.Families.Where(f => f.Adults.Any(a => a.HairColor == "red")).ToList();
            Console.WriteLine(families.Count);
        }


        // answer: 26
        [Test]
        public virtual void How_Many_Families_Have_2_Pets()
        {
            // Exactly 2 pets. Doesn't matter what type of pet. Ignore the children's pets for this one.
            List<Family> families = ctx.Families.Where(f => f.Pets.Count == 2).ToList();
            Console.WriteLine(families.Count);
        }


        // answer: 81
        [Test]
        public virtual void How_Many_Families_Have_A_Child_Playing_Soccer()
        {
            // at least one child.
            List<Family> families = ctx.Families
                .Where(f => f.Children.Any(child => child.Interests.Any(i => i.Type == "soccer"))).ToList();
            Console.WriteLine(families.Count);
        }

        // answer: 355
        [Test]
        public virtual void How_Many_Families_Have_Adult_And_Child_With_Black_Hair()
        {
            // count number of families where at least one adult and one child have black hair
            List<Family> families = ctx.Families
                .Where(f => f.Adults.Any(adult => adult.HairColor == "black") && f.Children.Any(child => child.HairColor == "black")).ToList();
            Console.WriteLine(families.Count);
          
        }


        // answer: 47
        [Test]
        public virtual void How_Many_Families_Have_A_Child_With_Black_Hair_Playing_Ultimate()
        {
            // count number of families where at least one child has black hair and plays ultimate
            List<Family> families = ctx.Families.Where(f =>
                    f.Children.Any(
                        child => child.HairColor == "black" && child.Interests.Any(i => i.Type == "Ultimate")))
                .ToList();
            Console.WriteLine(families.Count);
        }


        // answer: 172
        [Test]
        public virtual void HowManyFamiliesHaveTwoAdultsWithSameHairColor()
        {
            List<Family> families = ctx.Families.Include(f => f.Adults).Where(family => family.Adults.Count == 2)
                .ToList().FindAll(family => family.Adults[0].HairColor.Equals(family.Adults[1].HairColor));
            Console.WriteLine(families.Count);
            
        }

        // answer: 90
        [Test]
        public virtual void HowManyFamiliesHaveAChildWithAHamster()
        {
            List<Family> families = ctx.Families
                .Where(f => f.Children.Count == 1 && f.Pets.Any(p => p.Species == "Hamster")).ToList();
            Console.WriteLine(families.Count);
        }

        
        // Answer: 5
        [Test]
        public virtual void HowManyChildrenAreInterestedInBothSoccerAndBarbies()
        {
            List<Family> families = ctx.Families
                .Where(f => f.Children.Any(child => child.Interests.Any(i => i.Type == "soccer" && i.Type == "Barbies"))).ToList();
            Console.WriteLine(families.Count);
        }

        
        // answer 157
        [Test]
        public virtual void HowManyChildrenAreOfHeightBetween95And112()
        {
            List<Family> families = ctx.Families
                .Where(f => f.Children.Any(child => child.Height > 94 && child.Height < 113)).ToList();
            Console.WriteLine(families.Count);
        }
    }
}