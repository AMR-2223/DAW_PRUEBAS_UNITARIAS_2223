using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS; //AMR2223 este es el nombre del namespace 

namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTest
    {
        [TestMethod]
        public void prueba1_validarIngreso()
        {
            // AMR2223 simulamos ingreso
            double saldoInicial = 0;
            double ingreso = -250;
            double saldoEsperado = -250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo incorrecto.");
        }

        [TestMethod]
        public void prueba2_validarIngreso()
        {
            // AMR2223 simulamos ingresos varias cantidades
            double[] saldoInicial = new double[] { 0, 0, 2500, 1000000 };
            double[] ingreso = new double[] { 0, 750, 2500, 1000000 };
            double[] saldoEsperado = new double[] { 0, 750, 5000, 2000000 };

            for (int i = 0; i < saldoEsperado.Length; i++)
            {
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial[i]);
                // Método a probar
                miApp.realizarIngreso(ingreso[i]);
                Assert.AreEqual(saldoEsperado[i], miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo incorrecto.");
            }
        }

        [TestMethod]
        public void prueba3_validarReintegro()
        {
            // AMR2223 simulamos reintegro
            double saldoInicial = 0;
            double reintegro = -250;
            double saldoEsperado = -250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        [TestMethod]
        public void prueba4_validarReintegro()
        {
            // AMR2223 simulamos reintegros varias cantidades
            double[] saldoInicial = new double[] { 0, 750, 5000, 2000000 };
            double[] reintegro = new double[] { 0, 750, 2500, 1000000 };
            double[] saldoEsperado = new double[] { 0, 0, 2500, 1000000 };

            for (int i = 0; i < saldoEsperado.Length; i++)
            {
                GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial[i]);
                // Método a probar
                miApp.realizarReintegro(reintegro[i]);
                Assert.AreEqual(saldoEsperado[i], miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo incorrecto.");
            }
        }
                
        [TestMethod]
        public void prueba5_validarReintegro()
        {
            // AMR2223 simulamos reintegro
            double saldoInicial = 1000;
            double reintegro = 2000;
            double saldoEsperado = 0;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        /*[TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegro = 1250; // AMR2223
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarReintegro(reintegro);
        }*/

        [TestMethod]
        public void validarReintegroCantidadNoValida() //AMR2223
        {
            double saldoInicial = 1000;
            double reintegro = -250;
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void validarIngresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingreso = -250; // AMR2223
            double saldoFinal = saldoInicial + ingreso;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            miApp.realizarIngreso(ingreso);
        }
    }
}