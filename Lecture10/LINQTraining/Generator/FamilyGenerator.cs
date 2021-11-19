using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Models.StaticData;

namespace DataGenerator.Generator {
public class FamilyGenerator {
    private Random rand = new();
    private Dictionary<string, int> streetNumbersTaken;
    private int childId = 1;
    // private int adultId = 0;
    // private int petId = 0;

    public FamilyGenerator() {
        streetNumbersTaken = new Dictionary<string, int>();
    }

    public IList<Family> GenerateFamilies(int numToGenerate) {
        IList<Family> families = new List<Family>();
        for (int i = 0; i < numToGenerate; i++) {
            Family fam = GenerateOneFamily();

            families.Add(fam);
        }

        return families;
    }

    public Child GenerateChild(Family family, int[] ageRange, string lastName) {
        Child c = new Child();
        // c.Id = (++childId);
        c.Id = childId++;
        c.Age = rand.Next(ageRange[1] - ageRange[0]) + ageRange[0];
        c.Sex = rand.Next(2) == 0 ? "F" : "M";

        // setting height
        if (c.Age == 0) {
            c.Height = 50 + rand.Next(11) - 5;
        } else if (c.Age == 1) {
            c.Height = 70 + rand.Next(15) - 7;
        } else if (c.Age < 17) {
            int tmp = c.Age * 6 + 77;
            c.Height = tmp + rand.Next((int) (tmp * 0.4)) - (int) (tmp * 0.2);
            if (c.Sex.Equals("F")) {
                c.Height -= rand.Next(5);
            }
        } else if (c.Age >= 17) {
            string s = c.Sex;

            int result = GenerateAdultHeight(s);

            c.Height = result;
        }

        //float cWeight = c.Weight;
        int cHeight = c.Height;
        float cWeight = GenerateWeight(cHeight);

        if (c.Sex.Equals("F")) {
            cWeight -= cWeight * 0.15f;
        }

        c.Weight = cWeight;
        c.EyeColor = GenerateEyeColor(family.Adults).ToString();
        c.HairColor = GenerateHairColor().ToString();
        if (c.Sex.Equals("F")) {
            c.FirstName = FemaleName.list[rand.Next(FemaleName.list.Length)];
        } else {
            c.FirstName = MaleName.list[rand.Next(MaleName.list.Length)];
        }

        c.LastName = !"".Equals(lastName) && lastName != null ?
            lastName :
            LastName.list[rand.Next(LastName.list.Length)];

        foreach (Adult parent in family.Adults) {
            if (c.LastName.Equals(parent.LastName)) {
                c.LastName += " Jr.";
            }
        }

        c.Pets = GenerateChildPets();

        List<Interest> interests = new List<Interest>();
        double chance = 1.0;

        while (chance >= rand.NextDouble()) {

            int index = rand.Next(InterestTypes.dic.Count);
            string interestType = InterestTypes.dic.Keys.ToArray()[index];
            Interest interest = new Interest
            {
                Type = interestType,
                Description = InterestTypes.dic[interestType]
            };
            
            if (!interests.Any(i => i.Type.Equals(interest.Type))) {
                interests.Add(interest);
            }

            chance *= 0.8;
        }

        c.Interests = interests;
        return c;
    }

    private float GenerateWeight(int height) {
        // TODO noget går galt, den kan blive negativ

        int weightDist = rand.Next(100) + 1;
        if (height < 100) weightDist -= 50;
        else if (height < 120) weightDist -= 35;
        else if (height < 150) weightDist -= 20;

        float cWeight = 0;
        if (weightDist < 15) {
            float scale = 0.2f * height;
            cWeight = scale + rand.Next((int) (scale * 0.4)) - (int) (scale * 0.1);
        } else if (weightDist < 65) {
            float scale = 0.40f * height;
            cWeight = scale + rand.Next((int) (scale * 0.4)) - (int) (scale * 0.2);
        } else if (weightDist < 90) {
            float scale = 0.57f * height;
            cWeight = scale + rand.Next((int) (scale * 0.4)) - (int) (scale * 0.2);
        } else if (weightDist <= 100) {
            float scale = 0.8f * height;
            cWeight = scale + rand.Next((int) (scale * 0.4)) - (int) (scale * 0.2);
        }

        cWeight = MathF.Round(cWeight, 1);
        return cWeight;
    }

    private Family GenerateOneFamily() {
        Family fam = new Family();
        fam.Adults = GenerateParents();
        fam.Children = GenerateChildren(fam);

        fam.Pets = GenerateFamilyPets();

        fam.StreetName = Street.list[rand.Next(Street.list.Length)];
        if (streetNumbersTaken.ContainsKey(fam.StreetName)) {
            int famHouseNumber = streetNumbersTaken[fam.StreetName] + 1;
            fam.HouseNumber = famHouseNumber;
            streetNumbersTaken[fam.StreetName] = famHouseNumber;
        } else {
            fam.HouseNumber = 1;
            streetNumbersTaken.Add(fam.StreetName, 1);
        }

        return fam;
    }

