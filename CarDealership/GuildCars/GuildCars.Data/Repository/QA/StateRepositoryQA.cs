using GuildCars.Data.Interface;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class StateRepositoryQA : IStateRepository
    {
        private static List<State> _states = new List<State>
        {
            new State {StateId=1,StateAbbreviation="AK"},
            new State {StateId=2,StateAbbreviation="AL"},
            new State {StateId=3,StateAbbreviation="AR"},
            new State {StateId=4,StateAbbreviation="AZ"},
            new State {StateId=5,StateAbbreviation="CA"},
            new State {StateId=6,StateAbbreviation="CO"},
            new State {StateId=7,StateAbbreviation="CT"},
            new State {StateId=8,StateAbbreviation="DE"},
            new State {StateId=9,StateAbbreviation="FL"},
            new State {StateId=10,StateAbbreviation="GA"},
            new State {StateId=11,StateAbbreviation="HI"},
            new State {StateId=12,StateAbbreviation="IA"},
            new State {StateId=13,StateAbbreviation="ID"},
            new State {StateId=14,StateAbbreviation="IL"},
            new State {StateId=15,StateAbbreviation="IN"},
            new State {StateId=16,StateAbbreviation="KS"},
            new State {StateId=17,StateAbbreviation="KY"},
            new State {StateId=18,StateAbbreviation="LA"},
            new State {StateId=19,StateAbbreviation="MA"},
            new State {StateId=20,StateAbbreviation="MD"},
            new State {StateId=21,StateAbbreviation="ME"},
            new State {StateId=22,StateAbbreviation="MI"},
            new State {StateId=23,StateAbbreviation="MN"},
            new State {StateId=24,StateAbbreviation="MO"},
            new State {StateId=25,StateAbbreviation="MS"},
            new State {StateId=26,StateAbbreviation="MT"},
            new State {StateId=27,StateAbbreviation="NC"},
            new State {StateId=28,StateAbbreviation="ND"},
            new State {StateId=29,StateAbbreviation="NE"},
            new State {StateId=30,StateAbbreviation="NH"},
            new State {StateId=31,StateAbbreviation="NJ"},
            new State {StateId=32,StateAbbreviation="NM"},
            new State {StateId=33,StateAbbreviation="NV"},
            new State {StateId=34,StateAbbreviation="NY"},
            new State {StateId=35,StateAbbreviation="OH"},
            new State {StateId=36,StateAbbreviation="OK"},
            new State {StateId=37,StateAbbreviation="OR"},
            new State {StateId=38,StateAbbreviation="PA"},
            new State {StateId=39,StateAbbreviation="RI"},
            new State {StateId=40,StateAbbreviation="SC"},
            new State {StateId=41,StateAbbreviation="SD"},
            new State {StateId=42,StateAbbreviation="TN"},
            new State {StateId=43,StateAbbreviation="TX"},
            new State {StateId=44,StateAbbreviation="UT"},
            new State {StateId=45,StateAbbreviation="VA"},
            new State {StateId=46,StateAbbreviation="VT"},
            new State {StateId=47,StateAbbreviation="WA"},
            new State {StateId=48,StateAbbreviation="WI"},
            new State {StateId=49,StateAbbreviation="WV"},
            new State {StateId=50,StateAbbreviation="WY"}
        };
        
        public List<State> GetAll()
        {
            return _states;
        }
    }
}
