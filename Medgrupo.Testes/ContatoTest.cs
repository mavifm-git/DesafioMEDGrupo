using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedGrupo.Business.Models;
using MedGrupo.Business.Interfaces;
using MedGrupo.Business.Services;
using System;
using NSubstitute;

namespace Medgrupo.Testes
{
    [TestClass]
    public class ContatoTest
    {
    
        public ContatoTest()
        {

        }

        private static Contato CreateContato()
        {
            var contato = new Contato(){
                Nome = "Marcus Vinicius",
                Sexo = "Masculino",
                DataNascimento = DateTime.Parse("1979-07-12")
            };

            return contato;
        }



        [TestMethod]
        public void InserirContato()
        {
                var contatoMock = Substitute.For<IContatoRepository>();
                var contato = CreateContato();
            
                var ContatoService = new ContatoService(contatoMock);

                var retorno = ContatoService.Adicionar(contato);

                contatoMock.Received().Adicionar(contato);

                Assert.IsTrue(retorno.Result.Sucess==true,retorno.Result.Msg);
           
        }





        [TestMethod]
        public void AtualizarContato()
        {
            var contatoMock = Substitute.For<IContatoRepository>();
            var contato = CreateContato();

            contato.Nome = "João José";

            var ContatoService = new ContatoService(contatoMock);
            var retorno = ContatoService.Atualizar(contato);

            contatoMock.Received().Atualizar(contato);

            Assert.IsTrue(retorno.Result.Sucess==true,retorno.Result.Msg);
            
        }



    }
}
