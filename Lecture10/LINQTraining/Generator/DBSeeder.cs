using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using LINQTraining.DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LINQTraining.Generator
{
    public class DBSeeder
    {
        private class CI
        {
            public Child Child { get; set; }
            public IList<Interest> Interests { get; set; }
        }
        
        public static void Seed(IList<Family> families)
        {
            // CleanInterestObjects(families);

            Console.WriteLine("Inserting Interests...");
            AddInterests(families);
            Console.WriteLine("Done!");

            Console.WriteLine("Caching child interests..");
            List<CI> childInterests = CollectAllChildInterests(families);
            Console.WriteLine("Done!");

            Console.WriteLine("Inserting families..");
            AddFamilies(families);
            Console.WriteLine("Done!");

            Console.WriteLine("Setting child <-> interest relations..");
            SetupChildInterestRelations(childInterests);
            Console.WriteLine("Done!");
        }

        private static void SetupChildInterestRelations(List<CI> childInterests)
        {
            foreach (CI ci in childInterests)
            {
                using FamilyContext ctx = new FamilyContext();
                Child toUpdate = ctx.Set<Child>().First(c => c.Id == ci.Child.Id);
                List<Interest> interests = new();
                foreach (Interest interest in ci.Interests)
                {
                    interests.Add(ctx.Set<Interest>().First(i => i.Type.Equals(interest.Type)));
                }

                toUpdate.Interests = interests;
                ctx.Update(toUpdate);
                ctx.SaveChanges();
            }
        }

        private static void AddFamilies(IList<Family> families)
        {
            foreach (Family family in families)
            {
                using (FamilyContext fctxt = new FamilyContext())
                {
                    fctxt.Families.Add(family);

                    fctxt.Entry(family).State = EntityState.Added;
                    // fctxt.Entry(family).State = EntityState.Detached;
                    fctxt.SaveChanges();
                }
            }
        }

        private static List<CI> CollectAllChildInterests(IList<Family> families)
        {
            List<CI> childInterests = new();
            
            foreach (Family family in families)
            {
                foreach (Child child in family.Children)
                {
                    childInterests.Add(new ()
                    {
                        Child = child,
                        Interests = child.Interests
                    });
                    
                    child.Interests = null;
                }
            }

            return childInterests;
        }


        private static void AddInterests(IEnumerable<Family> families)
        {
            foreach (Family family in families)
            {
                List<Interest> interests = family.Children.SelectMany(x => x.Interests).ToList();

                foreach (Interest entity in interests)
                {
                    using (FamilyContext familyContext = new FamilyContext())
                    {
                        try
                        {
                            // Interest local = familyContext.Set<Interest>()
                            //     .Local
                            //     .FirstOrDefault(entry => entry.Type.Equals(entity.Type));
                            // if (local != null)
                            // {
                            //     // detach
                            //     familyContext.Entry(local).State = EntityState.Detached;
                            // }

                            if (!familyContext.Set<Interest>().Any(e => e.Type.Equals(entity.Type)))
                            {
                                familyContext.Set<Interest>().Add(entity);
                                // Console.WriteLine($"Added interest: {interestType}");

                                // familyContext.Entry(entity).State = EntityState.Modified;
                                familyContext.SaveChanges();
                            }
                        }
                        catch (Exception e)
                        {
                            // Console.WriteLine("Failed when adding " + interestType);
                            Console.WriteLine(e);
                            throw;
                        }

                    }
                }
            }
        }

       /* public static IList<Family> ReadJsonFromFile(string path)
        {
            IList<Family> families;
            using (var jsonReader = File.OpenText(path))
            {
                families = JsonSerializer.Deserialize<List<Family>>(jsonReader.ReadToEnd());
            }

            return families;
        }*/
    }
}