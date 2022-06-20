using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions.Brazil;

namespace VHF.CommonMethods
{
    public class GeradorDadosFakes
    {

        public static HospedeFake ListaDadosFakerPessoa()
        {
            var dadosFaker = new Faker<HospedeFake>("pt_BR").StrictMode(true)
                .RuleFor(p => p.CPFFaker, f => f.Person.Cpf())
                .RuleFor(p => p.NomeFaker, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(p => p.SobrenomeFaker, f => f.Name.LastName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(p => p.EmailFaker, f => f.Internet.Email(f.Person.FirstName, f.Person.LastName).ToLower())
                .RuleFor(p => p.DtNascFaker, f => "24031989")
                .RuleFor(p => p.CEPFaker, f => "57062422")
                .RuleFor(p => p.CidadeFaker, f => "Maceio");
            var pessoa = dadosFaker.Generate();

            return pessoa;

        }

    }
}
