using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentSowing
{
    class Program
    {
        static ICollection<string> _teams;

        static void Main(string[] args)
        {
            _teams = Setter(301);
            var ts = new TeamSowing(_teams);
            var dic = new Dictionary<Guid, string>();
            //dic.ele
            var random = new Random();

            foreach (var i in ts)
            {
              
                Console.WriteLine(i);
            }
            //foreach (var item in _teams)
            //{
            //    Console.WriteLine($"id:{item.Key} name:{item.Value}");
            //}

            Console.ReadKey();
        }
        //static IEnumerable<string> Sowing(IDictionary<Guid.string> teams)
        //{
        //    var list = new List<string>();
        //    var random = new Random();
        //    random.
        //}

        static ICollection<string> Setter(int count)
        {
            var teams = new List<string>();

            for (int i = 0; i < count; i++)
            {
                teams.Add($"team{i}");
            }
            return teams;
        }
    }
    public class TeamSowing : IEnumerable<string>
    {
        private ICollection<string> _teams;
        private Random _random;
        public TeamSowing(ICollection<string> teams)
        {
            _random = new Random();
            
            _teams = teams;
        }

        public IEnumerator<string> GetEnumerator()
        {

            for (int team = 0; team <= _teams.Count; team++)
            {
                var first = _teams.ElementAt(0);
                _teams.Remove(first);
                if (_teams.Count == 0)
                {
                    yield return $"{first}";
                    yield break;
                }
                var seconde = _teams.ElementAt(_random.Next(0, _teams.Count));
                _teams.Remove(seconde);


                yield return $"{first} vs {seconde}";
            }
            //foreach (var team in _teams)
            //{
            //    _teams.Remove(team);
            //    if (_teams.Count == null)
            //    {
            //        yield return $"{team}";
            //        yield break;
            //    }
            //    var index = _random.Next(0, _teams.Count);

            //    yield return $"{team} vs {index}";
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
    }
}
