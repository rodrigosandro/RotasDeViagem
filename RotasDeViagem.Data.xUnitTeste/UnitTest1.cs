using RotasDeViagem.Infra.Data;
using System;
using Xunit;

namespace RotasDeViagem.Data.xUnitTeste
{
    public class UnitTest1
    {
        [Fact]
        public void LendoDB()
        {
            var ReadBD = new LendoMeuDB();
            ReadBD.ListarBD();

        }
    }
}