    private List<Pet> GenerateFamilyPets() {
        List<Pet> pets = new List<Pet>();

        double chance = 0.3;
        while (chance > rand.NextDouble()) {
            Pet p = new Pet();
            p.Species = rand.Next(2) == 0 ? "Cat" : "Dog";
            p.Name = PetNames.list[rand.Next(PetNames.list.Length)];
            p.Age = rand.Next(15);
            // p.Id = petId++;
            pets.Add(p);
            chance *= 0.5;
        }

        return pets;
    }

    private List<Child> GenerateChildren(Family family) {
        string lastName;
        if (family.Adults.Count > 0) {
            lastName = family.Adults[rand.Next(family.Adults.Count)].LastName;
        } else {
            lastName = LastName.list[rand.Next(LastName.list.Length)];
        }

        int youngestParentAge = 100;
        foreach (Adult parent in family.Adults) {
            youngestParentAge = Math.Min(youngestParentAge, parent.Age);
        }

        int[] ageRange = {0, youngestParentAge - 17};

        List<Child> children = new List<Child>();

        int childRange = rand.Next(100) + 1;
        int[] spread = {5, 19, 38, 23, 9, 3, 2, 1}; // distribution of how many children a family has
        int idx = 0;
        int counter = spread[idx];

        while (counter < childRange) {
            Child c = GenerateChild(family, ageRange, lastName);
            c.LastName = lastName ?? c.LastName;

            children.Add(c);
            idx++;
            counter += spread[idx];
        }

        return children;
    }

    private List<Adult> GenerateParents() {
        List<Adult> parents = new List<Adult>();
        int chance = rand.Next(100) + 1;
        int numOfParents = 2;

        if (chance < 10) {
            numOfParents = 0;
        }

        if (chance < 30) {
            numOfParents = 1;
        }


        int[] ageRange = new int[2];
        ageRange[0] = 30;
        ageRange[1] = 60;

        for (int i = 0; i < numOfParents; i++) {
            Adult adult = GenerateAdult(ageRange);
            if (parents.Count > 0) {
                if (rand.Next(2) == 0) { // couple is married, same last name
                    adult.LastName = parents[0].LastName;
                }
            }

            parents.Add(adult);
        }

        return parents;
    }

    private List<Pet> GenerateChildPets() {
        List<Pet> pets = new List<Pet>();
        double chance = 0.20;
        while (chance > rand.NextDouble()) {
            Pet p = new Pet();
            int petType = rand.Next(100) + 1;
            if (petType < 30) {
                p.Species = PetSpecies.list[0];
            } else if (petType < 60) {
                p.Species = PetSpecies.list[1];
            } else if (petType < 70) {
                p.Species = PetSpecies.list[2];
            } else if (petType < 80) {
                p.Species = PetSpecies.list[3];
            } else if (petType < 85) {
                p.Species = PetSpecies.list[4];
            } else if (petType < 90) {
                p.Species = PetSpecies.list[5];
            } else if (petType < 105) {
                p.Species = PetSpecies.list[6];
            }

            // p.Id = petId++;
            p.Age = rand.Next(5);
            p.Name = PetNames.list[rand.Next(PetNames.list.Length)];
            pets.Add(p);
            chance *= 0.4;
        }

        return pets;
    }

    private HairColor GenerateHairColor() {
        // Ignore parents hair color because you can dye it
        int r = rand.Next(100) + 1;
        if (r < 69) { // black
            return HairColor.Black;
        }

        if (r < 85) {
            return HairColor.Brown;
        }

        if (r < 87) {
            return HairColor.Red;
        }

        if (r < 89) {
            return HairColor.Leverpostej;
        }

        if (r < 93) {
            return HairColor.Blond;
        }

        if (r < 95) {
            return HairColor.White;
        }

        if (r < 98) {
            return HairColor.Grey;
        }

        if (r < 99) {
            return HairColor.Blue;
        }

        if (r < 100) {
            return HairColor.Green;
        }

        return HairColor.Black;
    }

