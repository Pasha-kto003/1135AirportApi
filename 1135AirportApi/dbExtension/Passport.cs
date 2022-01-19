using ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1135AirportApi.db
{
    public partial class Passport
    {
        public static explicit operator PassportApi(Passport passport)
        {
            return new PassportApi
            {
                Id = passport.Id,
                Seria = passport.Seria,
                Nomer = passport.Nomer,
                GainDate = passport.GainDate
            };
        }

        public static explicit operator Passport(PassportApi passport)
        {
            return new Passport
            {
                Id = passport.Id,
                Seria = passport.Seria,
                Nomer = passport.Nomer,
                GainDate = passport.GainDate
            };
        }
    }
}
