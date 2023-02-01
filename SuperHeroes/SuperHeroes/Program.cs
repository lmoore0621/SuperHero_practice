/*
Suppose we have a set of superheroes (Ironman, Warmachine, and Vision). 

Superheroes can both punch and kick.  
Ironman and WarMachine both punch the same way (Jab) while Vision punches differently (Uppercut).  
Similarly, Vision and Ironman kick the same way (Roundhouse) while WarMachine kicks differently (Butterfly).  

For Jab, the sound is "Pow".
For Uppercut, the sound is "Bang". 
For Roundhouse, the sound is "Kaboom". 
For Butterfly, the sound is "Wham".

For each superhero, print their name. 
For each action, print the name of the action and the sound it makes. 
Each sound should be decorated by surrounding **

For example, when Ironman kicks the output should be "Ironman Roundhouse ** Kaboom **" on one line

Complete the program so that Ironman, WarMachine, and Vision all kick and punch.
*/

class IronMan
{
    public string KickAttack(SuperHero superHero)
    {
        var kick = superHero.Kick.SuperHeroKick(superHero);
        return kick;
    }

    public string PunchAttack(SuperHero superHero)
    {
        var punch = superHero.Punch.SuperHeroPunch(superHero);
        return punch;
    }
}

public class SuperHero
{
    public string Name { get; set; }
    public IPunch Punch { get; set; }
    public IKick Kick { get; set; }
}

class Punch : IPunch
{
    public string Jab()
    {
        return "Jab ** Pow **";
    }

    public string Uppercut() 
    { 
        return "Uppercut ** Bang **"; 
    }

    public string SuperHeroPunch(SuperHero hero)
    {
        var vision = "Vision".ToLower();
        var ironman = "Ironman".ToLower();
        var warMachine = "WarMachine".ToLower();

        if (hero.Name == vision)
        {
            return hero.Name + " " + Uppercut();
        }

        return hero.Name + " " + Jab();
    }
}

public interface IPunch
{
    string Jab();
    string Uppercut();
    string SuperHeroPunch(SuperHero hero);
}

class Kick : IKick
{
    public string Roundhouse()
    {
        return "Roundhouse ** Kaboom **";
    }

    public string Butterfly()
    {
        return "Butterfly ** Wham **";
    }

    public string SuperHeroKick(SuperHero hero)
    {
        var vision = "Vision".ToLower();
        var ironman = "Ironman".ToLower();
        var warMachine = "WarMachine".ToLower();

        if (hero.Name == warMachine)
        {
            return hero.Name + " " + Butterfly();
        }

        return hero.Name + " " + Roundhouse();
    }
}

public interface IKick
{
    string Roundhouse();
    string Butterfly();
    string SuperHeroKick(SuperHero hero);
}

class Program
{
    public static void Main(string[] args)
    {
        SuperHero hero = new SuperHero();
        hero.Kick = new Kick();
        hero.Punch = new Punch();
        hero.Name = Console.ReadLine();

        IronMan ironMan = new IronMan();

        Console.WriteLine(ironMan.PunchAttack(hero));
        //Console.WriteLine(ironMan.KickAttack(hero));
    }
}