    private EyeColor GenerateEyeColor(List<Adult> familyParents) {
        if (familyParents.Count == 2) { // determine eye color based on parents
            EyeColor p1 = Enum.Parse<EyeColor>(familyParents[0].EyeColor);
            EyeColor p2 = Enum.Parse<EyeColor>(familyParents[1].EyeColor);

            if (IsBrownEye(p1) && IsBrownEye(p2)) {
                int r = rand.Next(100) + 1;
                if (r < 75) { // brown/amber/hazel
                    r = rand.Next(100) + 1;
                    if (r < 88) return EyeColor.Brown;
                    if (r < 94) return EyeColor.Hazel;
                    return EyeColor.Amber;
                }

                if (r < 94) { // blue/grey
                    return rand.Next(3) == 0 ? EyeColor.Grey : EyeColor.Blue;
                }

                // green
                return EyeColor.Green;
            }

            if (IsBrownEye(p1) && IsBlueEye(p2) ||
                IsBrownEye(p2) && IsBlueEye(p1)) {
                int r = rand.Next(100) + 1;
                if (r <= 50) { // brown/amber/hazel
                    r = rand.Next(100) + 1;
                    if (r < 88) return EyeColor.Brown;
                    if (r < 94) return EyeColor.Hazel;
                    return EyeColor.Amber;
                }

                return rand.Next(3) == 0 ? EyeColor.Grey : EyeColor.Blue;
            }

            if ((IsBrownEye(p1) && p2 == EyeColor.Green) ||
                (IsBrownEye(p2) && p1 == EyeColor.Green)) {
                int r = rand.Next(100) + 1;
                if (r < 50) { // brown/amber/hazel
                    r = rand.Next(100) + 1;
                    if (r < 88) return EyeColor.Brown;
                    if (r < 94) return EyeColor.Hazel;
                    return EyeColor.Amber;
                }

                if (r < 12) { // blue/grey
                    return rand.Next(3) == 0 ? EyeColor.Grey : EyeColor.Blue;
                }

                // green
                return EyeColor.Green;
            }

            if (IsBlueEye(p1) && IsBlueEye(p2)) {
                return rand.Next(100) == 0 ? EyeColor.Green : EyeColor.Blue;
            }

            if ((IsBlueEye(p1) && p2 == EyeColor.Green) ||
                (IsBlueEye(p2) && p1 == EyeColor.Green)) {
                return rand.Next(100) < 50 ? EyeColor.Green : EyeColor.Blue;
            }

            if (p1 == EyeColor.Green && p2 == EyeColor.Green) {
                return rand.Next(100) < 75 ? EyeColor.Green : EyeColor.Blue;
            }
        } else { // randomly determine eye color based on world distribution
            int r = rand.Next(100) + 1;
            switch (r) {
                case int n when n < 75:            return EyeColor.Brown;
                case int n when n >= 75 && n < 84: return EyeColor.Blue;
                case int n when n >= 84 && n < 86: return EyeColor.Green;
                case int n when n >= 86 && n < 91: return EyeColor.Hazel;
                case int n when n >= 91 && n < 96: return EyeColor.Amber;
                case int n when n >= 96:           return EyeColor.Grey;
            }
        }

        // default to brown
        return EyeColor.Brown;
    }

    private static bool IsBlueEye(EyeColor p2) {
        return (p2 == EyeColor.Blue || p2 == EyeColor.Grey);
    }

    private static bool IsBrownEye(EyeColor p1) {
        return (p1 == EyeColor.Brown || p1 == EyeColor.Amber || p1 == EyeColor.Hazel);
    }

    private int GenerateAdultHeight(string s) {
        int result = 0;
        double heightDist = rand.NextDouble() * 100f;
        if (heightDist < 2.35) { // 150 - 165
            result = rand.Next(15) + 150;
        } else if (heightDist < 15.85) { // 165 - 169
            result = rand.Next(5) + 165;
        } else if (heightDist < 45.85) { // 169 - 173
            result = rand.Next(5) + 169;
        } else if (heightDist < 79.85) { // 172 - 177
            result = rand.Next(6) + 172;
        } else if (heightDist < 97.35) { // 177 - 181
            result = rand.Next(5) + 177;
        } else if (heightDist < 99.35) { // 181 - 196
            result = rand.Next(15) + 181;
        } else if (heightDist <= 100) { // 196
            result = rand.Next(20) + 196;
        }

        if (s.Equals("F")) {
            result -= rand.Next((int) (result * 0.2f));
        }

        return result;
    }

    public Adult GenerateAdult(int[] ageRange) {
        Adult a = new Adult();
        // a.Id = adultId;
        a.Age = rand.Next(ageRange[1] - ageRange[0]) + ageRange[0];
        a.Sex = rand.Next(2) == 0 ? "F" : "M";
        a.JobTitle = JobTitles.list[rand.Next(JobTitles.list.Length)];
        a.Salary = rand.Next(20000, 100000);
        a.Height = GenerateAdultHeight(a.Sex);
        a.EyeColor = GenerateEyeColor(new List<Adult>()).ToString();
        a.Weight = GenerateWeight(a.Height);
        a.FirstName = a.Sex.Equals("M") ?
            MaleName.list[rand.Next(MaleName.list.Length)] :
            FemaleName.list[rand.Next(FemaleName.list.Length)];
        a.LastName = LastName.list[rand.Next(LastName.list.Length)];
        a.HairColor = GenerateHairColor().ToString();
        // adultId++;
        return a;
    }
}
}