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
                .RuleFor(p => p.NomeFaker, f => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(p => p.SobrenomeFaker, f => f.Name.LastName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(p => p.EmailFaker, f => f.Internet.Email(f.Person.FirstName, f.Person.LastName).ToLower())
                .RuleFor(p => p.TratamentoHosp, f => "Senhora")
                .RuleFor(p => p.DtNascFaker, f => "24031989")
                .RuleFor(p => p.CEPFaker, f => "57062422")
                .RuleFor(p => p.CidadeFaker, f => "Maceio");
            var pessoa = dadosFaker.Generate();

            return pessoa;
        }

        public static EmpresaFake ListaDadosFakerEmpresa()
        {
            var dadosFaker = new Faker<EmpresaFake>("pt_BR").StrictMode(true)
                .RuleFor(e => e.CNPJFaker, f => f.Company.Cnpj())
                .RuleFor(e => e.PrefixoCompany, f => "GRP") //f.Company.CompanySuffix())
                .RuleFor(e => e.NomeCompany, f => f.Company.CompanyName())
                .RuleFor(e => e.EmailFaker, f => f.Internet.Email(f.Person.FirstName, f.Person.LastName).ToLower())
                .RuleFor(e => e.CidadeFaker, f => "Maceio")
                .RuleFor(e => e.TelefoneFaker, f => f.Phone.PhoneNumber());
            var empresa = dadosFaker.Generate();

            return empresa;

        }
    }
}
