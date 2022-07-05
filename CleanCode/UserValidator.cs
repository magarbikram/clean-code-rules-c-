using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class UserValidator
    {
        private readonly ICryptographer _cryptographer;

        public UserValidator(ICryptographer cryptographer)
        {
            _cryptographer = cryptographer;
        }
        public bool CheckPassword(string userName, string password)
        {
            User user = UserGateway.FindByName(userName);
            if (user != User.NULL)
            {
                string codedPhrase = user.GetPhraseEncodedByPassword();
                string phrase = _cryptographer.Decrypt(codedPhrase, password);
                if ("Valid Password".Equals(phrase))
                {
                    Session.Initialize();
                    return true;
                }
            }
            return false;
        }
    }
}
