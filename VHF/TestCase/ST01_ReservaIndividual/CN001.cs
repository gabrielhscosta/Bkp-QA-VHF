using VHF.Main;
using VHF.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VHF.TestCase.ST01_ReservaIndividual
{
    public class CN001 : SessaoMain
    {
        public CN001()
        {

        }

        public void ReservaIndividual()
        {
            FuncComuns funcComuns = new FuncComuns();

            funcComuns.ChamarAtalho("e", "i");

            funcComuns.InserirNumNoites();

            funcComuns.CriaReserva();
        }

    }
}
